using CommonUtils;
using System.Windows;

/*
注册表地址 计算机\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers 
*/

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

        //private const string _asmPath = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe";
        //private static string _asmPath = PathUtil.GetFull("RegAsm.exe");
        private static string _asmPath = "RegAsm.exe";

        //private static string _dllPath = PathUtil.GetFull("TortoiseGitNotPushedIconOverlayHandler.dll");
        private static string _dllPath = "TortoiseGitNotPushedIconOverlayHandler.dll";

        //private static string _installCommand = string.Format("{0} {1} /codebase", _asmPath, _dllPath); //FullPath
        //private static string _uninstallCommand = string.Format("{0} {1} /u", _asmPath, _dllPath); //FullPath

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(FileUtil.Exists(_asmPath) + " " + _asmPath);
            //TextBoxLog.Log(CommandUtil.Run(_installCommand));
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /codebase"));
        }

        private void ButtonUninstall_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(FileUtil.Exists(_dllPath) + " " + _dllPath);
            //TextBoxLog.Log(CommandUtil.Run(_uninstallCommand));
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /u"));
        }
    }
}
