using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Zad4.Models
{
    public class StorageList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [DataType(DataType.Date)] 
        public DateTime ValidToDate { get; set; }
        public decimal Weight { get; set; }
        public string LockerName { get; set; }

    }
}
