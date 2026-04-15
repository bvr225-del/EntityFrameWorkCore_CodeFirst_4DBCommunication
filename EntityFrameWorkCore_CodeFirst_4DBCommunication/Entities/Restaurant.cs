using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public string CreationDate { get; set; }

    }
}
