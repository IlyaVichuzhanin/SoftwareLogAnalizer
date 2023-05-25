using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class Software
    {
        public Software()
        {
            SoftwareModules = new List<SoftwareModule>();
            Sessions = new List<Session>();
            StructuredLogs = new List<StructuredLog>();
        }
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Програмное обеспечение")]
        public string SoftwareName { get; set; }
        public virtual List<SoftwareModule>? SoftwareModules { get; set; }
        public virtual List<Session>? Sessions { get; set; }
        public virtual List<StructuredLog>? StructuredLogs { get; set; }
        public override string ToString()
        {
            return this.SoftwareName;
        }
    }
}
