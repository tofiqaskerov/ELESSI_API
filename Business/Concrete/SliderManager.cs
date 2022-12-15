using Business.Abstract;
using Business.Constants;
using Business.Constants.Slider;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public IResult Add(SliderDTO sliderDTO)
        {
            try
            {
                Slider slider = new()
                {
                    PhotoUrl = sliderDTO.PhotoUrl,
                    Title = sliderDTO.Title,
                    Subtitle = sliderDTO.Subtitle,

                };
                _sliderDal.Add(slider);
                return new SuccessResult(SliderMessage.SliderAdded);
            }
            catch(Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var selectedProduct = _sliderDal.Get(x => x.Id == id);
                _sliderDal.Delete(selectedProduct);
                return new SuccessResult(SliderMessage.SliderIsDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IDataResult<List<Slider>> GetAll()
        {
            try
            {
                var products = _sliderDal.GetAll();
                return new SuccessDataResult<List<Slider>>(products, SliderMessage.SlidersIsFound);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Slider>>(e.Message);
            }
        }

        public IDataResult<Slider> GetById(int id)
        {
            try
            {
                var product = _sliderDal.Get(x => x.Id == id);
                return new SuccessDataResult<Slider>(product, SliderMessage.SliderIsFound);
            }
            catch(Exception e)
            {
                return new ErrorDataResult<Slider>(e.Message);
            }
        }

        public IResult Update(int id, SliderDTO sliderDTO)
        {
            try
            {
                var selectedProduct = _sliderDal.Get(x => x.Id == id);
                selectedProduct.PhotoUrl = sliderDTO.PhotoUrl;
                selectedProduct.Title = sliderDTO.Title;
                selectedProduct.Subtitle = sliderDTO.Subtitle;
                _sliderDal.Update(selectedProduct);
                return new SuccessResult(SliderMessage.SliderIsUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
          
        }
    }
}
