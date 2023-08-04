using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using Windows.UI.Notifications;

namespace WindowsMultiTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// System tray icon
        /// </summary>
        private readonly NotifyIcon _notifyIcon;

        /// <summary>
        /// Context menu for the system tray icon
        /// </summary>
        private readonly ContextMenuStrip _contextMenuStrip;

        public MainWindow()
        {
            InitializeComponent();

            // create and initialize NotifyIcon
            _notifyIcon = new NotifyIcon();
            _contextMenuStrip = new ContextMenuStrip();

            InitializeNotifyIcon();
            InitializeContextMenu();

            _notifyIcon.ContextMenuStrip = _contextMenuStrip;

            // show initial application start notification
            new ToastContentBuilder().AddText("Application started").Show(toast => { toast.ExpirationTime = DateTime.Now.AddSeconds(1); });

            void InitializeNotifyIcon()
            {
                _notifyIcon.Icon = new Icon(@".\Icons\multitool.ico");
                _notifyIcon.Text = "Windows Multi-Tool";
                _notifyIcon.Visible = true;
            }

            void InitializeContextMenu()
            {
                var exitButton = new ToolStripButton { Text = "🛑 Exit" };
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
        void ExitButton_Click(object? sender, EventArgs? e) => System.Windows.Application.Current.Shutdown();

        /// <summary>
        /// Show Current Media metadata notification on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NowPlayingButton_Click(object? sender, RoutedEventArgs? e) => await NowPlaying.ShowToast();
    }
}
