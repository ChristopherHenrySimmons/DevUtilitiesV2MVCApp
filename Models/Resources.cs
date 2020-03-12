using System;
using System.Collections.Generic;

namespace DevUtilitiesV2MVCApp.Models
{
    public partial class Resources
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Langues { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
