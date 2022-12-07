#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程.拦截器
 * 文  件 名：流入许可Interceptor
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/7 14:43:04
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
using AE1.流程.拦截器.特性标签;
using Castle.DynamicProxy;

namespace AE1.流程.拦截器 {
    /// <summary>
    /// 流入许可Interceptor 的摘要说明
    /// </summary>
    public class 流入许可Interceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            var 流入attr = invocation.MethodInvocationTarget
                                                                                          .GetCustomAttributes<流入许可Attribute>(true)
                                                                                          .Where(p => p.GetType() == typeof(流入许可Attribute)).FirstOrDefault();
            if (流入attr == null)
                return;
            流入attr.Process(invocation);
        }
    }


    public class 流入许可选择器 : IInterceptorSelector {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) {
            if (method.Name == "判断流入许可") {
                return interceptors;
            }
            return interceptors.Where(p => p.GetType() != typeof(流入许可Interceptor)).ToArray();
        }
    }
}