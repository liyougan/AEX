#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程.拦截器.特性标签
 * 文  件 名：IAttributeProcedure
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/7 14:47:28
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

namespace AE1.流程.拦截器.特性标签 {
    /// <summary>
    /// IAttributeProcedure 的摘要说明
    /// </summary>
    public interface IAttributeProcedure {
        void Process(IInvocation invocation);
    }
}
