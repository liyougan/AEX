#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.容器
 * 文  件 名：ContainerService
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/7 13:57:28
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AE1.工站;
using AE1.流程;
using AE1.流程.拦截;
using AE1.流程.拦截.拦截器;
using AE1.流程.拦截.特性标签;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;




namespace AE1.容器 {
    /// <summary>
    /// ContainerService 的摘要说明
    /// </summary>
    public static class ContainerService {
        public static WindsorContainer Container = new WindsorContainer();

        static ContainerService() {
            Container.Register(Component.For<流入提升升降机>());

            Container.Register(Component.For<流入许可Interceptor>());
            Container.Register(Component.For<流入到位Interceptor>());
            Container.Register(Component.For<取料完成Interceptor>());
            Container.Register(Component.For<流出信号Interceptor>());
            Container.Register(Component.For<流出完成Interceptor>());

            //Container.Register(Component.For<拦截Selector>().LifeStyle.Transient);

            Container.Register(Component.For<流入提升升降机Flow>()
                                                                                .Interceptors(typeof(流入许可Interceptor), typeof(流入到位Interceptor), typeof(取料完成Interceptor), typeof(流出信号Interceptor), typeof(流出完成Interceptor))
                                                                                .SelectInterceptorsWith(new 拦截Selector())
                                                                                 );

            Container.Register(Component.For<Form控制>());

        }


    }
}