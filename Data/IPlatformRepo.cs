using APIWithRedis.Models;

namespace APIWithRedis.Data{
    public interface IPlatformRepo{
        void CreatePlatform(Platform platform);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
        void DeletePlatform(string id);
        void UpdatePlatform(Platform platform);
    }
}