using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public interface IEmail
    {
        Task Send(string email, string subject, string body);
    }
}
