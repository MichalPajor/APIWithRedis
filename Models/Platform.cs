using System.ComponentModel.DataAnnotations;

namespace APIWithRedis.Models{
    public class Platform{
        [Required]
        public string Id { get; set; }= $"platform:{Guid.NewGuid().ToString()}";
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}