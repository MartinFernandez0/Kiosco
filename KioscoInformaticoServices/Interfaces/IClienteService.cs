using KioscoInformaticoServices.Models;
using KioscoInformaticoServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KioscoInformaticoServices.Interfaces
{
    public interface IClienteService : IGenericService<Cliente>
    {
        public Task<List<Cliente>?> GetAllAsync(string? filtro);
    }
}
