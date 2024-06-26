using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Infra.CrossCutting.Notification
{
    public interface INotificationSender
    {
        void Send(INotificationContent notificationContent);
    }
}
