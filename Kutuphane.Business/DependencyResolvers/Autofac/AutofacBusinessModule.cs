using Autofac;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Security.Jwt;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework;

namespace Kutuphane.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();
            builder.RegisterType<MemberManager>().As<IMemberService>().SingleInstance();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>().SingleInstance();
            builder.RegisterType<PersonalManager>().As<IPersonalService>().SingleInstance();
            builder.RegisterType<EfPersonalDal>().As<IPersonalDal>().SingleInstance();
            builder.RegisterType<StatisticManager>().As<IStatisticService>().SingleInstance();
            builder.RegisterType<EfStatisticDal>().As<IStatisticDal>().SingleInstance();
            builder.RegisterType<OperationManager>().As<IOperationService>().SingleInstance();
            builder.RegisterType<EfOperationDal>().As<IOperationDal>().SingleInstance();
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();
            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}