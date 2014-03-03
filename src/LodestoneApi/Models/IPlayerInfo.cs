using System.Collections.Generic;

namespace LodestoneApi.Models
{
    public interface IPlayerInfo
    {
        string Id { get; }
        string Name { get; }
        string World { get; }
        string FreeCompany { get; }
        IList<IPlayerClass> Classes { get; }
        string ProfileUrl { get; }
    }
}