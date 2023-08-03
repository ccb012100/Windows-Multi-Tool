using System;
using System.Threading.Tasks;
using Windows.Media.Control;

namespace WindowsMultiTool
{
    internal static class NowPlaying
    {
        public static async Task<GlobalSystemMediaTransportControlsSessionMediaProperties> GetMediaProperties()
        {
            var session = await GetMediaSession();

            return await session.TryGetMediaPropertiesAsync();
        }

        private static async Task<GlobalSystemMediaTransportControlsSession> GetMediaSession()
        {
            var sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();

            return sessionManager.GetCurrentSession();
        }
    }
}
