using Xamarin.Forms.Internals;

namespace Afonsoft.Portal.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}