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
using System.Windows.Shapes;

namespace Authtoriztion.Forms
{
    /// <summary>
    /// Логика взаимодействия для ModalGen.xaml
    /// </summary>
    public partial class ModalGen : Window
    {
        public ModalGen(Autht mn)
        {
            InitializeComponent();
            string arg = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm!@#$%^&*()_+";
            Random rnd = new Random();
            for(int i = 0; i<8; i++)
            {
                tbModal.Text += arg[rnd.Next(arg.Length)];
                mn.code = tbModal.Text;
            }
        }
    }
}
