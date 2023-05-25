using SoftwareLogAnalizer.Shared.Model;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftwareLogAnalizer.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient http;

        public EmployeeService(HttpClient http)
        {
            this.http = http;
        }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Resource> Resources { get; set; } = new List<Resource>();

        public async Task GetCompanies()
        {
            var result = await http.GetFromJsonAsync<List<Company>>("api/Companies/GetCompanies");
            if (result != null)
            {
                Companies = result;
            }
        }

        public Task<Employee> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetEmployees()
        {
            var result = await http.GetFromJsonAsync<List<Employee>>("api/Employees/GetEmployees");
            if (result != null)
            {
                Employees = result;
            }
        }

        public async Task GetResources()
        {
            var result = await http.GetFromJsonAsync<List<Resource>>("api/Resources/GetResources");
            if (result != null)
            {
                Resources = result;
            }
        }
    }
}
