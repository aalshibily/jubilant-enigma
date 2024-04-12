using Aegis.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Interfaces.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<Properties>> GetAlertsByState(string state);
    }
}
