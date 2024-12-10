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
using RBkonuk.Model;

namespace RBkonuk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class helper
    {
        public static Model1 ent;
        public static bool flag = false;
        public static int prioritet = 0;

        public static Model1 GetContext()
        {
            if (ent == null)
            {
                ent = new Model1();
            }
            return ent;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new ListOfAgents(frame);
        }

        private void frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            try
            {
                ListOfAgents listOfAgents = (ListOfAgents)e.Content;
                listOfAgents.Load();
            }
            catch { };
        }
    }
}
