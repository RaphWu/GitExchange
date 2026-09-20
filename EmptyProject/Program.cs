using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmptyProject
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    public static class Bootstrapper
    {
        private static readonly IUnityContainer _container = new UnityContainer();
        public static void RegisterDependencies()
        {
            WebApiConfig.RegisterTypes(_container);
            DalConfig.RegisterTypes(_container);
            BllConfig.RegisterTypes(_container);
        }
    }

}
