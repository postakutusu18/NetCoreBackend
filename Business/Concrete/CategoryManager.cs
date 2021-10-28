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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetList().ToList();

            return new SuccessDataResult<List<Category>>(result,Messages.SuccessListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(x => x.CategoryId == id);
            return new SuccessDataResult<Category>(result);
        }

        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
