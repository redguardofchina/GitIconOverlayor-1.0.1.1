using CommonUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TortoiseGitNotPushedIconOverlayor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonInstall.Click += ButtonInstall_Click;
            ButtonUninstall.Click += ButtonUninstall_Click;
        }

        private const string _asmPath = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe";
        //private static string _asmPath = PathUtil.GetFull("RegAsm.exe");
        //private static string _dllPath = PathUtil.GetFull("TortoiseGitNotPushedIconOverlayHandler.dll");
        private static string _dllPath = "TortoiseGitNotPushedIconOverlayHandler1.dll";

        private static string _installCommand = string.Format("{0} {1} /codebase", _asmPath, _dllPath);
        private static string _uninstallCommand = string.Format("{0} {1} /u", _asmPath, _dllPath);

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(FileUtil.Exists(_asmPath) + " " + _asmPath);
            //TextBoxLog.Log(CommandUtil.Run(_installCommand));
            //TextBoxLog.Log(CommandUtil.Execute("ipconfig/all"));
            //TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath));
            TextBoxLog.Log(CommandUtil.Ping("192.168.1.1"));
        }

        private void ButtonUninstall_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(FileUtil.Exists(_dllPath) + " " + _dllPath);
            TextBoxLog.Log(CommandUtil.Run(_uninstallCommand));
        }
    }
}
