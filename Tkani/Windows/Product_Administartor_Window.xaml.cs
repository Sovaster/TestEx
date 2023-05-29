using System;
using System.Collections.Generic;
using System.Data;
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
using Tkani.Fabrics_Data_SetTableAdapters;

namespace Tkani.Windows
{
    /// <summary>
    /// Логика взаимодействия для Administrator_Product_Window.xaml
    /// </summary>
    public partial class Product_Administartor_Window : Window
    {
        Fabrics_Data_Set fabrics_Data_Set = new Fabrics_Data_Set();
        ProductTableAdapter productTableAdapter = new ProductTableAdapter();

        int Count_Products;
        public Product_Administartor_Window(/*string fio_user*/)
        {
            InitializeComponent();

            FIO_User.Content = "ГГ ВП ОЛ";

            productTableAdapter.Fill(fabrics_Data_Set.Product);
            Product_LV.ItemsSource = fabrics_Data_Set.Product.DefaultView;
            Product_LV.SelectedValuePath = "Article";
            Count_Products = Product_LV.Items.Count;
            Search_LB.Content = "Все товары: " + Product_LV.Items.Count;
        }

        private void Product_Delete_BTN_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Product_LV.SelectedValue != "" || (string)Product_LV.SelectedValue != null)
            {
                try
                {
                    if (MessageBox.Show("Вы точно хотите удалить данный товар?\nТовар будет окончательно удалён из базы!", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        productTableAdapter.DeleteProduct((string)Product_LV.SelectedValue);
                        productTableAdapter.Fill(fabrics_Data_Set.Product);
                        Product_LV.ItemsSource = fabrics_Data_Set.Product.DefaultView;
                        Count_Products = Product_LV.Items.Count;
                        Search_LB.Content = "Все товары: " + Product_LV.Items.Count;
                    }
                }
                catch
                {
                    MessageBox.Show("Товар используется в заказах!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Product_LV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Insert_Tovar_BTN_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Exit_BTN_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorizationWindow = new Authorization();
            authorizationWindow.Show();
            this.Close();
        }

        private void tb_SearchProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_SearchProduct.Text != "" && tb_SearchProduct.Text != null)
            {
                try
                {
                    productTableAdapter.Search(fabrics_Data_Set.Product, tb_SearchProduct.Text);
                    Product_LV.ItemsSource = fabrics_Data_Set.Product.DefaultView;
                    if (Product_LV.HasItems == true)
                    {
                        Search_LB.Content = "Найденные товары: " + Product_LV.Items.Count +"/"+ Count_Products;
                    }
                    else
                    {
                        Search_LB.Content = "Ничего не найдено";
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка поиска!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                productTableAdapter.Fill(fabrics_Data_Set.Product);
                Product_LV.ItemsSource = fabrics_Data_Set.Product.DefaultView;
                Search_LB.Content = "Все товары: " + Product_LV.Items.Count;
            }
        }
    }
}
