using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareLogAnalizer.Shared.Model.Enums;

namespace SoftwareLogAnalizer.Shared.Model
{ 
    public class StructuredLog
    {
        [Key]
        public int? Id { get; set; }
        [Required, Display(Name = "Операция")]
        public Operation Operation { get; set; }
        [Required, Display(Name = "Время")]
        public DateTime OperationDateTime { get; set; }
        public int? SoftwareId { get; set; }
        [ForeignKey("SoftwareId"), Display(Name = "Программное обеспечение")]
        public virtual Software? Software { get; set; }
        public int? SoftwareModuleId { get; set; }

        [ForeignKey("SoftwareModuleId"), Display(Name = "Модуль")]
        public virtual SoftwareModule? SoftwareModule { get; set; }
        public int? SoftwareUserId { get; set; }

        [ForeignKey("SoftwareUserId"), Display(Name = "Пользователь")]
        public virtual SoftwareUser? SoftwareUser { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId"), Display(Name = "Сотрудник")]
        public virtual Employee? Employee { get; set; }
        public bool? LogIsMatched { get; set; }
        public bool? ErrorLog { get; set; }
    }
}
