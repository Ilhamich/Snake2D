using System;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsSnakeChois
{
    public partial class VersionChoisForm : Form
    {
        public VersionChoisForm()
        {
            InitializeComponent();
        }

        private void Console_Click(object sender, EventArgs e)
        {
            Assembly asm = Assembly.Load("ConsoleSnake");
            Type gameType = asm.GetType("ConsoleSnake.Program", true, false);
            object obj = Activator.CreateInstance(gameType);
            MethodInfo mi = gameType.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic);
            mi.Invoke(obj, new object[] { new string[] { } });
        }

        private void WindowForms_Click(object sender, EventArgs e)
        {
            Assembly asm = Assembly.Load("WFormsSnake");
            Type gameType = asm.GetType("WFormsSnake.Program", true, false);
            object obj = Activator.CreateInstance(gameType);
            MethodInfo mi = gameType.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic);
            mi.Invoke(obj, new object[] { new string[] { } });
        }
    }
}
