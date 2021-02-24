using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class YorumMamager : GenericManager<Yorum>, IYorumService
    {
        private readonly IYorumDal _yorumDal;

        public YorumMamager(IYorumDal yorumDal, IGenericDal<Yorum> genericDal) : base(genericDal)
        {
            _yorumDal = yorumDal;
        }
        public async Task<ICollection<Yorum>> GetirYorumsByYaziId(int id)
        {
            return await _yorumDal.GetirYorumsByYaziId(id);
        }
    }
}
