using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerAPI.Models;

namespace DockerAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform palt);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform>? GetAllPlatforms();
    }
}