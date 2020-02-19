using System.Threading.Tasks;

namespace Afonsoft.Portal.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}