using System.Collections.Generic;
using LodestoneApi.Internal.Services;
using LodestoneApi.Models;

namespace LodestoneApi
{
    public static class Lodestone
    {
        public static IList<IPlayerInfo> SearchPlayers(string name, string world)
        {
            return SearchService.SearchPlayers(name, world);
        }

        public static IPlayerInfo GetPlayerInfo(string profileUrl)
        {
            return PlayerInfoService.GetPlayerInfo(profileUrl);
        }
    }
}