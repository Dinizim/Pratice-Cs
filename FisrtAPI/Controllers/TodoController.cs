using Microsoft.AspNetCore.Mvc;
using FisrtAPI.Models;
using FisrtAPI.Data;
using Microsoft.EntityFrameworkCore;
using FisrtAPI.ViewsModels;

namespace FisrtAPI.Controllers;

[ApiController]
[Route("v1")]
public class TodoController : ControllerBase
{
    //Metodo get
    [HttpGet]
    [Route("todos")]
    public async Task<IActionResult> GetAsync(
        [FromServices] AppDbContext context)
    {
        var todos = await context
            .Todos
            .AsNoTracking()
            .ToListAsync();

        return Ok(todos);
    }

    [HttpGet]
    [Route("todos/{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbContext context,[FromRoute] int id)
    {
        var todo = await context
            .Todos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return todo == null ? NotFound() : Ok(todo);
    }

    [HttpPost("todos")]
    public async Task<IActionResult> PostAsync(
        [FromServices] AppDbContext context, [FromBody] CreateTodoViewModels model )
    {
        // valida os campos do FROMBODY
        if (!ModelState.IsValid)
            return BadRequest();

        var todo = new Todo
        {
            Date = DateTime.Now,
            Done = false,
            Title = model.Title
        };

        try
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();

            return Created("v1/todos/{todo.id}", todo);
        }catch(Exception e)
        {
            return BadRequest();
        }

    }
}
