using System;
using System.Collections.Generic;

namespace FSMTest
{
    class Character
    {
        private Stack<IState> _stateStack;
        
        public Character()
        {
            _stateStack = new Stack<IState>();
        }
        public void Initialize(IState state) 
        {
            this._stateStack.Push(state);
        }
        public virtual void HandleInput() 
        {
            checkState(_stateStack.Peek()?.HandleInput());
        }
        public virtual void Update(float delta)
        {
            checkState(_stateStack.Peek()?.Update(delta));
        }
        private void checkState(IState state)
        {
            // If the returned state is the same as the state at the top of the stack,
            // we don't do anything because the state hasn't changed.
            if(state == _stateStack.Peek()) return;

            // If the returned state is null, then we remove it from the stack and
            // transition to the previous state...
            if(state == null) 
            {
                // ... but first we want to make sure there are states to return to.
                // If not, then we just remain in the initial state.
                if(_stateStack.Count <= 1) return;

                // First pop off the top of the stack and run its exit method...
                _stateStack.Pop()?.OnExit();
                // ... then peek at the current state and run its entrance method
                _stateStack.Peek()?.OnEnter();
                return;
            }

            // If the returned state is different than the current state and not null,
            // we consider that a new state and add it to the top of the stack
            _stateStack.Peek()?.OnExit();
            _stateStack.Push(state);
            state.OnEnter();
        }
    }
}