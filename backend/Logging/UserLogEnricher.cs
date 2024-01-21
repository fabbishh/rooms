using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System.Security.Claims;

namespace Logging
{
    public class UserLogEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserLogEnricher() : this(new HttpContextAccessor())
        {
        }

        public UserLogEnricher(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "UserId", _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Неизвестно"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
                "UserRole", _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role) ?? "Неизвестно"));
        }
    }
}
