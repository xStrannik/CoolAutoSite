using System.ComponentModel.DataAnnotations;

namespace MvcMovie.DAL.Models
{
    public abstract class Entity
    {
        [Key, Required]
        public int Id { get; set; }
    }
}
