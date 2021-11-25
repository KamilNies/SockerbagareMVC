using System.ComponentModel.DataAnnotations;

namespace Sockerbagare2.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string ProviderName { get; set; }
    }
}