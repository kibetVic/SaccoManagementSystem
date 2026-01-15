using SaccoManagementSystem.Models;
using SaccoManagementSystem.Models.DB;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace SaccoManagementSystem.Services
{
    public interface IClientService
    {
        Task<(bool status, string message, List<Client>)> SaveClient(Client client);
        Task<(bool status, string message, List<Client>)> UpdateClient(Client client);
        Task<(bool status, string message)> DeleteClient(int clientId);
        Task<(bool status, string message, List<Client>)> GetClients();
        Task<(bool status, string message, List<Client>)> GetFilteredClients(FilterDto filter);
        Task<Client?> GetClientById(int clientId);
        Task<Client?> GetClientByCompanyCode(string CompanyCode);
        Task<(bool status, string message, List<Client>)> SearchClients(string searchTerm);
        Task<int> GetTotalClientsCount();
        Task<List<ClientSubscription>> GetClientSubscriptions();
        Task<(bool status, string message)> UpdateSubscription(int clientId, string subscriptionPlan);
        Task<(bool status, string message)> SendWelcomeEmail(int clientId);
    }

    // DTO for client subscription information
    public class ClientSubscription
    {
        public int ClientId { get; set; }
        public string CompanyCode { get; set; } = string.Empty;
        public string SubscriptionPlan { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public int BuildingCount { get; set; }
        public int TenantCount { get; set; }
        public int ActiveLeaseCount { get; set; }
    }

    public class ClientService : BaseService, IClientService
    {
        private readonly ApplicationDBContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationStateProvider _authStateProvider;

        public ClientService(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor, AuthenticationStateProvider authStateProvider)
            : base(db, httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _authStateProvider = authStateProvider;
        }

        private async Task<string> GetUserContextAsync()
        {
            try
            {
                var authState = await _authStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                if (!user.Identity?.IsAuthenticated ?? true)
                {
                    return GetLoggedInUser();
                }

                var loggedInUser = user.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(loggedInUser))
                    loggedInUser = GetLoggedInUser();

                return loggedInUser;
            }
            catch
            {
                return GetLoggedInUser();
            }
        }

        public async Task<(bool status, string message, List<Client>)> SaveClient(Client client)
        {
            try
            {
                var loggedInUser = await GetUserContextAsync();

                if (string.IsNullOrEmpty(loggedInUser))
                    loggedInUser = "System";

                // Check if client already exists (same company name or email)
                var existingClient = await _db.Clients
                    .FirstOrDefaultAsync(c =>
                        (c.CompanyCode != null && c.CompanyCode == client.CompanyCode) ||
                        (c.Email != null && c.Email == client.Email));

                if (existingClient != null)
                {
                    if (existingClient.CompanyCode == client.CompanyCode)
                        return (false, "Client with this company name already exists", new List<Client>());

                    if (existingClient.Email == client.Email)
                        return (false, "Client with this email already exists", new List<Client>());
                }

                // Validate email if provided
                if (!string.IsNullOrEmpty(client.Email) && !IsValidEmail(client.Email))
                {
                    return (false, "Invalid email format", new List<Client>());
                }

                // Create new client
                var newClient = new Client
                {
                    CompanyCode = client.CompanyCode ?? string.Empty,
                    Surname = client.Surname ?? string.Empty,
                    Email = client.Email ?? string.Empty,
                    PhoneNo = client.PhoneNo ?? string.Empty,
                    SubscriptionPlan = client.SubscriptionPlan ?? "Basic",
                    CreatedBy = loggedInUser,
                    UpdatedBy = loggedInUser,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                _db.Clients.Add(newClient);
                await _db.SaveChangesAsync();

                // Get updated list
                var clients = await GetAllClients();
                return (true, "Client added successfully", clients);
            }
            catch (Exception ex)
            {
                return (false, $"Error saving client: {ex.Message}", new List<Client>());
            }
        }

        public async Task<(bool status, string message, List<Client>)> UpdateClient(Client client)
        {
            try
            {
                var loggedInUser = await GetUserContextAsync();

                if (string.IsNullOrEmpty(loggedInUser))
                    loggedInUser = "System";

                // Find existing client
                var existingClient = await _db.Clients
                    .FirstOrDefaultAsync(c => c.ClientId == client.ClientId);

                if (existingClient == null)
                {
                    return (false, "Client not found", new List<Client>());
                }

                // Check for duplicate company name (excluding current client)
                if (!string.IsNullOrEmpty(client.CompanyCode))
                {
                    var duplicateCompany = await _db.Clients
                        .FirstOrDefaultAsync(c =>
                            c.ClientId != client.ClientId &&
                            c.CompanyCode == client.CompanyCode);

                    if (duplicateCompany != null)
                    {
                        return (false, "Another client with the same company name already exists", new List<Client>());
                    }
                }

                // Check for duplicate email (excluding current client)
                if (!string.IsNullOrEmpty(client.Email))
                {
                    var duplicateEmail = await _db.Clients
                        .FirstOrDefaultAsync(c =>
                            c.ClientId != client.ClientId &&
                            c.Email == client.Email);

                    if (duplicateEmail != null)
                    {
                        return (false, "Another client with the same email already exists", new List<Client>());
                    }

                    // Validate email format
                    if (!IsValidEmail(client.Email))
                    {
                        return (false, "Invalid email format", new List<Client>());
                    }
                }

                // Update client properties
                existingClient.CompanyCode = client.CompanyCode ?? existingClient.CompanyCode ?? string.Empty;
                existingClient.Surname = client.Surname ?? existingClient.Surname ?? string.Empty;
                existingClient.Email = client.Email ?? existingClient.Email ?? string.Empty;
                existingClient.PhoneNo = client.PhoneNo ?? existingClient.PhoneNo ?? string.Empty;
                existingClient.SubscriptionPlan = client.SubscriptionPlan ?? existingClient.SubscriptionPlan ?? "Basic";
                existingClient.UpdatedBy = loggedInUser;
                existingClient.DateUpdated = DateTime.Now;

                _db.Clients.Update(existingClient);
                await _db.SaveChangesAsync();

                // Get updated list
                var clients = await GetAllClients();
                return (true, "Client updated successfully", clients);
            }
            catch (Exception ex)
            {
                return (false, $"Error updating client: {ex.Message}", new List<Client>());
            }
        }

        public async Task<(bool status, string message, List<Client>)> GetFilteredClients(FilterDto filter)
        {
            try
            {
                // Base query
                var query = _db.Clients.AsQueryable();

                // Apply search filter if provided
                if (!string.IsNullOrEmpty(filter.SearchTerm))
                {
                    var searchTerm = filter.SearchTerm.ToLower();
                    query = query.Where(c =>
                        (c.CompanyCode != null && c.CompanyCode.ToLower().Contains(searchTerm)) ||
                        (c.Surname != null && c.Surname.ToLower().Contains(searchTerm)) ||
                        (c.Email != null && c.Email.ToLower().Contains(searchTerm)) ||
                        (c.PhoneNo != null && c.PhoneNo.Contains(searchTerm)));
                }

                // Apply date filter if dates are valid
                if (filter.StartDate != default && filter.EndDate != default)
                {
                    query = query.Where(c =>
                        c.DateCreated.Date >= filter.StartDate.Date &&
                        c.DateCreated.Date <= filter.EndDate.Date);
                }

                var clients = await query
                    .OrderBy(c => c.CompanyCode)
                    .Select(c => new Client
                    {
                        ClientId = c.ClientId,
                        CompanyCode = c.CompanyCode ?? string.Empty,
                        Surname = c.Surname ?? string.Empty,
                        Email = c.Email ?? string.Empty,
                        PhoneNo = c.PhoneNo ?? string.Empty,
                        SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                        CreatedBy = c.CreatedBy ?? string.Empty,
                        UpdatedBy = c.UpdatedBy ?? string.Empty,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated
                    })
                    .ToListAsync();

                return (true, "Data retrieved successfully", clients);
            }
            catch (Exception ex)
            {
                return (false, $"Error retrieving clients: {ex.Message}", new List<Client>());
            }
        }

        public async Task<(bool status, string message, List<Client>)> GetClients()
        {
            try
            {
                var clients = await GetAllClients();
                return (true, "Data retrieved successfully", clients);
            }
            catch (Exception ex)
            {
                return (false, $"Error retrieving clients: {ex.Message}", new List<Client>());
            }
        }

        private async Task<List<Client>> GetAllClients()
        {
            return await _db.Clients
                .OrderBy(c => c.CompanyCode)
                .Select(c => new Client
                {
                    ClientId = c.ClientId,
                    CompanyCode = c.CompanyCode ?? string.Empty,
                    Surname = c.Surname ?? string.Empty,
                    Email = c.Email ?? string.Empty,
                    PhoneNo = c.PhoneNo ?? string.Empty,
                    SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                    CreatedBy = c.CreatedBy ?? string.Empty,
                    UpdatedBy = c.UpdatedBy ?? string.Empty,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated
                })
                .ToListAsync();
        }

        public async Task<Client?> GetClientById(int id)
        {
            try
            {
                return await _db.Clients
                    .Where(c => c.ClientId == id)
                    .Select(c => new Client
                    {
                        ClientId = c.ClientId,
                        CompanyCode = c.CompanyCode ?? string.Empty,
                        Surname = c.Surname ?? string.Empty,
                        Email = c.Email ?? string.Empty,
                        PhoneNo = c.PhoneNo ?? string.Empty,
                        SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                        CreatedBy = c.CreatedBy ?? string.Empty,
                        UpdatedBy = c.UpdatedBy ?? string.Empty,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated
                    })
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool status, string message)> DeleteClient(int clientId)
        {
            try
            {
                var client = await _db.Clients
                    .FirstOrDefaultAsync(c => c.ClientId == clientId);

                if (client == null)
                {
                    return (false, "Client not found");
                }

                _db.Clients.Remove(client);
                await _db.SaveChangesAsync();

                return (true, "Client deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error deleting client: {ex.Message}");
            }
        }

        public async Task<Client?> GetClientByCompanyCode(string CompanyCode)
        {
            try
            {
                return await _db.Clients
                    .Where(c => c.CompanyCode == CompanyCode)
                    .Select(c => new Client
                    {
                        ClientId = c.ClientId,
                        CompanyCode = c.CompanyCode ?? string.Empty,
                        Surname = c.Surname ?? string.Empty,
                        Email = c.Email ?? string.Empty,
                        PhoneNo = c.PhoneNo ?? string.Empty,
                        SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                        CreatedBy = c.CreatedBy ?? string.Empty,
                        UpdatedBy = c.UpdatedBy ?? string.Empty,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated
                    })
                    .FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<(bool status, string message, List<Client>)> SearchClients(string searchTerm)
        {
            try
            {
                if (string.IsNullOrEmpty(searchTerm))
                    return await GetClients();

                var clients = await _db.Clients
                    .Where(c =>
                        (c.CompanyCode != null && c.CompanyCode.Contains(searchTerm)) ||
                        (c.Surname != null && c.Surname.Contains(searchTerm)) ||
                        (c.Email != null && c.Email.Contains(searchTerm)) ||
                        (c.PhoneNo != null && c.PhoneNo.Contains(searchTerm)))
                    .OrderBy(c => c.CompanyCode)
                    .Select(c => new Client
                    {
                        ClientId = c.ClientId,
                        CompanyCode = c.CompanyCode ?? string.Empty,
                        Surname = c.Surname ?? string.Empty,
                        Email = c.Email ?? string.Empty,
                        PhoneNo = c.PhoneNo ?? string.Empty,
                        SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                        CreatedBy = c.CreatedBy ?? string.Empty,
                        UpdatedBy = c.UpdatedBy ?? string.Empty,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated
                    })
                    .ToListAsync();

                return (true, "Search completed successfully", clients);
            }
            catch (Exception ex)
            {
                return (false, $"Error searching clients: {ex.Message}", new List<Client>());
            }
        }

        public async Task<int> GetTotalClientsCount()
        {
            try
            {
                return await _db.Clients.CountAsync();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<ClientSubscription>> GetClientSubscriptions()
        {
            try
            {
                var subscriptions = await _db.Clients
                    .Select(c => new ClientSubscription
                    {
                        ClientId = c.ClientId,
                        CompanyCode = c.CompanyCode ?? string.Empty,
                        SubscriptionPlan = c.SubscriptionPlan ?? "Basic",
                        DateCreated = c.DateCreated,
                    })
                    .OrderBy(c => c.CompanyCode)
                    .ToListAsync();

                return subscriptions;
            }
            catch
            {
                return new List<ClientSubscription>();
            }
        }

        public async Task<(bool status, string message)> UpdateSubscription(int clientId, string subscriptionPlan)
        {
            try
            {
                var client = await _db.Clients
                    .FirstOrDefaultAsync(c => c.ClientId == clientId);

                if (client == null)
                    return (false, "Client not found");

                client.SubscriptionPlan = subscriptionPlan;
                client.UpdatedBy = await GetUserContextAsync();
                client.DateUpdated = DateTime.Now;

                _db.Clients.Update(client);
                await _db.SaveChangesAsync();

                return (true, "Subscription updated successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error updating subscription: {ex.Message}");
            }
        }

        public async Task<(bool status, string message)> SendWelcomeEmail(int clientId)
        {
            try
            {
                var client = await _db.Clients
                    .FirstOrDefaultAsync(c => c.ClientId == clientId);

                if (client == null)
                    return (false, "Client not found");

                if (string.IsNullOrEmpty(client.Email))
                    return (false, "Client does not have an email address");

                // Here you would implement your email sending logic
                // For now, we'll just simulate it
                await Task.Delay(100); // Simulate email sending

                return (true, "Welcome email sent successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error sending welcome email: {ex.Message}");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}