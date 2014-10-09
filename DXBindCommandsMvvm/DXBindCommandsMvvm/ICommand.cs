
namespace DXBindCommandsMvvm
{
    interface ICommand
    {
        void Execute();

        bool CanExecute();
    }
}
