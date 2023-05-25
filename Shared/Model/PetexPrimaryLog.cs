using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class PetexPrimaryLog
    {
        public PetexPrimaryLog(string logInfo)
        {
            LogInfo = logInfo;
            IsLog = ChechLog(logInfo);
            LogIsStructurated = false;
        }
        [Key]
        public long Id { get; set; }
        public string LogInfo { get; set; }
        public bool IsLog { get; set; }
        public bool LogIsStructurated { get; set; }
        public bool ChechLog(string logInfo)
        {
            var operation = Regex.Split(logInfo, "\\t")[0];
            if (operation == "Login" || operation == "Logout" || operation == "Revoked" || operation == "Timeout")
                return true;
            return false;
        }

    }
}