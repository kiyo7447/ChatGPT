using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;
using System.Collections.Generic;

namespace AzureNotificationHubConsoleApp.Services
{
    public class NotificationService
    {
        private NotificationHubClient _hub;

        public NotificationService(string? notificationHubConnectionString=null, string? notificationHubName=null)
        {
            _hub = NotificationHubClient.CreateClientFromConnectionString(notificationHubConnectionString, notificationHubName);
        }

        public async Task SendNotificationAsync(string message, List<string> tags)
        {
            // Android notification payload
//            var androidPayload = "{ \"data\" : {\"message\":\"" + message + "\"}}";
            var androidPayload = "{ \"notification\" : {\"title\" : \"Notification Hub Test Notification\", \"body\":\"" + message +  "\"},     \"data\" : {\"message\":\"" + message + "\"}}";

            // iOS notification payload
            var applePayload = "{\"aps\":{\"alert\":\"" + message + "\"}}";

            // Windows (UWP) notification payload
            var windowsPayload = @"<toast><visual><binding template=""ToastText01""><text id=""1"">" +
                                    message + "</text></binding></visual></toast>";

            // Send the message to the specified tags
            await _hub.SendFcmNativeNotificationAsync(androidPayload, tags);
            await _hub.SendAppleNativeNotificationAsync(applePayload, tags);
            await _hub.SendWindowsNativeNotificationAsync(windowsPayload, tags);
        }
    }
}