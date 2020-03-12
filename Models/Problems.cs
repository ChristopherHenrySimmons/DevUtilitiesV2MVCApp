using System;
using System.Collections.Generic;

namespace DevUtilitiesV2MVCApp.Models
{
    public partial class Problems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Solution { get; set; }
        public string SolutionLink { get; set; }
        public string Details { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
