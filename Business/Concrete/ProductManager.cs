using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result, Messages.SuccessListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(x => x.ProductId == id);
            return new SuccessDataResult<Product>(result);
        }

        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
