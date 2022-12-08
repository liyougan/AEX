#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程.拦截器.特性标签
 * 文  件 名：流出信号Attribute
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/8 9:19:14
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
using Castle.DynamicProxy;

namespace AE1.流程.拦截.特性标签 {
    /// <summary>
    /// 流出信号Attribute 的摘要说明
    /// </summary>
    public class 流出信号Attribute : Attribute, IAttributeProcedure {
        public void Process(IInvocation invocation) {
            流入提升升降机Flow flow = invocation.InvocationTarget as 流入提升升降机Flow;
            if (flow == null)
                return;
            if (flow.CurrentState == 流入提升升降机Flow.State.收到流出信号) {
                invocation.Proceed();
            }
        }
    }
}