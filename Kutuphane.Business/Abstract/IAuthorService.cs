using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;
using X.PagedList;


namespace Kutuphane.Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetList(string p = "");
        IDataResult<Author> GetById(int id);
        IResult Add(Author author);
        IResult Update(Author author);
        IResult Delete(Author author);
    }
}