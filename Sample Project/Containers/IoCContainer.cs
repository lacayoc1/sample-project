using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Sample_Project.Containers
{
    public static class IocContainer
    {
        private static IWindsorContainer _container;

        public static void Setup()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));
        }
    }

    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer container;

        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(() => this.container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            { this.release = release; }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}