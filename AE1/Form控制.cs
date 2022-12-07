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

        private 流入提升升降机Flow flow;

        private async void SetSignal(object sender, EventArgs args) {
            var btnInfo = (sender as Button).Text;
            switch (btnInfo) {
                case "给流入许可":
                    await SendPulseSignal("收到流入信号");
                    break;
                default:
                    break;
            }
        }

        private async Task SendPulseSignal(string signal) {
            flow.State = signal;
            await Task.Delay(1000);
            flow.State = "Idle";
        }
    }
}
