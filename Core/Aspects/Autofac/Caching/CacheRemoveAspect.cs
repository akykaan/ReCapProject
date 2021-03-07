﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
	public class CacheRemoveAspect : MethodInterception
    // CacheRemoveAspect datamız bozulduğu zaman çalışır
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        //OnSuccess çünkü add belki hata verecek ve ekleyemeyecek
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
