using System.ComponentModel.DataAnnotations;

namespace lab2and3.Models.DomainModel
{
    public record User
    {
        [Key]
        [MaxLength(50)]
        public string UserId { get; init;}
    }
}