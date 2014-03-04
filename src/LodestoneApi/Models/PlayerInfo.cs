using System.Collections.Generic;

namespace LodestoneApi.Models
{
    internal class PlayerInfo : HtmlPage, IPlayerInfo
    {
        public PlayerInfo(string url, string html)
            : base(url, html)
        {
            Classes = new List<IPlayerClass>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string World { get; set; }
        public string FreeCompany { get; set; }
        public string GrandCompany { get; set; }
        public string GrandCompanyRank { get; set; }
        public IList<IPlayerClass> Classes { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public string ProfileUrl
        {
            get { return "http://na.finalfantasyxiv.com/lodestone/character/" + Id; }
        }
    }
}