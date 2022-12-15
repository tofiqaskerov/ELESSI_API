using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SliderManager>().As<ISliderService>();
            builder.RegisterType<SliderDal>().As<ISliderDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDal>().As<IProductDal>();

            builder.RegisterType<ProductPictureDal>().As<IProductPictureDal>();
            builder.RegisterType<ProductPictureManager>().As<IProductPictureService>();

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<BlogDal>().As<IBlogDal>();

        }
    }
}
