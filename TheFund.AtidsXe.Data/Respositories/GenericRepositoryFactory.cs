using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheFund.AtidsXe.Data.Respositories
{
    public class GenericRepositoryFactory : IGenericRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public GenericRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGenericRepository Create()
        {
            return _serviceProvider.GetService<IGenericRepository>();
        }
    }
}
