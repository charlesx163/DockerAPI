using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DockerAPI.Models;
using StackExchange.Redis;

namespace DockerAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;
        public RedisPlatformRepo(IConnectionMultiplexer redis)
        {
            _redis=redis;
        }
        public void CreatePlatform(Platform palt)
        {
            if(palt==null){
                throw new ArgumentOutOfRangeException(nameof(palt));
            }
            var db=_redis.GetDatabase();
            var serialPlat=JsonSerializer.Serialize(palt);
            db.StringSet(palt.Id,serialPlat);
            db.SetAdd("PlatformSet",serialPlat);
        }

        public IEnumerable<Platform>? GetAllPlatforms()
        {
            var db=_redis.GetDatabase();
            var completeSet = db.SetMembers("PlatformSet");
            if(completeSet.Length>0){
                var list = Array.ConvertAll(completeSet, val=> JsonSerializer.Deserialize<Platform>(val)).ToList();
                return list!;
            }
            return default;
        }

        public Platform? GetPlatformById(string id)
        {
            var db=_redis.GetDatabase();
            var plat=db.StringGet(id);
            if(!string.IsNullOrWhiteSpace(plat))
            {
                return JsonSerializer.Deserialize<Platform>(plat);
            }
            return default;
        }
    }
}