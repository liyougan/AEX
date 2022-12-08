﻿#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程.拦截.拦截器
 * 文  件 名：流入到位Interceptor
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/8 9:26:03
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
using AE1.流程.拦截.特性标签;
using Castle.DynamicProxy;

namespace AE1.流程.拦截.拦截器 {
    /// <summary>
    /// 流入到位Interceptor 的摘要说明
    /// </summary>
    public class 流入到位Interceptor : IInterceptor {
        public void Intercept(IInvocation invocation) {
            var attr = invocation.MethodInvocationTarget.GetCustomAttributes<流入到位Attribute>(true).FirstOrDefault();
            if (attr == null)
                return;
            attr.Process(invocation);
        }
    }
}