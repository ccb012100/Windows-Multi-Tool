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
        private const int CONTEXT_MENU_WIDTH = 200;

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
            ToastNotificationManagerCompat.History.Clear();
            InitializeComponent();

            // create and initialize NotifyIcon
            _notifyIcon = new NotifyIcon();
            _contextMenuStrip = new ContextMenuStrip();

            InitializeNotifyIcon();
            InitializeContextMenu();

            // show initial application start notification
            new ToastContentBuilder().AddText("Application started").Show(toast => { toast.ExpirationTime = DateTime.Now; });

            void InitializeNotifyIcon()
            {
                _notifyIcon.Icon = new Icon(@".\Icons\multitool.ico");
                _notifyIcon.Text = "Windows Multi-Tool";
                _notifyIcon.Visible = true;
                _notifyIcon.ContextMenuStrip = _contextMenuStrip;
            }

            void InitializeContextMenu()
            {
                ToolStripButton nowPlayingButton = NewButton("⏯️ 🔊 Now Playing");
                nowPlayingButton.Click += NowPlayingButton_Click;

                ToolStripButton exitButton = NewButton("🛑 Exit");
                exitButton.Click += ExitButton_Click;

                _contextMenuStrip.Width = CONTEXT_MENU_WIDTH;
                _contextMenuStrip.Items.Add(nowPlayingButton);
                _contextMenuStrip.Items.Add(new ToolStripSeparator());
                _contextMenuStrip.Items.Add(exitButton);

                ToolStripButton NewButton(string text) => new() { Text = text, AutoSize = false, Width = CONTEXT_MENU_WIDTH, Alignment = ToolStripItemAlignment.Left };
            }
        }

        /// <summary>
        /// Exit the Application on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object? sender, EventArgs? e) => ExitApplication();

        /// <summary>
        /// Show Current Media metadata notification on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NowPlayingButton_Click(object? sender, EventArgs? e) => await NowPlaying.ShowToast();

        private static void ExitApplication()
        {
            ToastNotificationManagerCompat.History.Clear();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
