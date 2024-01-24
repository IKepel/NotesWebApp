using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class Note
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter value")]
        public string Value { get; set; }

        [Required(ErrorMessage = "Please enter priority")]
        [Range(0, 10, ErrorMessage = "Priority must be beetween 0 and 10 only!!")]
        public int Priority { get; set; }
    }
}
