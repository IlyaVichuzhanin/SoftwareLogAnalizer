using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class tNavPrimaryLog
    {
        public tNavPrimaryLog(
            long? tNavLogID, 
            int? operationType, 
            string feature, 
            DateTime operationDateTime,
            string computerUserName,
            string windowsUserName,
            int? returnedId)
        {
            TNavLogID=tNavLogID;
            OperationType=operationType;
            Feature=feature;
            OperationDateTime=operationDateTime;
            ComputerUserName=computerUserName;
            WindowsUserName=windowsUserName;
            ReturnedId=returnedId;
        }
        [Key]
        public long? Id { get; set; }
        public long? TNavLogID { get; set; }
        public int? OperationType { get; set; }
        public string Feature { get; set; }
        public DateTime OperationDateTime { get; set; }
        public string ComputerUserName { get; set; }
        public string WindowsUserName { get; set; }
        public int? ReturnedId { get; set; }
        public bool? IsLog { get; set; }
        public bool? LogIsStructurated { get; set; }
        public bool? ChechLog(Tuple<int, int, string, DateTime, string, string, int> logInfo)
        {
            return (logInfo.Item2 != -1);
        }
    }
}