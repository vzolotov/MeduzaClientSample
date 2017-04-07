using System;
using System.Collections.Generic;
using System.Text;

namespace MeduzaClient.Services.Interfaces
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
    }
}
