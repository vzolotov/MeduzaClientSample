using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeduzaClient.Services.Interfaces;
using Microsoft.Toolkit.Uwp;

namespace MeduzaClient.Services
{
    public class ConnectionService : IConnectionService
    {
        public bool IsConnected => NetworkHelper.Instance.ConnectionInformation.IsInternetAvailable;
    }
}
