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

        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(PathUtil.Base);
        }

        private void ButtonUninstall_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(PathUtil.Base);
        }
    }
}
