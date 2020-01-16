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

            Loaded += MainWindow_Loaded;

            ButtonInstall.Click += ButtonInstall_Click;
            ButtonUninstall.Click += ButtonUninstall_Click;
            LabelUpdate.Click += LabelUpdate_Click;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxLog.Log("Overlay Priority：" + GitIconOverlayHandler.Priority);
            TextBoxLog.Log("FirstAccessStatus：" + GitIconOverlayHandler.FirstAccessStatus);
        }

        private static string _asmPath = "RegAsm.exe";
        private static string _dllPath = typeof(GitIconOverlayHandler).Namespace + ".dll";

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            RegistryUtil.SetToConfig(GitIconOverlayHandler.RootFloderFiled, PathUtil.Base);
            TextBoxLog.Log("SetToRegeditConfig: " + GitIconOverlayHandler.RootFloderFiled + " = " + PathUtil.Base);
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /codebase"));
            MessageBox.Show("安装完成，重启后生效，请保留此文件夹");
        }

        private void ButtonUninstall_Click(object sender, RoutedEventArgs e)
        {
            RegistryUtil.RemoveFromConfig(GitIconOverlayHandler.RootFloderFiled);
            TextBoxLog.Log("RemoveFromRegeditConfig: " + GitIconOverlayHandler.RootFloderFiled);
            TextBoxLog.Log(ProcessUtil.Run(_asmPath, _dllPath + " /u"));
            MessageBox.Show("卸载完成，重启后生效，重启后可手动删除此文件夹");
        }

        private void LabelUpdate_Click(object sender, RoutedEventArgs e)
        {
            UrlUtil.Open("https://gitee.com/atalent/GitIconOverlayor/releases");
        }
    }
}
