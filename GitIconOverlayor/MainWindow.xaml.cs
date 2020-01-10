﻿using CommonUtils;
using GitIconOverlayHandlers;
using System.Windows;

/*
注册表地址 计算机\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers
*/

namespace GitIconOverlayor
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
            ButtonTest.Click += ButtonTest_Click;

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxLog.Log("优先级：" + IconOverlay.Priority);
        }

        private static string _asmPath = "RegAsm.exe";
        private static string _dllPath = typeof(IconOverlay).Namespace + ".dll";

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /codebase"));
            MessageBox.Show("安装完成，重启后生效，请保留此文件夹");
        }

        private void ButtonUninstall_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /u"));
            MessageBox.Show("卸载完成，重启后生效，重启后可手动删除此文件夹");
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(FileUtil.Exists(_asmPath) + " " + _asmPath);
            //MessageBox.Show(FileUtil.Exists(_dllPath) + " " + _dllPath);

            TextBoxLog.Log(GitUtil.GetStatus(@"D:\Subversion\CommonUtils-dot-net"));
            TextBoxLog.Log(GitUtil.GetStatus(@"D:\Subversion\CommonUtils-dot-net-committed"));
        }
    }
}
