using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodestoneApi.Models
{
    internal class PlayerInfo : HtmlPage, IPlayerInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string World { get; set; }
        public string FreeCompany { get; set; }
        public IList<IPlayerClass> Classes { get; set; }

        public string ProfileUrl
        {
            get { return "http://na.finalfantasyxiv.com/lodestone/character/" + Id; }
        }

        public PlayerInfo(string url, string html)
            : base(url, html)
        {
            Classes = new List<IPlayerClass>();
        }
    }
}
