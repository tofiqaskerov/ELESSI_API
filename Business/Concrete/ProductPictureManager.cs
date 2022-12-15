using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductPictureManager : IProductPictureService
    {
        private readonly IProductPictureDal _productPictureDal;

        public ProductPictureManager(IProductPictureDal productPictureDal)
        {
            _productPictureDal = productPictureDal;
        }

        public void Add(ProductPictureDTO productPictureDTO)
        {
            ProductPicture productPicture = new()
            {
                ProductId = productPictureDTO.ProductId,
                PhotoUrl = productPictureDTO.PhotoUrl
            };
            _productPictureDal.Add(productPicture);
            
        }
    }
}
