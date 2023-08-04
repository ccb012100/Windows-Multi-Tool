using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media.Control;

namespace WindowsMultiTool
{
    internal static class NowPlaying
    {
        public static async Task ShowToast()
        {
            var sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();

            GlobalSystemMediaTransportControlsSession session = sessionManager.GetCurrentSession();

            // TODO: notification when there is no current media session
            if (session == null) return;

            GlobalSystemMediaTransportControlsSessionMediaProperties mediaProperties = await session.TryGetMediaPropertiesAsync();

            // TODO: notification when there are no media properties
            if (mediaProperties == null) return;

            // for documentation, see:
            // <https://learn.microsoft.com/en-us/windows/apps/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop-msix>
            var builder = new ToastContentBuilder();

            // Dedupe list since AlbumArtist always contains Artist
            var artists = new SortedSet<string> { mediaProperties.AlbumArtist, mediaProperties.Artist };

            // TODO: use generic image when/if mediaProperties.Thumbnail is null
            if (mediaProperties.Thumbnail != null)
            {
                // TODO: add image to toast notification
            }

            builder
                .AddText(mediaProperties.Title)
                .AddText(string.Join(", ", artists))
                .AddText(mediaProperties.AlbumTitle)
                .Show(toast => { toast.ExpirationTime = DateTime.Now.AddMinutes(10); });
        }
    }
}
