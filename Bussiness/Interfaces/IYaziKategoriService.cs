using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Bussiness.Interfaces
{
    public interface IYaziKategoriService : IGenericService<YaziKategori>
    {
        Task<List<YaziKategori>> GetYaziKategoris(List<int> kategoriler);
    }
}
