using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        private LoggerServiceBase _loggerServiceBase;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(DatabaseLogger));
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

                string logData = $"Metod Geç Çalışıyor :  {methodName} -->{_stopwatch.Elapsed.TotalSeconds}";
               // Debug.WriteLine(logData);
                _loggerServiceBase.Info(logData);

            }
            _stopwatch.Reset();
        }

    
    }
}
