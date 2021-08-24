using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DianaGamezWebApp.Models
{
    public class Usuario
    {
        public string EXp { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}