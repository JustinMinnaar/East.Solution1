using System.Windows;
using System.Windows.Controls;

namespace East.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lastValue;
        private string? lastOperation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.OriginalSource as Button;
            if (btn == null) return;

            var content = (string)btn.Content;
            if (int.TryParse(content, out int value))
            {
                tbValue.Text += content;
            }
            else
            {
                int.TryParse(tbValue.Text, out value);

                if (lastOperation == "+") value += lastValue;

                lastValue = value;
                lastOperation = content;

                if (content == "-")
                    tbValue.Text = lastOperation;
                else
                    tbValue.Text = "";
            }
        }
    }
}
