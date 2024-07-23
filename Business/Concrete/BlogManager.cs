using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        private readonly IValidator<Blog> _validator;

        public BlogManager(IBlogDal testimonialDal, IValidator<Blog> validator)
        {
            _blogDal = testimonialDal;
            _validator = validator;
        }
        public IResult Add(Blog entity, IFormFile imageUrl, string webRootPath)
        {
            var validator = _validator.Validate(entity);
            entity.PhotoUrl = PictureHelper.UploadImage(imageUrl, webRootPath);


            string errorMessage = "";
            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _blogDal.Add(entity);

            return new SuccessResult(UIMessages.SUCCESS_ADDED_MESSAGE);
        }

        public IResult Update(Blog entity, IFormFile imageUrl, string webRootPath)
        {

            var existData = GetById(entity.Id).Data;
            if (imageUrl == null)
            {
                entity.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                entity.PhotoUrl = PictureHelper.UploadImage(imageUrl, webRootPath);
            }

            entity.UpdatedDate = DateTime.Now;
            _blogDal.Update(entity);

            return new SuccessResult(UIMessages.SUCCESS_UPDATED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            _blogDal.Update(data);

            return new SuccessResult(UIMessages.SUCCESS_DELETED_MESSAGE);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.GetById(id));
        }
    }
}
