using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PizzaStorage
{
    public class PizzaFactory : IPizzaFactory
    {
        public Pizza CreateDefault()
        {
            return new Pizza();
        }

        public Pizza CreateFromRecipe(Recipe recipe)
        {
            return new Pizza()
            {
                Name = recipe.Name,
                Cheese = recipe.Cheese,
                Crust = recipe.Crust,
                Meat = recipe.Meat,
                Sauce = recipe.Sauce,
            };
        }

        public Pizza CreateRandom()
        {
            Random rand = new Random();
            return new Pizza()
            {
                Name = "Surprise Pizza",
                Cheese = (Cheese)rand.Next((int)Cheese.None, (int)Cheese.Hard),
                Crust = (Crust)rand.Next((int)Crust.Thin, (int)Crust.Thick),
                Meat = (Meat)rand.Next((int)Meat.None, (int)Meat.Fish),
                Sauce = (Sauce)rand.Next((int)Sauce.None, (int)Sauce.Mayonnaise)
            };
        }
    }
}
