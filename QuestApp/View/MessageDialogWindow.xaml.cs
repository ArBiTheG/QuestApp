using QuestApp.Model;
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

namespace QuestApp.View
{
    /// <summary>
    /// Логика взаимодействия для MessageDialogWindow.xaml
    /// </summary>
    public partial class MessageDialogWindow : Window
    {
        Message Message;
        public MessageDialogWindow(Message message)
        {
            Message = message;
            InitializeComponent();
            DataContext = Message;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
