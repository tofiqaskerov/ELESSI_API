using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(BlogDTO blogDTO);
        IDataResult<Blog> GetById(int id);
        IDataResult<List<Blog>> GetAll();
        IResult Update(int id, BlogDTO blogDTO);
        IResult Delete(int id);
    }
}
