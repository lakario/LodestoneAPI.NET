using System;
using System.Text.RegularExpressions;
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
            var nameA = dom.Find(".player_name_txt > h2 > a");
            var charHeaderDiv = dom.Find(".chara_profile_list");
            var freeCompanyA = charHeaderDiv.Find("li").Filter(e => e.Cq().Text().Contains("Free Company")).Find("strong > a");
            var grandCompanyStrong = charHeaderDiv.Find("li").Filter(e => e.Cq().Text().Contains("Grand Company")).Find("strong");
            var thumbnailImg = dom.Find(".player_name_thumb img");
            var playerImg = dom.Find("#chara_img_area .img_area img");
            var classTds = dom.Find(".class_list .ic_class_wh24_box").Has("img");
            var match = Regex.Match(nameA.Attr("href").Trim(), "/lodestone/character/(?<profileId>[0-9]+)/");

            foreach (IDomElement classTd in classTds)
            {
                var cqClassTd = classTd.Cq();
                var imgUrl = cqClassTd.Find("img").Attr("src");
                var className = cqClassTd.Text().CleanUp();
                var level = cqClassTd.Next("td").Text().CleanUp();
                int intLvl = 0;
                int.TryParse(level, out intLvl);

                playerInfo.Classes.Add(new PlayerClass
                {
                    IconUrl = imgUrl,
                    Name = className,
                    Level = intLvl
                });
            }

            playerInfo.Id = match.Success ? match.Groups["profileId"].Captures[0].Value.Trim() : null;
            playerInfo.Name = nameA.Text().CleanUp();
            playerInfo.World = Regex.Replace(nameA.Next("span").Text().CleanUp(), @"\(|\)", "");
            playerInfo.FreeCompany = freeCompanyA.Text().CleanUp();
            playerInfo.GrandCompany =
                (!String.IsNullOrWhiteSpace(grandCompanyStrong.Text())
                    ? grandCompanyStrong.Text().Substring(0, grandCompanyStrong.Text().IndexOf('/'))
                    : null).CleanUp();
            playerInfo.GrandCompanyRank =
                (!String.IsNullOrWhiteSpace(grandCompanyStrong.Text())
                    ? grandCompanyStrong.Text().Substring(grandCompanyStrong.Text().IndexOf('/') + 1)
                    : null).CleanUp();
            playerInfo.ThumbnailUrl = thumbnailImg.Attr("src").CleanUp();
            playerInfo.ImageUrl = playerImg.Attr("src").CleanUp();

            return playerInfo;
        }
    }
}