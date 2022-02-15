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
using System.Windows.Threading;

namespace Authtoriztion
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Autht : Window
    {
        public string code = String.Empty;
        private Models.Employee _emp;
        DispatcherTimer timer = new DispatcherTimer();
        public Autht()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            code = String.Empty;
            MessageBox.Show("Время действия кода истекло");
            timer.Stop();
            btImage.IsEnabled = true;
        }

        private void clSign(object sender, RoutedEventArgs e)
        {
            if (code == tbCode.Text)
            {
                timer.Stop();
                MessageBox.Show($"Welcome, {_emp.EmployeeType.name}");
            }
        }

        private void clCancel(object sender, RoutedEventArgs e)
        {
            btSign.IsEnabled = false;
            tbCode.IsEnabled = false;
            tbCode.Text = String.Empty;
            tbNumb.Text = String.Empty;
            tbPwd.Password = String.Empty;
            btImage.IsEnabled = false;
        }

        private void tbNumb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var emp = Models.context.aGetContext().Employees.Where(p => p.login == tbNumb.Text).FirstOrDefault();
                if (emp != null)
                {
                    _emp = emp;
                    tbPwd.IsEnabled = true;
                    tbPwd.Focus();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void tbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {               
                if (_emp.pwd == tbPwd.Password)
                {
                    btSign.IsEnabled = true;
                    tbCode.IsEnabled = true;
                    Forms.ModalGen gen = new Forms.ModalGen(this);
                    gen.Show();
                    gen.IsVisibleChanged += Gen_IsVisibleChanged;
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void Gen_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var win = (sender as Window);
            if(win.IsVisible == false)
            {
                timer.Start();
                tbCode.Focus();
            }
        }

        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(code == tbCode.Text)
                {
                    timer.Stop();
                    MessageBox.Show($"Welcome, {_emp.EmployeeType.name}");
                }
            }
        }

        private void clReturn(object sender, RoutedEventArgs e)
        {
            if (_emp.pwd == tbPwd.Password)
            {
                btSign.IsEnabled = true;
                tbCode.Text = String.Empty;
                Forms.ModalGen gen = new Forms.ModalGen(this);
                gen.Show();
                gen.IsVisibleChanged += Gen_IsVisibleChanged;
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
