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
    public interface ISliderService
    {
        IResult Add(SliderDTO sliderDTO);
        IDataResult<Slider> GetById(int id);
        IDataResult<List<Slider>> GetAll();
        IResult Update(int id, SliderDTO sliderDTO);
        IResult Delete(int id);
    }
}
