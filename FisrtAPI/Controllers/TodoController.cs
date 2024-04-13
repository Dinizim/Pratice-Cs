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
    //Metodo Get -- Buscar por ID
    [HttpGet]
    [Route("todos/{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] AppDbContext context, [FromRoute] int id)
    {
        var todo = await context
            .Todos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return todo == null ? NotFound() : Ok(todo);
    }



    // metodo post ---> Adicionar um dado 
    [HttpPost("todos")]
    public async Task<IActionResult> PostAsync(
        [FromServices] AppDbContext context, [FromBody] CreateTodoViewModels model)
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
            //adicionar e salvar (importante ser await)
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();

            return Created("v1/todos/{todo.id}", todo);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

    }
    [HttpPut("todos/{id}")]
    public async Task<IActionResult> PutAsync(
        [FromServices] AppDbContext context,
        [FromBody] CreateTodoViewModels model,
        [FromRoute] int id)
    {
        // valida os campos do FROMBODY
        if (!ModelState.IsValid)
            return BadRequest();

        var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

        if (todo == null)
            return NotFound();


        try
        {
            //para o metodo PUT(editar) e recomendado ter um viewmodel so para ele
            todo.Title = model.Title;


            //adicionar e salvar (importante ser await)
            context.Todos.Update(todo);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }

    }

    [HttpDelete("todos/{id}")]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] AppDbContext context,
        [FromRoute] int id)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (todo == null)
            return NotFound();
        try
        {
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}
