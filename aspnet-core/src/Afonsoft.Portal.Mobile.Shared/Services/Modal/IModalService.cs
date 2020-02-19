using System.Threading.Tasks;
using Afonsoft.Portal.Views;
using Xamarin.Forms;

namespace Afonsoft.Portal.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
