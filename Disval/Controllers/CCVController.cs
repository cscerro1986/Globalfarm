using Microsoft.AspNetCore.Mvc;
using Disval.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Disval.Entidades;
using Archivos;
namespace Disval.Controllers
{
    [ApiController]
    [Route("CCV")]
    public class CCVController : Controller
    {
        private IAppDbContext _context;

        public CCVController(IAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dbResponse = await  _context.CCVs.ToArrayAsync();
            if (dbResponse.Length == 0) return BadRequest(dbResponse);

            return Ok(dbResponse);
          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dbResponse = await _context.CCVs.Where(ccv => ccv.ID == id).FirstOrDefaultAsync();
            
            return Ok(dbResponse);

        }

        [HttpPost]
        public async Task <IActionResult>Post(CCV ccv)
        {
            if (ccv == null) return BadRequest();
            _context.CCVs.AddAsync(ccv);
            return Ok(ccv);

        }

        [HttpPost]
        [Route("/upload")]
        public async Task<IActionResult>Post(IFormFile formFile)
        {
            try
            {
                string nombre = formFile.FileName;
                string[] parseo = nombre.Split('.');
                string extencion = parseo[1];

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/ccv");

                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = "CCV." + extencion;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }

                Texto texto = new Texto();
                string datos;
                if (texto.Leer(fileNameWithPath, out datos))
                {
                    string[] sub = datos.Split('\n');
                    foreach (var item in sub)
                    {
                        try
                        {
                            CCV ccv = CCV.DeLineaACCV(item);
                            var retorno = await _context.CCVs.AddAsync(ccv);
                            var retorno2 = await _context.SaveChangesAsync();

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
                return Ok("Archivo cargado correctamente");
            }
            catch (Exception)
            {
                return NotFound("no se pudo");
            }



        }
    }
}
