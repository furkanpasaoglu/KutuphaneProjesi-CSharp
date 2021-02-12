using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList(string p = "");
        IDataResult<Category> GetById(int id);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}