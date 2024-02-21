using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.PizzaStorage
{
    public interface IPizzaFactory
    {
        Pizza CreateDefault();

        Pizza CreateFromRecipe(Recipe recipe);

        Pizza CreateRandom();
    }
}
