using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE1.工站;
using AE1.流程;

namespace AE1 {
    class Program {
        static void Main(string[] args) {
            var 流入提升升降机 = new 流入提升升降机();
            var flow = new 流入提升升降机Flow(流入提升升降机);
            flow.Run();
            Console.WriteLine("===启动===");


            ConsoleKeyInfo keyInfo = Console.ReadKey();
        }
    }
}
