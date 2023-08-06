using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsMultiTool
{
    internal static class Notifications
    {
        private const int NOTIFICATION_DURATION_MS = 5000;

        /// <summary>
        /// Show toast notification indicating an Error
        /// </summary>
        /// <param name="message"></param>
        public static void ShowErrorToast(string message)
        {
            // TODO: add an image
            new ToastContentBuilder()
                .AddText(message)
                .Show(toast => { toast.ExpirationTime = DateTime.Now.AddMilliseconds(NOTIFICATION_DURATION_MS); });
        }

        /// <summary>
        /// Show toast notification indicating a Warning
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarningToast(string message)
        {
            // TODO: add an image
            new ToastContentBuilder()
                .AddText(message)
                .Show(toast => { toast.ExpirationTime = DateTime.Now.AddMilliseconds(NOTIFICATION_DURATION_MS); });
        }
    }
}
