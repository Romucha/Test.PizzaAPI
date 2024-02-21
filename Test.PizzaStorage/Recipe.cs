using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PizzaStorage
{
    public record Recipe
    {
        public string Name { get; set; }

        public Crust Crust { get; set; }

        public Sauce Sauce { get; set; }

        public Meat Meat { get; set; }

        public Cheese Cheese { get; set; }
    }
}
