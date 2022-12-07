#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1
 * 文  件 名：Form控制
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/7 10:42:16
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AE1.工站;
using AE1.流程;

namespace AE1 {
    public partial class Form控制 : Form {
        public Form控制() {
            InitializeComponent();
        }

        public 流入提升升降机Flow Flow;

        /// <summary>
        /// 设置信号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void SetSignal(object sender, EventArgs args) {
            var btnInfo = (sender as Button).Text;
            switch (btnInfo) {
                case "给流入许可":
                    await SendPulseSignal("收到流入许可信号");
                    break;
                case "给流入到位":
                    await SendPulseSignal("收到到位信号");
                    break;
                case "给取料完成信号":
                    await SendPulseSignal("收到取料完成信号");
                    break;
                case "给流出许可":
                    await SendPulseSignal("收到流出信号");
                    break;
                case "给流出完成":
                    await SendPulseSignal("收到流出完成信号");
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 发送信号
        /// </summary>
        /// <param name="signal">新信号</param>
        /// <returns></returns>
        private async Task SendPulseSignal(string signal) {
            Flow.State = signal;
            await Task.Delay(1000);
            Flow.State = "Idle";
        }
    }
}
