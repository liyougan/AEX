#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程.拦截
 * 文  件 名：拦截Selector
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/8 9:44:51
 * 版      本：V1.0.0.0
 * 描      述：
 *
 * ----------------------------------------------------------------
 * 修  改 人：
 * 时      间：
 * 修改说明：
 *
 * 版      本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AE1.容器;
using AE1.流程.拦截.拦截器;
using Castle.DynamicProxy;

namespace AE1.流程.拦截 {
    public class 拦截Selector : IInterceptorSelector {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) {
            switch (method.Name) {
                case "判断流入许可":
                    return new IInterceptor[] { ContainerService.Container.Resolve<流入许可Interceptor>() };
                case "判断流入到位":
                    return new IInterceptor[] { ContainerService.Container.Resolve<流入到位Interceptor>() };
                case "等待取料":
                    return new IInterceptor[] { ContainerService.Container.Resolve<取料完成Interceptor>() };
                case "等待流出许可":
                    return new IInterceptor[] { ContainerService.Container.Resolve<流出信号Interceptor>() };
                case "等待流出完成":
                    return new IInterceptor[] { ContainerService.Container.Resolve<流出完成Interceptor>() };

                default:
                    break;
            }
            return null;
        }
    }
}