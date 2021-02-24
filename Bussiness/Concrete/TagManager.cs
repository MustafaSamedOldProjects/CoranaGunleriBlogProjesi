using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class TagManager : GenericManager<Tag>, ITagService
    {
        private readonly ITagDal _tagDal;
        public TagManager(ITagDal tagDal, IGenericDal<Tag> genericDal) :base (genericDal)
        {
            _tagDal = tagDal;
        }
        public async Task<ICollection<Tag>> GetirTagsByYaziId()
        {
            return await _tagDal.GetirTagsByYaziId();
        }
    }
}
