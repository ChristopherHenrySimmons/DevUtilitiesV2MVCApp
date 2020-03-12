using System;
using System.Collections.Generic;

namespace DevUtilitiesV2MVCApp.Models
{
    public partial class Commands
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Command { get; set; }
        public string ConsoleType { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
