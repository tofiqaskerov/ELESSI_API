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
    public interface IProductService
    {
        IResult Add(AddProductDTO productDTO);
        IDataResult<ProductDTO> GetById(int id);
        IDataResult<List<ProductDTO>> GetAll();
        IResult Update(int id, AddProductDTO productDTO);
        IResult Delete(int id);
    }
}
