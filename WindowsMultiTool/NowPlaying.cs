using Microsoft.Windows.AppNotifications;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Windows.Media.Control;
using Microsoft.Windows.AppNotifications.Builder;

namespace WindowsMultiTool
{
    internal static class NowPlaying
    {
        public const int ScenarioId = 1;
        public const string ScenarioName = "Now Playing Toast";

        public static async Task<bool> SendToast()
        {
            var sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();

            GlobalSystemMediaTransportControlsSession session = sessionManager.GetCurrentSession();

            if (session == null) return SendErrorToast("No current SMTC session");

            GlobalSystemMediaTransportControlsSessionMediaProperties mediaProperties = await session.TryGetMediaPropertiesAsync();

            if (mediaProperties == null) return SendErrorToast("The MediaProperties on the GMTC session was null.");

            // Dedupe list since AlbumArtist always contains Artist
            var artists = new SortedSet<string> { mediaProperties.AlbumArtist, mediaProperties.Artist };

            var notification = new AppNotificationBuilder()
                .SetTag(nameof(NowPlaying))
                .AddText(mediaProperties.Title)
                .AddText(string.Join(", ", artists))
                .AddText(mediaProperties.AlbumTitle)
                .BuildNotification();

            // TODO: use mediaProperties.Thumbnail image for inline image

            notification.ExpiresOnReboot = true;

            AppNotificationManager.Default.Show(notification);

            return notification.Id != 0; // return true if the toast was sent (if it has an Id)
        }

        public static void NotificationReceived(AppNotificationActivatedEventArgs notificationActivatedEventArgs)
        {
            // NOOP
            Console.WriteLine(notificationActivatedEventArgs);
        }

        private static bool SendErrorToast(string message)
        {
            var notification = new AppNotificationBuilder()
                .SetTag(nameof(NowPlaying))
                .SetHeroImage(new Uri("ms-appx:///Assets/wave.png"))
                .SetAppLogoOverride(new Uri("ms-appx:///Assets/wave.png"))
                .AddText(message)
                .BuildNotification();

            // TODO: use System error icon for inline image

            notification.ExpiresOnReboot = true;

            AppNotificationManager.Default.Show(notification);

            return notification.Id != 0;
        }
    }
}