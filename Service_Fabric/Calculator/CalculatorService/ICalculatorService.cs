using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace CalculatorService
{
    interface ICalculatorService : IService
    {
        Task<int> Add(int a, int b);
        Task<int> Subtract(int a, int b);
    }
}
