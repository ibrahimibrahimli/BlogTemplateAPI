using Core.Results.Abstract;
using Entity.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBlogService
    {

        IResult Add( Blog entity, IFormFile imageUrl, string webRootPath);
        IResult Update(Blog entity, IFormFile imageUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Blog>> GetAll();
        IDataResult<Blog> GetById(int id);
    }
}
