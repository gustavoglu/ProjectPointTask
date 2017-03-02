using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectPointTask.Models;
using ProjectPointTask.ViewModels;
using ProjectPointTask.Application.interfaces;
using ProjectPointTask.Application.Services;

namespace ProjectPointTask.Controllers
{
    public class PontosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IPontoAppService _pontoAppService;
        public PontosController()
        {
            _pontoAppService = new PontoAppService();
        }
        // GET: api/Pontos
        public IQueryable<PontoViewModel> GetPontoViewModels()
        {
            return _pontoAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Pontos/5
        [ResponseType(typeof(PontoViewModel))]
        public IHttpActionResult GetPontoViewModel(Guid id)
        {
            PontoViewModel pontoViewModel = _pontoAppService.TrazerPorId(id);
            if (pontoViewModel == null)
            {
                return NotFound();
            }

            return Ok(pontoViewModel);
        }

        // PUT: api/Pontos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPontoViewModel(Guid id, PontoViewModel pontoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pontoViewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                _pontoAppService.Atualizar(pontoViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontoViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pontos
        [ResponseType(typeof(PontoViewModel))]
        public IHttpActionResult PostPontoViewModel(PontoViewModel pontoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _pontoAppService.Criar(pontoViewModel);
            }
            catch (DbUpdateException)
            {
                if (PontoViewModelExists(pontoViewModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pontoViewModel.Id }, pontoViewModel);
        }

        // DELETE: api/Pontos/5
        [ResponseType(typeof(PontoViewModel))]
        public IHttpActionResult DeletePontoViewModel(Guid id)
        {
            PontoViewModel pontoViewModel = _pontoAppService.TrazerPorId(id);
            if (pontoViewModel == null)
            {
                return NotFound();
            }

            _pontoAppService.Deletar(pontoViewModel);

            return Ok(pontoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pontoAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PontoViewModelExists(Guid id)
        {
            return db.Set<Ponto>().Count(e => e.Id == id) > 0;
        }
    }
}