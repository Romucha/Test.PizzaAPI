using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.PizzaStorage
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Crust Crust { get; set; }

        public Sauce Sauce { get; set; }

        public Meat Meat { get; set; }

        public Cheese Cheese { get; set; }
    }
}
