using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodestoneApi.Models
{
    internal class PlayerClass : IPlayerClass
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string IconUrl { get; set; }
    }
}
