using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    // GET all action
    [HttpGet(Name = "GetAllPizzas")]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}", Name = "GetPizza")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();

        return pizza;
    }
    // POST action
    [HttpPost(Name = "AddPizza")]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
        
        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        PizzaService.Delete(id);
        return NoContent();
    }
}