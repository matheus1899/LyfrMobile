using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo1_Lyfr.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowMessage(string title,string message,string confirmation);
    }
}
