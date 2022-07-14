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

            db.HashSet("PlatformsHash",new HashEntry[]{
                new HashEntry(platform.Id,serialPlatform)
            });

           // db.StringSet(platform.Id, serialPlatform); //add object to Redis
           // db.SetAdd("PlatformSet",serialPlatform); //add object to Set
        }

        public void DeletePlatform(string id)
        {
            var db = _redis.GetDatabase();
            var platform = db.KeyDelete(id);
        }

        public IEnumerable<Platform?>? GetAllPlatforms()
        {
            var db = _redis.GetDatabase();
            var completeSet = db.HashGetAll("PlatformsHash");
            //var completeSet = db.SetMembers("PlatformSet");
            if(completeSet != null){
                return Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<Platform>(val.Value)).ToList();//val if set
            }
            return null;
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redis.GetDatabase();

            var platform = db.HashGet("PlatformsHash",id);
            //var platform = db.StringGet(id);

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