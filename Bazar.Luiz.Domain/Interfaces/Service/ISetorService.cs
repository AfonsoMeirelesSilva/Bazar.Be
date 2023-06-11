using Bazar.Luiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bazar.Luiz.Domain.Interfaces.Service
{
    public interface ISetorService
    {
        Task<IEnumerable<Setor>> GetAllAsync();
    }
    
}
