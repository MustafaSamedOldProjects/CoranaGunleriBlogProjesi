using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Concrete.EfCore.Context;
using Entities.Concrete;

namespace Data.Interfaces
{
    public interface IYaziKategoriDal : IGenericDal<YaziKategori>
    {
        Task<List<YaziKategori>> GetYaziKategoris(int[] kategoriler);
        
    }
}
