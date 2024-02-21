using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.PizzaStorage;

namespace Test.PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaFactory pizzaFactory;

        private readonly ILogger<PizzaController> logger;

        private readonly PizzaDbContext pizzaDbContext;

        public PizzaController(IPizzaFactory pizzaFactory, ILogger<PizzaController> logger, PizzaDbContext pizzaDbContext)
        {
            this.pizzaFactory = pizzaFactory;
            this.logger = logger;
            this.pizzaDbContext = pizzaDbContext;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(pizzaDbContext.Pizzas);
            }
            catch (Exception ex) 
            {
                logger.LogError(ex, nameof(GetAll));
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) 
        {
            try
            {
                return Ok(await pizzaDbContext.Pizzas.FindAsync(id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(Get));
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Recipe recipe)
        {
            try
            {
                var pizza = pizzaFactory.CreateFromRecipe(recipe);
                pizzaDbContext.Pizzas.Add(pizza);
                await pizzaDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(Post));
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/default")]
        public IActionResult Default()
        {
            try
            {
                return Ok(pizzaFactory.CreateDefault());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(Default));
                return this.NotFound(ex.Message);
            }
        }

        [HttpGet("/random")]
        public IActionResult Random()
        {
            try
            {
                return Ok(pizzaFactory.CreateRandom());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, nameof(Random));
                return NotFound(ex.Message);
            }
        }
    }
}
