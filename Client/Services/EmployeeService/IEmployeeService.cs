using SoftwareLogAnalizer.Shared.Model;

namespace SoftwareLogAnalizer.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task GetEmployees();
        Task<Employee> GetEmployee(int id);
        List<Company> Companies { get; set; }
        Task GetCompanies();
        List<Resource> Resources { get; set; }
        Task GetResources();

    }
}
