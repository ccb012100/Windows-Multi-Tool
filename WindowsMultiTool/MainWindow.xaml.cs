using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace WindowsMultiTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int BALLOON_TIP_DURATION_MS = 3000;
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenuStrip;
        public MainWindow()
        {
            Console.WriteLine("entered MainWindow");
            // InitializeComponent call is required to merge the UI
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();

            // create and initialize NotifyIcon
            _notifyIcon = new NotifyIcon();
            _contextMenuStrip = new ContextMenuStrip();

            InitializeNotifyIcon();
            InitializeContextMenu();

            _notifyIcon.ContextMenuStrip = _contextMenuStrip;

            // show initial application start notification
            _notifyIcon.ShowBalloonTip(BALLOON_TIP_DURATION_MS);

            void InitializeNotifyIcon()
            {
                _notifyIcon.BalloonTipText = "Windows Multi-tool has started";
                _notifyIcon.Icon = new Icon(@".\Icons\multitool.ico");
                _notifyIcon.Text = "Windows Multi-Tool";
                _notifyIcon.Visible = true;
            }
            void InitializeContextMenu()
            {
                var exitButton = new ToolStripButton
                {
                    Text = "🛑 Exit"
                };
                exitButton.Click += ExitButton_Click;

                _contextMenuStrip.Items.Add(new ToolStripSeparator());
                _contextMenuStrip.Items.Add(exitButton);

                _contextMenuStrip.Width = 200;
            }
        }

        /// <summary>
        /// Exit the Application on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ExitButton_Click(object? sender, EventArgs? e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Show Volume and Now Playing popup on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MediaPopupButton_Click(object? sender, RoutedEventArgs? e)
        {
            var mediaProperties = await NowPlaying.GetMediaProperties();

            _notifyIcon.BalloonTipText = mediaProperties.Dump();

            _notifyIcon.ShowBalloonTip(BALLOON_TIP_DURATION_MS);
        }
    }
}
