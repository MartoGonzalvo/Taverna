using ControlPortales.Infraestructure.Services.Services.Notifications.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.Services.Services.Notifications
{
    internal class NotificationsService : INotificationsService
    {
        private readonly ILogger<NotificationsService> _logger;
        private readonly HttpClient _httpClient;

        public NotificationsService(ILogger<NotificationsService> logger, HttpClient httpClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task SendMail(SendMailData data)
        {
            var response = await _httpClient.PostAsJsonAsync("Mail", data);

            response.EnsureSuccessStatusCode();


        }

    }
}
