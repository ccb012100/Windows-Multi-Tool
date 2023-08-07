using Microsoft.Windows.AppNotifications;
using System;
using System.Collections.Generic;

namespace WindowsMultiTool
{
    internal class NotificationManager
    {
        private bool notificationManagerIsRegistered;

        private readonly Dictionary<int, Action<AppNotificationActivatedEventArgs>> c_map;

        public NotificationManager()
        {
            notificationManagerIsRegistered = false;

            // When adding new a scenario, be sure to add its notification handler here.
            c_map = new Dictionary<int, Action<AppNotificationActivatedEventArgs>>
            {
                { NowPlaying.ScenarioId, NowPlaying.NotificationReceived }
            };
        }

        ~NotificationManager()
        {
            Unregister();
        }

        public void Init()
        {
            // To ensure all Notification handling happens in this process instance, register for
            // NotificationInvoked before calling Register(). Without this a new process will
            // be launched to handle the notification.
            AppNotificationManager notificationManager = AppNotificationManager.Default;

            //notificationManager.NotificationInvoked += OnNotificationInvoked;

            notificationManager.Register();

            notificationManagerIsRegistered = true;
        }

        public void Unregister()
        {
            if (notificationManagerIsRegistered)
            {
                AppNotificationManager.Default.Unregister();
                notificationManagerIsRegistered = false;
            }
        }

        public void ProcessLaunchActivationArgs(AppNotificationActivatedEventArgs notificationActivatedEventArgs)
        {
            // Complete in Step 5
        }

    }
}
