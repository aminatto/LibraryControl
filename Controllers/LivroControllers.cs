using Library.Data;
using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosControllers : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var livros = await context.Livros.AsNoTracking().ToListAsync();

            return Ok(livros);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            return livro == null ? NotFound() : Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateLivroViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var novoLivro = new Livro()
            {
                Title = model.Title,
                Author = model.Author
            };

            try
            {
                await context.Livros.AddAsync(novoLivro);
                await context.SaveChangesAsync();
                return Created($"v1/livros{novoLivro.Id}", novoLivro);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateLivroViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (livro == null)
                return NotFound();

            try
            {
                livro.Title = model.Title;

                context.Livros.Update(livro);
                await context.SaveChangesAsync();

                return Ok(livro);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var livro = await context.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (livro == null)
                return NotFound();

            try
            {
                context.Livros.Remove(livro);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
