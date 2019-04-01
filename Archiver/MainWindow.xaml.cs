using System.Windows;

namespace Archiver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZippingButton_Click(object sender, RoutedEventArgs e)
        {
            ZippingWindow zipping = new ZippingWindow();
            zipping.Show();
            Close();
        }

        private void UnzippingButton_Click(object sender, RoutedEventArgs e)
        {
            UnzippingWindow unzipping = new UnzippingWindow();
            unzipping.Show();
            Close();
        }
    }
}
