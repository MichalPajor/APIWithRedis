using System.ComponentModel.DataAnnotations;
namespace APIWithRedis.DTOs{
    public class PlatformUpdateDto{
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}