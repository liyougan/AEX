using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AE1.容器;
using AE1.工站;
using AE1.流程;

namespace AE1 {
    class Program {
        static void Main(string[] args) {
            var flow = ContainerService.Container.Resolve<流入提升升降机Flow>();
            var frm = ContainerService.Container.Resolve<Form控制>();
            flow.Init();
            flow.Run();
            Console.WriteLine("===启动===");
            Application.Run(frm);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
        }
    }
}
