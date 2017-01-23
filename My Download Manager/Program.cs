using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace My_Download_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            CustomApplication myapp = new CustomApplication();
            myapp.Run(args);
        }

        #region >- Single App -<
        /// <summary>
        /// Tạm thời dùng cách này !
        /// Cách này khá chậm. Nếu tìm ra cách khác sẻ thay thế :)
        /// </summary>
        class CustomApplication : WindowsFormsApplicationBase
        {
            public CustomApplication()
            {
                this.IsSingleInstance = true;
                this.EnableVisualStyles = true;
                this.ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses;
                this.StartupNextInstance += new StartupNextInstanceEventHandler(CustomApplication_StartupNextInstance);
            }
            protected override void OnCreateMainForm()
            {
                this.MainForm = new Main();
                ((Main)this.MainForm).Args = new string[this.CommandLineArgs.Count];
                this.CommandLineArgs.CopyTo(((Main)this.MainForm).Args, 0);
            }
            void CustomApplication_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                string[] args = new string[e.CommandLine.Count];
                e.CommandLine.CopyTo(args, 0);
                Main frm = (Main)this.MainForm;
                object[] parameters = new object[2];
                parameters[0] = frm;
                parameters[1] = args;
                this.MainForm.Invoke(new Main.OpenNewMainFormCallback(frm.OpenNewMainForm), parameters);
            }

        }

        #endregion
    }
}