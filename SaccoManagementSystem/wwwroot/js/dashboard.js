// Dashboard JavaScript - Separated from HTML
(function () {
    'use strict';

    // Chart configuration
    const colors = {
        primary: '#4e73df',
        success: '#1cc88a',
        info: '#36b9cc',
        warning: '#f6c23e',
        danger: '#e74a3b',
        secondary: '#858796',
        light: '#f8f9fc',
        dark: '#5a5c69'
    };

    let revenueChart, expenseChart;
    let currentChartType = 'line';

    // Initialize dashboard
    function initDashboard() {
        console.log('Initializing dashboard...');

        // Initialize charts
        if (window.chartDataAvailable) {
            renderRevenueChart();
            renderExpenseChart();
        }

        // Initialize DataTable for building table
        initBuildingTable();

        // Set up event listeners
        setupEventListeners();

        console.log('Dashboard initialized successfully.');
    }

    // Set up event listeners
    function setupEventListeners() {
        // Quick filter buttons
        document.querySelectorAll('[data-range]').forEach(button => {
            button.addEventListener('click', function () {
                setDateRange(this.dataset.range);
            });
        });

        // Chart type toggle
        document.querySelectorAll('[data-chart-type]').forEach(button => {
            button.addEventListener('click', function () {
                toggleChartType(this.dataset.chartType);
            });
        });

        // Print button
        const printBtn = document.getElementById('printDashboard');
        if (printBtn) {
            printBtn.addEventListener('click', printDashboard);
        }

        // Export button
        const exportBtn = document.getElementById('exportDashboard');
        if (exportBtn) {
            exportBtn.addEventListener('click', exportDashboard);
        }

        // Refresh button
        const refreshBtn = document.getElementById('refreshDashboard');
        if (refreshBtn) {
            refreshBtn.addEventListener('click', refreshDashboard);
        }
    }

    // Revenue Chart
    function renderRevenueChart() {
        const ctx = document.getElementById('revenueChart');
        if (!ctx) return;

        const labels = window.monthlyLabels || [];
        const incomeData = window.monthlyIncome || [];
        const expenseData = window.monthlyExpenses || [];

        if (revenueChart) {
            revenueChart.destroy();
        }

        revenueChart = new Chart(ctx.getContext('2d'), {
            type: currentChartType,
            data: {
                labels: labels,
                datasets: [{
                    label: 'Revenue',
                    data: incomeData,
                    backgroundColor: 'rgba(28, 200, 138, 0.1)',
                    borderColor: colors.success,
                    pointBackgroundColor: colors.success,
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    fill: true,
                    tension: 0.3,
                    borderWidth: 2
                }, {
                    label: 'Expenses',
                    data: expenseData,
                    backgroundColor: 'rgba(231, 74, 59, 0.1)',
                    borderColor: colors.danger,
                    pointBackgroundColor: colors.danger,
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    fill: true,
                    tension: 0.3,
                    borderWidth: 2
                }]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top',
                        labels: {
                            padding: 20,
                            usePointStyle: true,
                            font: {
                                size: 12,
                                family: 'Nunito'
                            }
                        }
                    },
                    tooltip: {
                        mode: 'index',
                        intersect: false,
                        backgroundColor: 'rgba(0, 0, 0, 0.8)',
                        titleFont: {
                            size: 14,
                            family: 'Nunito'
                        },
                        bodyFont: {
                            size: 13,
                            family: 'Nunito'
                        },
                        callbacks: {
                            label: function (context) {
                                const label = context.dataset.label || '';
                                const value = context.parsed.y;
                                return label + ': Ksh ' + formatCurrency(value);
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        grid: {
                            display: false,
                            drawBorder: false
                        },
                        ticks: {
                            font: {
                                family: 'Nunito',
                                size: 11
                            }
                        }
                    },
                    y: {
                        beginAtZero: true,
                        grid: {
                            borderDash: [2],
                            drawBorder: false
                        },
                        ticks: {
                            font: {
                                family: 'Nunito',
                                size: 11
                            },
                            callback: function (value) {
                                return 'Ksh ' + formatCurrency(value);
                            }
                        }
                    }
                },
                interaction: {
                    intersect: false,
                    mode: 'index'
                }
            }
        });
    }

    // Expense Chart
    function renderExpenseChart() {
        const ctx = document.getElementById('expenseChart');
        if (!ctx) return;

        const categories = window.expenseCategories || [];
        const amounts = window.expenseAmounts || [];
        const percentages = window.expensePercentages || [];

        if (expenseChart) {
            expenseChart.destroy();
        }

        const backgroundColors = [
            colors.primary,
            colors.success,
            colors.info,
            colors.warning,
            colors.danger,
            colors.secondary,
            '#6610f2',
            '#6f42c1'
        ];

        expenseChart = new Chart(ctx.getContext('2d'), {
            type: 'doughnut',
            data: {
                labels: categories,
                datasets: [{
                    data: amounts,
                    backgroundColor: backgroundColors,
                    borderColor: '#fff',
                    borderWidth: 2,
                    hoverOffset: 15
                }]
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                cutout: '65%',
                plugins: {
                    legend: {
                        display: false
                    },
                    tooltip: {
                        backgroundColor: 'rgba(0, 0, 0, 0.8)',
                        titleFont: {
                            size: 13,
                            family: 'Nunito'
                        },
                        bodyFont: {
                            size: 12,
                            family: 'Nunito'
                        },
                        callbacks: {
                            label: function (context) {
                                const label = context.label || '';
                                const value = context.parsed;
                                const total = context.dataset.data.reduce((a, b) => a + b, 0);
                                const percentage = Math.round((value / total) * 100);
                                return label + ': Ksh ' + formatCurrency(value) +
                                    ' (' + percentage + '%)';
                            }
                        }
                    }
                }
            },
            plugins: [{
                id: 'doughnutLabels',
                afterDraw: function (chart) {
                    const ctx = chart.ctx;
                    const meta = chart.getDatasetMeta(0);

                    meta.data.forEach((element, index) => {
                        const label = chart.data.labels[index];
                        const value = chart.data.datasets[0].data[index];
                        const percentage = percentages[index] || 0;

                        if (percentage > 5) {
                            const position = element.tooltipPosition();

                            ctx.save();
                            ctx.textAlign = 'center';
                            ctx.textBaseline = 'middle';
                            ctx.font = 'bold 11px Nunito';

                            // Draw label
                            ctx.fillStyle = '#fff';
                            ctx.fillText(label.substring(0, 10), position.x, position.y);

                            ctx.font = '10px Nunito';
                            ctx.fillText(percentage.toFixed(1) + '%', position.x, position.y + 15);

                            ctx.restore();
                        }
                    });
                }
            }]
        });
    }

    // Initialize DataTable for building table
    function initBuildingTable() {
        const table = document.getElementById('buildingTable');
        if (table && window.jQuery && $.fn.DataTable) {
            $(table).DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
                order: [[4, 'desc']],
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Search buildings..."
                },
                dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>' +
                    '<"row"<"col-sm-12"tr>>' +
                    '<"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
                responsive: true,
                columnDefs: [
                    { responsivePriority: 1, targets: 0 },
                    { responsivePriority: 2, targets: 4 },
                    { responsivePriority: 3, targets: 5 }
                ]
            });
        }
    }

    // Toggle chart type
    function toggleChartType(type) {
        currentChartType = type;
        renderRevenueChart();

        // Update button states
        document.querySelectorAll('[data-chart-type]').forEach(btn => {
            btn.classList.remove('active');
            if (btn.dataset.chartType === type) {
                btn.classList.add('active');
            }
        });
    }

    // Set date range for filters
    function setDateRange(range) {
        const today = new Date();
        const startDate = new Date();
        const endDate = new Date(today);

        switch (range) {
            case 'today':
                startDate.setHours(0, 0, 0, 0);
                break;
            case 'week':
                startDate.setDate(today.getDate() - 7);
                break;
            case 'month':
                startDate.setDate(1);
                break;
            case 'quarter':
                const quarter = Math.floor(today.getMonth() / 3);
                startDate.setMonth(quarter * 3, 1);
                break;
            case 'year':
                startDate.setMonth(0, 1);
                break;
        }

        // Format dates as YYYY-MM-DD
        document.querySelector('input[name="StartDate"]').valueAsDate = startDate;
        document.querySelector('input[name="EndDate"]').valueAsDate = endDate;
    }

    // Update revenue chart with different time periods
    function updateRevenueChart(months) {
        const url = `/Dashboard/GetMonthlyData?months=${months}`;

        fetch(url)
            .then(response => {
                if (!response.ok) throw new Error('Network response was not ok');
                return response.json();
            })
            .then(data => {
                if (revenueChart && data.monthlyData) {
                    revenueChart.data.labels = data.monthlyData.map(d => d.monthYear);
                    revenueChart.data.datasets[0].data = data.monthlyData.map(d => d.income);
                    revenueChart.data.datasets[1].data = data.monthlyData.map(d => d.expenses);
                    revenueChart.update();

                    // Show success notification
                    showNotification('Chart updated successfully', 'success');
                }
            })
            .catch(error => {
                console.error('Error updating chart:', error);
                showNotification('Error updating chart data', 'error');
            });
    }

    // Download chart as image
    function downloadChart(chartId) {
        const chartCanvas = document.getElementById(chartId);
        if (!chartCanvas) return;

        const link = document.createElement('a');
        const timestamp = new Date().toISOString().split('T')[0];
        link.download = `chart-${chartId}-${timestamp}.png`;
        link.href = chartCanvas.toDataURL('image/png');
        link.click();
    }

    // Print dashboard
    function printDashboard() {
        window.print();
    }

    // Export dashboard data
    function exportDashboard() {
        const data = {
            kpis: window.dashboardKPIs || {},
            filter: window.dashboardFilter || {},
            generated: new Date().toISOString()
        };

        const dataStr = JSON.stringify(data, null, 2);
        const dataUri = 'data:application/json;charset=utf-8,' + encodeURIComponent(dataStr);
        const timestamp = new Date().toISOString().split('T')[0];
        const exportFileDefaultName = `dashboard-export-${timestamp}.json`;

        const linkElement = document.createElement('a');
        linkElement.setAttribute('href', dataUri);
        linkElement.setAttribute('download', exportFileDefaultName);
        document.body.appendChild(linkElement);
        linkElement.click();
        document.body.removeChild(linkElement);
    }

    // Show all expenses
    function showAllExpenses() {
        navigateTo('/Expenses');
    }

    // Navigate to URL
    function navigateTo(url) {
        window.location.href = url;
    }

    // Refresh dashboard
    function refreshDashboard() {
        const refreshBtn = document.getElementById('refreshDashboard');
        if (refreshBtn) {
            // Add the refreshing class to rotate the icon
            refreshBtn.classList.add('refreshing');

            // Optional: disable button during refresh
            refreshBtn.disabled = true;

            setTimeout(() => {
                // Remove the class and enable button
                refreshBtn.classList.remove('refreshing');
                refreshBtn.disabled = false;
                // Reload the page
                window.location.reload();
            }, 1000);
        } else {
            window.location.reload();
        }
    }

    // Show notification
    function showNotification(message, type = 'info') {
        // You can implement a toast notification system here
        console.log(`${type.toUpperCase()}: ${message}`);
        alert(message); // Simple alert for now
    }

    // Format currency for Kenyan Shillings
    function formatCurrency(value) {
        return new Intl.NumberFormat('en-KE', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        }).format(value);
    }

    // Expose functions to global scope
    window.Dashboard = {
        init: initDashboard,
        setDateRange: setDateRange,
        toggleChartType: toggleChartType,
        updateRevenueChart: updateRevenueChart,
        downloadChart: downloadChart,
        printDashboard: printDashboard,
        exportDashboard: exportDashboard,
        showAllExpenses: showAllExpenses,
        navigateTo: navigateTo,
        refreshDashboard: refreshDashboard,
        formatCurrency: formatCurrency
    };

    // Initialize when DOM is loaded
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', initDashboard);
    } else {
        initDashboard();
    }

})();