using RBkonuk.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RBkonuk
{
    /// <summary>
    /// Логика взаимодействия для ListOfAgents.xaml
    /// </summary>
    public partial class ListOfAgents : Page
    {
        private int start = 0;
        private int fullCount = 0;
        private int iag = 0;
        private string fnd = "";
        Frame frame;

        public ListOfAgents(Frame frm)
        {
            frame = frm;
            InitializeComponent();

            List<ProductType> productTypes = new List<ProductType>();
            productTypes = helper.GetContext().ProductType.ToList();
            productTypes.Add(new ProductType { Title = "Все" });
            Type.ItemsSource = productTypes.OrderBy(ProductType => ProductType.ID);

            Load();
        }

        public void Load()
        {
            try
            {
                List<Product> products = new List<Product>();
                var query = helper.GetContext().Product.Where(Product => Product.Title.Contains(fnd) || Product.ArticleNumber.Contains(fnd));
                if (iag > 0) query = query.Where(Product => Product.ProductTypeID == iag);
                products.Clear();

                fullCount = query.Count();
                agentGrid.ItemsSource = query.OrderBy(Product => Product.ID).Skip(start * 10).Take(10).ToList();
            }
            catch
            {
                return;
            }

            int ost = fullCount % 10;
            int pag = (fullCount - ost) / 10;
            if (ost > 0) pag++;
            pagin.Children.Clear();
            for (int i = 0; i < pag; i++)
            {
                Button myButton = new Button();
                myButton.Height = 30;
                myButton.Content = i + 1;
                myButton.Width = 20;
                myButton.HorizontalAlignment = HorizontalAlignment.Center;
                myButton.Tag = i;
                myButton.Click += new RoutedEventHandler(paginButton_Click);
                pagin.Children.Add(myButton);
            }
            turnButton();
        }

        private void turnButton()
        {
            if (start == 0) { back.IsEnabled = false; }
            else { back.IsEnabled = true; };
            if ((start + 1) * 10 > fullCount) { forward.IsEnabled = false; }
            else { forward.IsEnabled = true; };
        }

        private void paginButton_Click(object sender, RoutedEventArgs e)
        {
            start = Convert.ToInt32(((Button)sender).Tag.ToString());
            Load();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            start--;
            Load();
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            start++;
            Load();
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            iag = ((ProductType)Type.SelectedItem).ID;
            Load();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            fnd = ((TextBox)sender).Text;
            Load();
        }
    }
}