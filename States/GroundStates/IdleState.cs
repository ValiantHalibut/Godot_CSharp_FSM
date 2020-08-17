using System;

namespace FSMTest
{
    class IdleState : GroundState
    {
        public IdleState(ref Character character) : base(ref character) {}
        public override IState HandleInput()
        {
            if(Input.HVal != InputValue.ZERO)
            {
                Console.WriteLine("'Left/Right' button press sent to " + this.ToString() + ", starting to walk.");
                return new WalkingState(ref character);
            }
            return base.HandleInput();
        }
        public override IState Update(float delta)
        {
            Console.WriteLine("--- Idling...");
            return this;
        }
    }
}