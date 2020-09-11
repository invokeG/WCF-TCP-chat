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

namespace Lab_5
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartWindow(string userName, int left, int top)
        {
            ChatCline w = new ChatCline();
            w.Left = left;
            w.Top = top;
            w.UserName = userName;
            w.Owner = this;
            w.Closed += (sender, e) => this.Activate();//关闭子窗体时激活父窗体
            w.Show();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            StartWindow("用户1", 0, 0);
            StartWindow("用户2", 400, 300);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            ChatCline w = new ChatCline();
            w.Owner = this;
            w.Closed += (sendObj, args) => this.Activate();
            w.Show();
        }
    }
}
