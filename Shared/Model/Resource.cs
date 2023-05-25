using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SoftwareLogAnalizer.Shared.Model.Enums;
using ResourceType = SoftwareLogAnalizer.Shared.Model.Enums.ResourceType;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Название ресурса")]
        public string ResourceName { get; set; }
        [Display(Name = "Id ресурса в MS Project")]
        public int ProjectResourceId { get; set; }
        [Display(Name = "Тип ресурса")]
        public ResourceType ResourceType { get; set; }
        [Display(Name = "Категория ресурса")]
        public ResourceCategory ResourceCategory { get; set; }
        [Display(Name = "Состояние ресурса")]
        public ResourceUsageState ResourceUsageState { get; set; }
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<SoftwareModule>? SoftwareModules { get; set; }
        public override string ToString()
        {
            return this.ResourceName;
        }
    }
}