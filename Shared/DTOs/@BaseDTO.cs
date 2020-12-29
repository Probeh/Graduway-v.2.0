using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class @BaseDTO
    {
        public int Id { get; set; }

        [Required, DataType(DataType.Text)]
        public string Title { get; set; }

        [Required, DataType(DataType.Text)]
        public string Description { get; set; }
    }
}