using System.ComponentModel.DataAnnotations;

namespace Dapperpractise.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string Dept { get; set; }=null!;

    }
}
