using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class YaziManager : GenericManager<Yazi>, IYaziService
    {
        private readonly IYaziDal _yaziDal;
        public YaziManager(IYaziDal yaziDal, IGenericDal<Yazi> genericDal) : base(genericDal)
        {
            _yaziDal = yaziDal;
        }
        public async Task<List<Yazi>> GetBekleyenYazilar()
        {
            return await _yaziDal.GetBekleyenYazilar();
        }

        public async Task<List<Yazi>> GetOnaylananYazilar()
        {
            return await _yaziDal.GetOnaylananYazilar();
        }

        public async Task<List<Yazi>> GetOnaylanMayanYazilar()
        {
            return await _yaziDal.GetOnaylanMayanYazilar();
        }

        public async Task<List<Yazi>> GetSilinenYazilar()
        {
            return await _yaziDal.GetSilinenYazilar();
        }

        public async Task<List<Yazi>> GetYazi()
        {
            return await _yaziDal.GetYazi();
        }

        public async Task<List<Kategori>> GetYaziKategoris(int id)
        {
            return await _yaziDal.GetYaziKategoris(id);
        }

        public async Task<List<AppUser>> GetYaziSahipUsers()
        {
            return await _yaziDal.GetYaziSahipUsers();
        }

        public async Task Onaylama(int id)
        {
            await _yaziDal.Onaylama(id);
        }

        public async Task Onaylar(int id)
        {
            await _yaziDal.Onaylar(id);
        }
    }
}
