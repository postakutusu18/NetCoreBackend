using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
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
        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetList()
        {
           // Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfCategoryIsEnabled());

            //if (result != null)
            //{
            //    return result;
            //}
                _productDal.Add(product);

            return new SuccessResult(Messages.SuccessAdded);

            //ProductValidator validator = new();
            //ValidationResult result = validator.Validate(product);
            //if (result.IsValid)
            //{
            //    _productDal.Add(product);
            //    return new SuccessResult(Messages.SuccessAdded);
            //}
            //else
            //{
            //    string errorMessage = "";
            //    foreach (var failure in result.Errors)
            //        errorMessage += failure.ErrorMessage;
            //   // errorMessage += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
            //    return new ErrorResult(errorMessage);
            //}
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
        [TransactionScopeAspect]

        public IResult TransactionalOperation(Product product)
        {
             _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
