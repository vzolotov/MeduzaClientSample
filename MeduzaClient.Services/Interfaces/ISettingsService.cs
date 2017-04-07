using System;
using System.Collections.Generic;
using System.Text;

namespace MeduzaClient.Services.Interfaces
{
    public interface ISettingsService
    {
        Uri Url { get; }
        string SearchUrl { get; }
    }
}
