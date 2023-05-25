using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class SoftwareModule
    {
        public SoftwareModule()
        {
            Sessions = new List<Session>();
            StructuredLogs = new List<StructuredLog>();
        }
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Модуль")]
        public string SoftwareModuleName { get; set; }
        //Resource
        public int ResourceID { get; set; }
        [ForeignKey("ResourceID"), Display(Name = "Ресурс")]
        public virtual Resource?  Resource { get; set; }
        
        public int SoftwareId { get; set; }
        [ForeignKey("SoftwareId"), Display(Name = "Программное обеспечение")]
        public virtual Software? Software { get; set; }
        public virtual List<Session>? Sessions { get; set; }
        public virtual List<StructuredLog>? StructuredLogs { get; set; }

        public override string ToString()
        {
            return this.SoftwareModuleName;
        }
    }
}
