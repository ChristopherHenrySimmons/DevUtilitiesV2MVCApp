using System;
using System.Collections.Generic;

namespace DevUtilitiesV2MVCApp.Models
{
    public partial class CodeBlocks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Block { get; set; }
        public string Langue { get; set; }
        public string Function { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
