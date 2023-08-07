using Microsoft.UI.Xaml;
using System;

namespace WindowsMultiTool
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        private readonly Window mainWindow;
        private readonly NotificationManager notificationManager;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            notificationManager = new NotificationManager();
            notificationManager.Init();

            mainWindow = new MainWindow();
            mainWindow.Activate();

            // TODO: make app single instanced. Right now, clicking a notification will open a new instance
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // TODO: add logging
        }

        void OnProcessExit(object? sender, EventArgs? e) => notificationManager?.Unregister();
    }
}
