using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Data.Interfaces
{
    public interface IYaziService : IGenericService<Yazi>
    {
        Task<List<Yazi>> GetOnaylananYazilar(); //UserGörücek
        Task<List<Yazi>> GetOnaylanMayanYazilar(); //UserGöremeyecekAmaYazarDüzeltebilecek.
        Task<List<Yazi>> GetBekleyenYazilar();// Validator'a düşecek.
        Task<List<Yazi>> GetSilinenYazilar(); //Admin(ler) Görebilecek.
        Task<List<AppUser>> GetYaziSahipUsers();
        Task<List<Yazi>> GetYazi();
    }
}
