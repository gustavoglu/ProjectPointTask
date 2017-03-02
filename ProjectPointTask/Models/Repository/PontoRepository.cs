using ProjectPointTask.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPointTask.Models.Repository
{
    public class PontoRepository : Repository<Ponto>, IPontoRepository
    {
        public PontoRepository()
        {
            
        }
    }
}