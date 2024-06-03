using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CasseBrique.Services
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public static T Get<T>()
        {
            if (!_services.ContainsKey(typeof(T)))
                throw new InvalidOperationException($"Service of type {typeof(T)} does not exist");
            return (T)_services[typeof(T)];
        }
    }
}
