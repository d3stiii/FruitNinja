namespace CodeBase.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}