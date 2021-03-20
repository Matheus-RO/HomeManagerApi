using HomeManagerApi.Data;
using HomeManagerApi.Data.Models;
using HomeManagerApi.Extensions;
using HomeManagerApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        // GET: api/<ComprasController>
        [HttpGet]
        public IActionResult Get()
        {
            var db = new ApplicationContext();

            List<Compra> compras = null;
            try
            {
                
                compras = db.Compras
                    .OrderBy(p => p.IncluidoDataHora)
                    .ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return new JsonResult(compras);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            // TODO - injetar o context para não haver necessidade
            var db = new ApplicationContext();
            JsonResult result = null;

            try
            {
                var compra = db.Compras
                    .Where(c => c.Id == id);

                result = new JsonResult(compra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return result;
        }

        // POST api/<ComprasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompraRequest comprasRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var db = new ApplicationContext();

            // TODO ver https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
            // Aprender a usar a injeção de deéndências e o AutoMapper para melhorar o código no geral

            Compra compra = new Compra();
            compra.Nome = comprasRequest.Nome;
            compra.Concluido = comprasRequest.Concluido;
            compra.Observacao = comprasRequest.Observacao;

            try
            {
                // testar o add com a cópia de valores
                //db.Entry(compra).CurrentValues.SetValues(comprasRequest);

                await db.Compras.AddAsync(compra);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            // TODO - criar um objeto de resposta
            return Ok("Objeto criado");

        }

        // PUT api/<ComprasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CompraRequest compraRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var db = new ApplicationContext();

            // TODO ver https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
            // Aprender a usar a injeção de deéndências e o AutoMapper para melhorar o código no geral

            Compra compra = db.Compras.Find(id);
            //compra.Nome = compraRequest.Nome;
            //compra.Concluido = compraRequest.Concluido;
            //compra.Observacao = compraRequest.Observacao;

            try
            {
                //db.Compras.Update(compra);

                db.Attach(compra);
                db.Entry(compra).CurrentValues.SetValues(compraRequest);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            // TODO - criar um objeto de resposta
            return Ok("Objeto atualizado");
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                var db = new Data.ApplicationContext();

                var compra = db.Compras.Find(id);
                db.Entry(compra).State = EntityState.Deleted;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                StatusCode(500, ex.Message);
            }

            Ok();
        }
    }
}
