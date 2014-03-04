using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;
using LodestoneApi.Internal.Utils;
using LodestoneApi.Models;

namespace LodestoneApi.Internal.Services
{
    internal class SearchService
    {
        internal static IList<IPlayerInfo> SearchPlayers(string name, string world)
        {
            const string search_url_template =
                "http://na.finalfantasyxiv.com/lodestone/character/?q={0}&worldname={1}&classjob=&race_tribe=&order=";

            var matches = new List<IPlayerInfo>();
            var url = String.Format(search_url_template, HttpUtility.UrlEncode(name), HttpUtility.UrlEncode(world));
            var html = HttpUtilities.GetUrl(url);

            if (html.Contains("Your search yielded no results."))
            {
                return null;
            }

            CQ dom = html;
            var resultElements = dom.Find(".player_name_area");

            foreach (IDomElement result in resultElements)
            {
                PlayerInfo match = ParseSearchResult(result);

                if (match != null)
                {
                    matches.Add(match);
                }
            }

            return matches;
        }

        private static PlayerInfo ParseSearchResult(IDomElement result)
        {
            var cqResult = result.Cq();
            var aTag = cqResult.Find("a");

            var profileUrl = aTag.Attr("href");
            var characterName = aTag.Text().CleanUp();
            var worldName = Regex.Replace(aTag.Next("span").Text().CleanUp(), @"\(|\)", "");
            var match = Regex.Match(profileUrl, "/lodestone/character/(?<profileId>[0-9]+)/");

            if (match.Success)
            {
                return new PlayerInfo(null, null)
                {
                    Name = characterName,
                    World = worldName,
                    Id = match.Groups["profileId"].Captures[0].Value
                };
            }
            return null;
        }
    }
}