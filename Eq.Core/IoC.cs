﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Eq.Core
{
    /// <summary>
    /// IoC static class to Install, Register, Release and Resolve dependencies
    /// </summary>
    public static class IoC
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        /// <summary>
        /// Install all dependencies from Installer Class
        /// </summary>
        /// <param name="installerClass">IWindsorInstaller installer class</param>
        public static void Install(IWindsorInstaller installerClass)
        {
            Container.Install(installerClass);
        }

        /// <summary>
        /// Resolve type from container
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Requested instance</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Register provided instance as singleton
        /// </summary>
        /// <typeparam name="T">Type to register</typeparam>
        /// <param name="instance">Concret instance to register</param>
        public static void RegisterSingleInstance<T>(T instance) where T : class
        {
            Container.Register(Component.For<T>().Instance(instance).LifestyleSingleton());
        }

        /// <summary>
        /// Release provided instance from container
        /// </summary>
        /// <param name="instance"></param>
        public static void Release(object instance)
        {
            Container.Release(instance);
        }
    }
}
