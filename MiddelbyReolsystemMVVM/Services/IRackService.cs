using MiddelbyReolsystemMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Services
{
    public interface IRackService
    {
        IEnumerable<Rack> GetPredefinedRacks();
    }
}
