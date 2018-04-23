using System.Windows;

namespace DXEditors_DataBinding {
    public partial class Window1 : Window {
        DXEditors_DataBinding.nwindDataSet.ProductsDataTable dt;
        int currentRecord;
        public Window1() {
            InitializeComponent();
            currentRecord = 0;
            dt = new nwindDataSetTableAdapters.ProductsTableAdapter().GetData();
            DataContext = dt[currentRecord];
            comboBoxEdit1.ItemsSource = 
                new nwindDataSetTableAdapters.CategoriesTableAdapter().GetData();
        }

        private void prevButton_Click(object sender, RoutedEventArgs e) {
            currentRecord--;
            UpdateData();
            UpdateButtonState();
        }
        private void nextButton_Click(object sender, RoutedEventArgs e) {
            currentRecord++;
            UpdateData();
            UpdateButtonState();
        }
        private void UpdateData() {
            DataContext = dt[currentRecord];
        }
        private void UpdateButtonState() {
            prevButton.IsEnabled = currentRecord != 0;
            nextButton.IsEnabled = currentRecord != dt.Rows.Count - 1;
        }
    }
}
