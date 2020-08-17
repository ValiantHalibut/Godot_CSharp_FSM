using System;

namespace FSMTest
{
    abstract class StateBase : IState
    {
        internal Character character;
        public StateBase(ref Character character) {
            this.character = character;
        }
        public override string ToString() { return this.GetType().Name; }
        public virtual IState HandleInput()
        {
            Console.WriteLine("No inputs handled by " + this.ToString());
            return this;
        }

        public virtual void OnEnter()
        {
            Console.WriteLine("Entering " + this.ToString());
        }

        public virtual void OnExit()
        {
            Console.WriteLine("Exiting " + this.ToString());
        }

        public virtual IState Update(float delta)
        {
            Console.WriteLine("Updating " + this.ToString());
            return null;
        }
    }
}