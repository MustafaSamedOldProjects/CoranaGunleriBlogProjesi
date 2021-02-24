using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Data.Interfaces
{
    public interface IKategoriService :IGenericService<Kategori>
    {
        Task<List<Kategori>> GetKategorisHaveYazis();
        Task<List<Kategori>> GetKategorisHaveNoYazis(); 
    }
}
