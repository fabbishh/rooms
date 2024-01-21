using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Email
{
    public interface IEmailService
    {
        Task Send(EmailMetadata emailMetadata);
    }
}
