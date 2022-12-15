using Business.Abstract;
using Business.Constants;
using Business.Constants.Product;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductPictureService _productPictureService;

        public ProductManager(IProductDal productDal, IProductPictureService productPictureService)
        {
            _productDal = productDal;
            _productPictureService = productPictureService;
        }

        public IResult Add(AddProductDTO productDTO)
        {
			try
			{
                Product product = new()
                {
                    Title = productDTO.Title,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    Discount = productDTO.Discount,
                    Offer = productDTO.Offer,
                    CoverPhoto = productDTO.CoverPhoto
                };
                _productDal.Add(product);
                for(int i = 0; i < productDTO.ProductPictures.Count; i++)
                {
                    productDTO.ProductPictures[i].ProductId = product.Id;
                    _productPictureService.Add(productDTO.ProductPictures[i]);
                }
                return new SuccessResult(ProductMessage.ProductAdded);
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
                var selectedProduct = _productDal.Get(x => x.Id == id);
                _productDal.Delete(selectedProduct);
                return new SuccessResult(ProductMessage.ProductIsDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IDataResult<List<ProductDTO>> GetAll()
        {
            try
            {
                var products = _productDal.GetAllProduct();
                return new SuccessDataResult<List<ProductDTO>>(products, ProductMessage.ProductsIsFound);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<ProductDTO>>(e.Message);
            }
        }

        public IDataResult<ProductDTO> GetById(int id)
        {
            try
            {
                var selectedProduct = _productDal.GetById(id);
                return new SuccessDataResult<ProductDTO>( selectedProduct, ProductMessage.ProductIsFound);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<ProductDTO>(e.Message);
            }
        }

        public IResult Update(int id, AddProductDTO productDTO)
        {
            try
            {
                var selectedProduct = _productDal.Get(x => x.Id == id);
                selectedProduct.Title = productDTO.Title;
                selectedProduct.Description = productDTO.Description;
                selectedProduct.Price = productDTO.Price;
                selectedProduct.Stock = productDTO.Stock;
                selectedProduct.Discount = productDTO.Discount;
                selectedProduct.Offer = productDTO.Offer;
                selectedProduct.CoverPhoto = productDTO.CoverPhoto;
                _productDal.Update(selectedProduct);
                return new SuccessResult(ProductMessage.ProductIsUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
