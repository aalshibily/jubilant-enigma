using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Services
{
    public class ToastNotificationService
    {
        private readonly List<ToastNotification> notifications = new();

        public event Action OnChange;

        public IEnumerable<ToastNotification> GetActiveNotifications() => notifications;

        public void ShowToast(string message, string heading = "Notification", int timeout = 3000)
        {
            if (notifications.Count >= 5)
            {
                notifications.RemoveAt(0); // Ensure max 5 notifications by removing the oldest one
            }

            var notification = new ToastNotification
            {
                Id = Guid.NewGuid(),
                Heading = heading,
                Message = message,
                Timeout = timeout,
                StartTime = DateTime.Now
            };

            notifications.Add(notification);
            OnChange?.Invoke();

            var interval = timeout / 100; // Calculate the interval duration to update progress
            var timer = new System.Timers.Timer(interval);
            timer.Elapsed += (sender, e) =>
            {
                var elapsed = (DateTime.Now - notification.StartTime).TotalMilliseconds;
                notification.Progress = (elapsed / timeout) * 100;
                //Console.WriteLine(notification.Progress);
                if (elapsed >= timeout)
                {
                    timer.Stop(); // Stop the timer when timeout is reached
                    timer.Dispose();
                    RemoveToast(notification.Id); // Remove the toast
                }
                OnChange?.Invoke(); // Trigger UI update
            };
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void RemoveToast(Guid id)
        {
            var item = notifications.FirstOrDefault(n => n.Id == id);
            if (item != null)
            {
                notifications.Remove(item);
                OnChange?.Invoke();
            }
        }
    }

    public class ToastNotification
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Message { get; set; }
        public int Timeout { get; set; }
        public double Progress { get; set; } = 0;
        public DateTime StartTime { get; set; }
    }

}
