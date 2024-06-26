using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Infra.CrossCutting.Notification
{
    [Serializable]
    public abstract class NotificationContent : INotificationContent
    {
        public string From { get; set; }

        public string[] To { get; set; }

        public string Body { get; set; }
    }
}
