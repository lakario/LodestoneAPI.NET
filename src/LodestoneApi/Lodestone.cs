using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using LodestoneApi.Internal.Services;
using LodestoneApi.Models;

namespace LodestoneApi
{
    public static class Lodestone
    {
        public static IList<IPlayerInfo> SearchPlayers(string name, string world)
        {
            return (IList<IPlayerInfo>)SearchService.SearchPlayers(name, world);
        }

        public static IPlayerInfo GetPlayerInfo(string profileUrl)
        {
            return PlayerInfoService.GetPlayerInfo(profileUrl);
        }
    }
}
