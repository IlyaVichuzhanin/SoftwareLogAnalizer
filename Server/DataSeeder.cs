using SoftwareLogAnalizer.Shared.Model;
using SoftwareLogAnalizer.Shared.Model.Enums;
using SoftwareLogAnalizer.Client.Pages.Software;

namespace SoftwareLogAnalizer.Server
{
    public class DataSeeder
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            var serviceScope = appBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            var unknownCompany = new Company() { CompanyName = "Unknown" };
            var unknownResource = new Resource() { 
                ResourceName = "Unknown", 
                ProjectResourceId=0, 
                ResourceType=ResourceType.Employee,
                ResourceCategory=ResourceCategory.Internal,
                ResourceUsageState=ResourceUsageState.Used
                };
            var unknownEmployee = new Employee()
            {
                FullName = "Unknown",
                Resource = unknownResource,
                EmployeType = EmployeType.Internal,
                Company = unknownCompany
            };
            var unknownSoftware = new Software() { SoftwareName = "Unknown" };
            var unknownSoftwareModule = new SoftwareModule()
            {
                SoftwareModuleName = "Unknown",
                Resource = unknownResource,
                Software = unknownSoftware
            };
            var unknownUser = new SoftwareUser() { 
                WindowsUserName = "Unknown",
                ComputerUserName = "Unknown",
                Employee = unknownEmployee
            };


            if (!context.Companies.Any())
            {
                context.Companies.Add(unknownCompany);
                context.SaveChanges();
            }

            if (!context.Resources.Any())
            {
                context.Resources.Add(unknownResource);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                context.Employees.Add(unknownEmployee);
                context.SaveChanges();
            }

            if (!context.Softwares.Any())
            {
                context.Softwares.Add(unknownSoftware);
                context.SaveChanges();
            }
            if (!context.SoftwareModules.Any())
            {
                context.SoftwareModules.Add(unknownSoftwareModule);
                context.SaveChanges();
            }
            if (!context.SoftwareUsers.Any())
            {
                context.SoftwareUsers.Add(unknownUser);
                context.SaveChanges();
            }
        }
    }
}
