using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Services
{
    public interface IConversorService
    {
        Task<double> Convert(double value);
    }
}
