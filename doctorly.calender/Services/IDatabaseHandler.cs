using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public interface IDatabaseHandler
    {
        IDbConnection GetDbConnection();
    }
}
