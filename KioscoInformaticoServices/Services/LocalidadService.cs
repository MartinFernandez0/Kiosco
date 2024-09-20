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
    public class LocalidadService : GenericService<Localidad>, ILocalidadService
    {
        public async Task<List<Localidad>?> GetAllAsync(string? filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?filtro={filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Localidad>>(content, options); ;
        }
    }
}
