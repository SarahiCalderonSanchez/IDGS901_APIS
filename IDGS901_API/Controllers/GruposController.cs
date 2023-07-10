using IDGS901_API.Context;
using IDGS901_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_API.Controllers
{
    [Route("api/[controller]")]//ruta depebndiendo el modulo
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly AppDbContext _context;//instancia a la clase para poder usar la tabla
        public GruposController(AppDbContext context)//constructor
        {
            _context = context;
        }
        [HttpGet]//Api/<Grupos>
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Alumnos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name ="Alumnos")]//para pasarle el parametro
        public IActionResult Get(int id)
        {
            try
            {
                var alum=_context.Alumnos.FirstOrDefault(x => x.Id == id);
                return Ok(alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<Alumnos> Post([FromBody]Alumnos alum)
        {
            try
            {
                _context.Alumnos.Add(alum);
                _context.SaveChanges();
                return CreatedAtRoute("Alumnos", new {id=alum.Id});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put (int id, [FromBody]Alumnos alumn)
        {
            try
            {
                if(alumn.Id == id)
                {
                    _context.Entry(alumn).State=EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("Alumnos", new { id = alumn.Id }, alumn);
                } else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var alum = _context.Alumnos.FirstOrDefault(x => x.Id == id);
                if (alum! == null)
                {
                    _context.Remove(alum);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
