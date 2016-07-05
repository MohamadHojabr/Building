using DomainClasses.Models;
using DataLayer.Context;
using ServiceLayer.EfService;
using ServiceLayer.IService;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Building.Web.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Building.Web.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace Building.Web.Mvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind<IAddress>().To<EfAddress>().InRequestScope();
            kernel.Bind<IArticle>().To<EfArticle>().InRequestScope();
            kernel.Bind<IBrand>().To<EfBrand>().InRequestScope();
            kernel.Bind<ICity>().To<EfCity>().InRequestScope();
            kernel.Bind<ICompanyProfile>().To<EfCompanyProfile>().InRequestScope();
            kernel.Bind<IContact>().To<EfContact>().InRequestScope();
            kernel.Bind<IImageGallery>().To<EfImageGallery>().InRequestScope();
            kernel.Bind<IMainCategory>().To<EfMainCategory>().InRequestScope();
            kernel.Bind<IPersonalProfile>().To<EfPersonalProfile>().InRequestScope();
            kernel.Bind<IPortfolio>().To<EfPortfolio>().InRequestScope();
            kernel.Bind<IProduct>().To<EfProduct>().InRequestScope();
            kernel.Bind<IProject>().To<EfProject>().InRequestScope();
            kernel.Bind<IState>().To<EfState>().InRequestScope();
            kernel.Bind<IUseLocation>().To<EfUseLocation>().InRequestScope();
            kernel.Bind<IVideoGallery>().To<EfVideoGallery>().InRequestScope();
            kernel.Bind<IUsersManager>().To<EfUsersManager>().InRequestScope();
        }
    }
}
