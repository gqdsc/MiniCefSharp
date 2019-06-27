using System.Windows;

namespace VideoTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            BrowserContainer.Load("http://vodkj1m4ppg.vod.126.net/vodkj1m4ppg/e7ee5119-923c-4d4d-80d6-e6c6adf65eae.mp4");
        }
    }
}
