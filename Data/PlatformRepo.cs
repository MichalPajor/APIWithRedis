using System.Text.Json;
using APIWithRedis.Models;
using StackExchange.Redis;

namespace APIWithRedis.Data{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;
        public PlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
                throw new ArgumentNullException(nameof(platform));
            var db = _redis.GetDatabase(); //get database reference
            //serialize object to string
            var serialPlatform = JsonSerializer.Serialize(platform);
            db.StringSet(platform.Id, serialPlatform); //add object to Redis
        }

        public void DeletePlatform(string id)
        {
            var db = _redis.GetDatabase();
            var platform = db.KeyDelete(id);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redis.GetDatabase();
            var platform = db.StringGet(id);

            if(!string.IsNullOrEmpty(platform)){
                return JsonSerializer.Deserialize<Platform>(platform);
            }
            return null;
        }

        public void UpdatePlatform(Platform platform)
        {
            if(platform == null)
                throw new ArgumentNullException(nameof(platform));
            var db = _redis.GetDatabase(); 
            var serialPlatform = JsonSerializer.Serialize(platform);
            db.StringSet(platform.Id, serialPlatform); 
        }
    }
}