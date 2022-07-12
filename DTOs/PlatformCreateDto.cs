using System.ComponentModel.DataAnnotations;
namespace APIWithRedis.DTOs{
    public class PlatformCreateDto{
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}