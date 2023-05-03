namespace Lookup.ViewModel
{
    internal interface IMediator
    {
        void Notify(object recipient, string message);
    }
}
