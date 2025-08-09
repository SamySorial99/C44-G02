using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_OOP_5
{
    internal interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // 4) Simulate sending an email
            Console.WriteLine($"[EMAIL] To: {recipient} | Body: {message}");
        }
    }

    // 3) SMS implementation
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // 5) Simulate sending an SMS
            Console.WriteLine($"[SMS] To: {recipient} | Text: {message}");
        }
    }

    // 3) Push implementation
    public class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            // 6) Simulate sending a push notification
            Console.WriteLine($"[PUSH] To: {recipient} | Alert: {message}");
        }
    }


}
