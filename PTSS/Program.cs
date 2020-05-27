using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTSS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TSSolver woof = new TSSolver(2, "abc", new string[] { "bc", "a", "aaa" });
            Stopwatch pTime = new Stopwatch();
            pTime.Start();
            Debug.WriteLine(woof.Solve("aaa"));
            pTime.Stop();
            Debug.WriteLine(pTime.Elapsed);

            Application.Run(new Form1());
        }
    }
}
