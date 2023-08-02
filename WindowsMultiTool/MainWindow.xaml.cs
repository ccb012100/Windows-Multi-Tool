using System;
using System.Drawing;
using System.Windows;

namespace WindowsMultiTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("entered MainWindow");
            // InitializeComponent call is required to merge the UI
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();

            var notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                BalloonTipText = "Windows Multi-tool has started",
                Icon = new Icon(@".\Icons\multitool.ico"),
                Text = "Windows Multi-Tool",
                Visible = true
            };

            notifyIcon.ShowBalloonTip(3000);
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
