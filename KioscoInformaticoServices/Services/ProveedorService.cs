using KioscoInformaticoServices.Interfaces;
using KioscoInformaticoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KioscoInformaticoServices.Services
{
    public class ProveedorService : GenericService<Proveedor>, IProveedorService
    {
        public async Task<List<Proveedor>?> GetAllAsync(string? Filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?Filtro={Filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Proveedor>>(content, options); ;

        }

    }
}
