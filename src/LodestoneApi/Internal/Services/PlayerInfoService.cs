using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;
using LodestoneApi.Internal.Utils;
using LodestoneApi.Models;

namespace LodestoneApi.Internal.Services
{
    internal static class PlayerInfoService
    {
        internal static PlayerInfo GetPlayerInfo(string profileUrl)
        {
            var html = HttpUtilities.GetUrl(profileUrl);
            var playerInfo = new PlayerInfo(profileUrl, html);
            CQ dom = html;

            var nameDiv = dom.Find(".player_name_txt");
            var nameA = nameDiv.Find("> h2 > a");

            playerInfo.Name = nameA.Text().CleanUp();
            playerInfo.World = Regex.Replace(nameA.Next("span").Text().CleanUp(), @"\(|\)", "");

            var classTds = dom.Find(".class_list .ic_class_wh24_box").Has("img");

            foreach (IDomElement classTd in classTds)
            {
                var cqClassTd = classTd.Cq();
                var imgUrl = cqClassTd.Find("img").Attr("src");
                var className = cqClassTd.Text().CleanUp();
                var level = cqClassTd.Next("td").Text().CleanUp();

                int intLvl = 0;
                int.TryParse(level, out intLvl);

                playerInfo.Classes.Add(new PlayerClass()
                {
                    IconUrl = imgUrl,
                    Name = className,
                    Level = intLvl
                });
            }

            return playerInfo;
        }
    }
}
