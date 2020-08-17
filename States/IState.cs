using System;

namespace FSMTest
{
    interface IState
    {
        void OnEnter();
        void OnExit();
        IState Update(float delta);
        IState HandleInput();
    }
}