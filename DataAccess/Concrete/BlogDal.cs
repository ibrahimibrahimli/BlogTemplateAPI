using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal{}
}
