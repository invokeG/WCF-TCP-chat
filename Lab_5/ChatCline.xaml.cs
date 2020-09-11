using Lab_5.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_5
{
    /// <summary>
    /// ChatCline.xaml 的交互逻辑
    /// </summary>
    public partial class ChatCline : Window,IService1Callback
    {
        public ChatCline()
        {
            InitializeComponent();
            this.Closing += ChatCline_Closing;
            box.Visibility = System.Windows.Visibility.Hidden;
        }

        private Service1Client client;

        public string UserName
        {
            get { return textbox.Text; }
            set { textbox.Text = value; }
        }

        private void ChatCline_Closing(object sender, CancelEventArgs e)
        {
            if (client != null)
            {
                client.Logout(UserName); 
                client.Close();
            }
        }

        private void AddMessage(string str)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            listmessage.Items.Add(t);
        }

        public void InitUsersInfo(string UsersInfo)
        {
            if (UsersInfo.Length == 0) return;
            string[] users = UsersInfo.Split('、');
            for (int i = 0; i < users.Length; i++)
            {
                listbox.Items.Add(users[i]);
            }
        }

        public void ShowLogin(string loginUserName)
        {
            if (loginUserName == UserName)
            {
                box.Visibility = System.Windows.Visibility.Visible;
            }
            listbox.Items.Add(loginUserName);
        }

        public void ShowLogout(string userName)
        {
            listbox.Items.Remove(userName);
        }

        public void ShowTalk(string userName, string message)
        {
            AddMessage(userName+"说: "+message);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            UserName = textbox.Text;
            InstanceContext context = new InstanceContext(this);
            client = new Service1Client(context);
            try
            {
                client.Login(textbox.Text);
                login.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("与服务端连接失败：" + ex.Message);
                return;
            }
        }

        private void launch_Click(object sender, RoutedEventArgs e)
        {
            client.Talk(UserName, messagebox.Text);
            messagebox.Text = "";
        }


        private void messagebox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                client.Talk(UserName, messagebox.Text);
                messagebox.Text = "";
            }
        }
    }
}
