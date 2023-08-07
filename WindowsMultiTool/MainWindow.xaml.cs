using Microsoft.UI.Xaml;
using System;

namespace WindowsMultiTool
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private const int CONTEXT_MENU_WIDTH = 200;

        public MainWindow()
        {
            InitializeComponent();

            // TODO: add system tray icon with context menu (use P/Invoke?)
        }

        /// <summary>
        /// Exit the Application on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object? sender, RoutedEventArgs? e) => ExitApplication();

        /// <summary>
        /// Show Current Media metadata notification on click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NowPlayingButton_Click(object? sender, RoutedEventArgs? e) => await NowPlaying.SendToast();

        private void ExitApplication() => Close();
    }
}
