using Autofac;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework;

namespace Kutuphane.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<AuthorManager>().As<IAuthorService>();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>();
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfBookDal>().As<IBookDal>();
            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();
            builder.RegisterType<PersonalManager>().As<IPersonalService>();
            builder.RegisterType<EfPersonalDal>().As<IPersonalDal>();
        }
    }
}