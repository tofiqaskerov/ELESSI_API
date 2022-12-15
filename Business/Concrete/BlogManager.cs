using Business.Abstract;
using Business.Constants.Blog;
using Business.Constants.Slider;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(BlogDTO blogDTO)
        {
            try
            {
                Blog blog = new()
                {
                    PhotoUrl = blogDTO.PhotoUrl,
                    Title = blogDTO.Title,
                    Description = blogDTO.Description,
                };
                _blogDal.Add(blog);
                return new SuccessResult(BlogMessage.BlogAdded);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var blog = _blogDal.Get(x => x.Id == id);
                _blogDal.Delete(blog);
                return new SuccessResult(BlogMessage.BlogIsDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IDataResult<List<Blog>> GetAll()
        {
            try
            {
                var blogs = _blogDal.GetAll();
                return new SuccessDataResult<List<Blog>>(blogs, BlogMessage.BlogsIsFound);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Blog>>(e.Message);
            }
        }

        public IDataResult<Blog> GetById(int id)
        {
            try
            {
                var blog = _blogDal.Get(x => x.Id == id);
                return new SuccessDataResult<Blog>(blog, BlogMessage.BlogIsFound);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Blog>(e.Message);
            }
        }

        public IResult Update(int id, BlogDTO blogDTO)
        {
            try
            {
                var selectedBlog = _blogDal.Get(x => x.Id == id);
                selectedBlog.Title = blogDTO.Title;
                selectedBlog.Description = blogDTO.Description;
                selectedBlog.PhotoUrl = blogDTO.PhotoUrl;
                _blogDal.Update(selectedBlog);
                return new SuccessResult(BlogMessage.BlogIsUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
