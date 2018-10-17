using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIAndOAuth.Infrastructure;

namespace WebAPIAndOAuth.Models
{
    public class AppClient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("idx_unique_clientId", IsUnique =true)]
        [MaxLength(40)]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ApplicationTypes ApplicationType { get; set; }
        
        public bool Active { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
    }
}