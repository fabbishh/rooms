
using FluentEmail.MailKitSmtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Extensions
{
    public static class FluentEmailExtensions
    {
        public static void AddFluentEmail(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var emailSettings = configuration.GetSection("EmailSettings");

            var defaultFromEmail = emailSettings["DefaultFromEmail"];
            var host = emailSettings["SMTPSetting:Host"];
            var port = emailSettings.GetValue<int>("SMTPSetting:Port");
            var userName = emailSettings.GetValue<string>("SMTPSetting:Username");
            var password = emailSettings.GetValue<string>("SMTPSetting:Password");

            services.AddFluentEmail(defaultFromEmail)
                .AddMailKitSender(new SmtpClientOptions
                {
                    Server = host,
                    Port = port,
                    Password = password,
                    User = userName,
                    UseSsl = true,
                    SocketOptions = SecureSocketOptions.SslOnConnect,
                    RequiresAuthentication = true,
                });
        
        }
    }
}
