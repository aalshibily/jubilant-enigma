using Aegis.Core.Domain.Entities;
using Aegis.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Interfaces.Services
{
    public interface IJokeService
    {
        Task<IEnumerable<Joke>> GetJokeById(int id);
        Task<IEnumerable<Joke>> GetOneRandom();
        Task<IEnumerable<Joke>> GetTenRandom();
        Task<IEnumerable<Joke>> GetOneByType(JokeType type);
        Task<IEnumerable<Joke>> GetTenByType(JokeType type);
    }
}
