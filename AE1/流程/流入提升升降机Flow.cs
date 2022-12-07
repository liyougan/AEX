#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * CLR 版本：4.0.30319.42000
 * 公司名称：BZ
 * 命名空间：AE1.流程
 * 文  件 名：流入提升升降机Flow
 * 
 * 创  建 者：liyougan
 * 创建时间：2022/12/7 9:26:49
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
using System.Threading;
using System.Threading.Tasks;
using AE1.工站;

namespace AE1.流程 {
    /// <summary>
    /// 流入提升升降机Flow 的摘要说明
    /// </summary>
    public class 流入提升升降机Flow {

        public 流入提升升降机Flow(流入提升升降机 station) {
            this.流入提升升降机 = station;
            Init();
        }

        /*=============================================[-- 参数 --]=============================================*/
        public 流入提升升降机 流入提升升降机 { get; set; }
        private Step _currentStep = Step.Idle;
        private Dictionary<Step, MethodInfo> _stepDict = null;
        public enum Step {
            Idle,
            判断流入许可,
            流入,
            判断流入到位,
            扫码,
            等待取料,
            下降,
            等待流出许可,
            流出,
            等待流出完成,
            上升,
            完成,


            异常开始,
            异常处理,
            异常处理完成
        }
        public string State { get; set; } = "Idle";

        /*=============================================[-- AutoFlow --]=============================================*/
        public void Run() {
            _currentStep = Step.判断流入到位;
            var t = new Task(() => {
                while (true) {
                    _stepDict[_currentStep]?.Invoke(this, null);
                    Thread.Sleep(1000);
                }
            }, TaskCreationOptions.LongRunning);
            t.Start();
        }

        #region AutoFlow
        public void 判断流入许可() {
            Console.WriteLine("判断流入许可--OK");
            _currentStep = Step.流入;
        }

        public void 流入() {
            Console.WriteLine("流入电机正转");
            _currentStep = Step.判断流入到位;
        }

        public void 判断流入到位() {
            Console.WriteLine("判断流入到位--OK");
            _currentStep = Step.扫码;
        }
        public void 扫码() {
            Console.WriteLine("扫码");
            _currentStep = Step.等待取料;
        }
        public void 等待取料() {
            Console.WriteLine("等待取料");
            _currentStep = Step.下降;
        }
        public void 下降() {
            Console.WriteLine("下降");
            _currentStep = Step.等待流出许可;
        }
        public void 等待流出许可() {
            Console.WriteLine("等待流出许可--OK");
            _currentStep = Step.流出;
        }
        public void 流出() {
            Console.WriteLine("流出");
            _currentStep = Step.等待流出完成;
        }
        public void 等待流出完成() {
            Console.WriteLine("等待流出完成");
            _currentStep = Step.上升;
        }
        public void 上升() {
            Console.WriteLine("上升");
            _currentStep = Step.完成;
        }
        public void 完成() {
            Console.WriteLine("完成");
            _currentStep = Step.判断流入许可;
        }
        #endregion






        /*=============================================[-- 辅助 --]=============================================*/
        private void Init() {
            _stepDict = new Dictionary<Step, MethodInfo>();
            var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo methodInfo in methods) {
                if (Enum.GetNames(typeof(Step)).Contains(methodInfo.Name)) {
                    var step = (Step)Enum.Parse(typeof(Step), methodInfo.Name);
                    _stepDict.Add(step, methodInfo);
                }
            }
        }







    }
}