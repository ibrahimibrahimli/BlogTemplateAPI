using Core.DataAccess.Abstract;
using Entity.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IBaseRepository<Blog> { }
}
