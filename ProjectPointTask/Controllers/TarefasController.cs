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
    public class TarefasController : ApiController
    {
        private readonly ITarefaAppService _tarefaAppService;
        public TarefasController()
        {
            _tarefaAppService = new TarefaAppService();
        }
        // GET: api/Tarefas
        public IQueryable<TarefaViewModel> GetTarefaViewModels()
        {
            return _tarefaAppService.TrazerTodosAtivos().ToList().AsQueryable();
        }

        // GET: api/Tarefas/5
        [ResponseType(typeof(TarefaViewModel))]
        public IHttpActionResult GetTarefaViewModel(Guid id)
        {
            TarefaViewModel tarefaViewModel = _tarefaAppService.TrazerPorId(id);

            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            return Ok(tarefaViewModel);
        }

        // PUT: api/Tarefas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarefaViewModel(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarefaViewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                _tarefaAppService.Atualizar(tarefaViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaViewModelExists(id))
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

        // POST: api/Tarefas
        [ResponseType(typeof(TarefaViewModel))]
        public IHttpActionResult PostTarefaViewModel(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _tarefaAppService.Criar(tarefaViewModel);
            }
            catch (DbUpdateException)
            {
                if (TarefaViewModelExists(tarefaViewModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tarefaViewModel.Id }, tarefaViewModel);
        }

        // DELETE: api/Tarefas/5
        [ResponseType(typeof(TarefaViewModel))]
        public IHttpActionResult DeleteTarefaViewModel(Guid id)
        {
            TarefaViewModel tarefaViewModel = _tarefaAppService.TrazerPorId(id);
            if (tarefaViewModel == null)
            {
                return NotFound();
            }

            _tarefaAppService.Deletar(tarefaViewModel);

            return Ok(tarefaViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tarefaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarefaViewModelExists(Guid id)
        {
            var db = new ApplicationDbContext();
            return db.Set<Tarefa>().Count(e => e.Id == id) > 0;
        }
    }
}