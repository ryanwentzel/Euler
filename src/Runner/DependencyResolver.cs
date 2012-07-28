using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Ryan.ProjectEuler.Runner
{
    /// <summary>
    /// Adapted from CodeCampServer
    /// http://codecampserver.codeplex.com/
    /// </summary>
    public class DependencyResolver
    {
        private static bool areDependenciesRegistered;
        private static readonly object syncObject = new object();

        public void RegisterDependencies()
        {
            ObjectFactory.Container.Configure(x =>
            {
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.LookForRegistries();
                });
            });
        }

        public static T Resolve<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return ObjectFactory.GetAllInstances<T>().AsEnumerable();
        }

        public static object Resolve(Type type)
        {
            return ObjectFactory.GetInstance(type);
        }

        public static bool IsRegistered<T>()
        {
            EnsureDependenciesAreRegistered();

            return (ObjectFactory.GetInstance<T>() != null);
        }

        public static bool IsRegistered(Type type)
        {
            EnsureDependenciesAreRegistered();

            return (ObjectFactory.GetInstance(type) != null);
        }

        public static void EnsureDependenciesAreRegistered()
        {
            if (!areDependenciesRegistered)
            {
                lock (syncObject)
                {
                    if (!areDependenciesRegistered)
                    {
                        new DependencyResolver().RegisterDependencies();
                        areDependenciesRegistered = true;
                    }
                }
            }
        }
    }
}
