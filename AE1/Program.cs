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
            //var 流入提升升降机 = new 流入提升升降机();
            //var flow = new 流入提升升降机Flow(流入提升升降机);
            //flow.Run();
            //Console.WriteLine("===启动===");
            //Form控制 frm = new Form控制();
            //frm.Show();


            var 流入提升升降机 = ContainerService.Container.Resolve<流入提升升降机>();
            var flow = ContainerService.Container.Resolve<流入提升升降机Flow>();
            var frm = ContainerService.Container.Resolve<Form控制>();
            frm.Flow = flow;
            flow.Run();
            Console.WriteLine("===启动===");
            Application.Run(frm);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
        }
    }
}
