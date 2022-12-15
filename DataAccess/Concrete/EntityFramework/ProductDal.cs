using Core.DataAccess.EntityFramework;
using Core.Helpers.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfRepositoryBase<Product, ElessiDbContext>, IProductDal
    {
        public List<ProductDTO> GetAllProduct()
        {
            using var _context = new ElessiDbContext();
            var products = _context.Products.Include(x =>x.ProductPicture).ToList();
            List<ProductDTO> productDTOList = new();
            for(int i = 0; i < products.Count; i++)
            {
                var productPicture = _context.ProductPictures.Where(x => x.ProductId == products[i].Id);

                List<string> pictures = new();
                
                foreach(var product in productPicture)
                {
                    pictures.Add(product.PhotoUrl); ;
                }
                ProductDTO productDTO = new()
                {
                    Id = products[i].Id,
                    Title = products[i].Title,
                    Description = products[i].Description,
                    Price = products[i].Price,
                    Stock = products[i].Stock,
                    Discount = products[i].Discount,
                    Offer = products[i].Offer,
                    CoverPhoto = products[i].CoverPhoto,
                    ProductPictures = pictures

                };
                productDTOList.Add(productDTO);
            }
            return productDTOList;
        }

        public ProductDTO GetById(int id)
        {
            using var _context = new ElessiDbContext();
            var productPicture = _context.ProductPictures.Where(x => x.ProductId == id).ToList();
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            List<string> pictures = new();
            foreach(var picture in productPicture)
            {
                pictures.Add(picture.PhotoUrl);
            }

            ProductDTO productDTO = new()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Discount = product.Discount,
                Offer = product.Offer,
                ProductPictures = pictures,
                CoverPhoto = product.CoverPhoto

            };
            return productDTO;
        }
    }
}
