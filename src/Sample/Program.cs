using LodestoneApi;
using System;
using System.Linq;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = Lodestone.SearchPlayers("John", null);

            foreach (var playerInfo in players)
            {
                Console.WriteLine("{0} ({1}) - {2}", playerInfo.Name, playerInfo.World, playerInfo.ProfileUrl);
            }

            if (players.Any())
            {
                Console.WriteLine("\n\n-------------------------\n");

                var firstPlayer = players.First();
                var playerInfo = Lodestone.GetPlayerInfo(firstPlayer.ProfileUrl);

                Console.WriteLine("Name: {0} ({1})", playerInfo.Name, playerInfo.World);

                Console.WriteLine("Classes:");
                foreach (var @class in playerInfo.Classes)
                {
                    Console.WriteLine("  - {0} {1}", @class.Level, @class.Name);
                }
            }

            Console.ReadLine();
        }
    }
}
