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

namespace WpfTraining
{
    /// <summary>
    /// Interaction logic for ListViewFiltering.xaml
    /// </summary>
    public partial class ListViewFiltering : Window
    {
        public ListViewFiltering()
        {
            InitializeComponent();
            var items = new List<UserToFilter>();
            items.Add(new UserToFilter() { Name = "John Doe", Age = 42 });
            items.Add(new UserToFilter() { Name = "Jane Doe", Age = 39 });
            items.Add(new UserToFilter() { Name = "Sammy Doe", Age = 13 });
            items.Add(new UserToFilter() { Name = "Donna Doe", Age = 13 });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as UserToFilter).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }
    }
    public enum SexType { Male, Female };

    public class UserToFilter
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public SexType Sex { get; set; }
    }
}
