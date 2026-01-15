using System;

namespace SaccoManagementSystem.Models
{
    public class FilterDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? Severity { get; set; }
        public string? Category { get; set; }
        public string? IssueType { get; set; }
        public string? SearchTerm { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}