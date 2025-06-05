using Castle.Windsor;
using Domino;
using Domino2;
using GameDomino.Game;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;

namespace GameDomino
{
    internal static class Program
    {
        public static WindsorContainer Container { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container = new WindsorContainer();
            Container.Install(new WindsorInstaller());
            var entryForm = Container.Resolve<Entry>();
            Application.Run(entryForm);
        }
    }
}