using System;
using System.Windows.Forms;
using Ninject;
using Students.BusinessLogic;

namespace Students.View
{
    internal static class Program
    {
        // Единственная внешняя зависимость View — контейнер Ninject.
        public static IKernel Kernel { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Composition root: контейнер собирается один раз здесь.
            Kernel = new StandardKernel(new SimpleConfigModule());

            var service = Kernel.Get<StudentService>();
            service.InitializeDatabase();

            Application.Run(new Form1(service, Kernel));
        }
    }
}
