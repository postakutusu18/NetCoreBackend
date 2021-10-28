using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }


        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfCategoryIsEnabled());

            //if (result != null)
            //{
            //    return result;
            //}
            _productDal.Add(product);
            return new SuccessResult(Messages.SuccessAdded);
        }

        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetList(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.RecordAlreadyExist);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count < 10)
            {
                return new ErrorResult(Messages.RecordAlreadyExist);
            }

            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.SuccessUpdated);
        }

         public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
