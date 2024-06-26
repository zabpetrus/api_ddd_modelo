using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Infra.CrossCutting.Notification
{
    public interface INotificationContent
    {
        /// <summary>
        /// This property store the identification of whom that will send this notification
        /// </summary>
        string From { get; set; }

        /// <summary>
        /// Comma separated list of identifications of whom that will receive this notification
        /// </summary>
        string[] To { get; set; }

        /// <summary>
        /// Notification content
        /// </summary>
        string Body { get; set; }
    }
}
