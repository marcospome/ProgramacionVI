using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // POST api/<FoodController>
        [HttpPost]
        public List<Food> Post(Food food)
        {
            List<Food> lista = new List<Food>();
            for (int i = 0; i < 10; i++)
            {
                lista.Add(food);
                food.FoodPrice = food.FoodPrice + (food.FoodPrice * 0.50);
            }
            return lista;
        }

    }
}
