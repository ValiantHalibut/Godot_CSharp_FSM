using System;

namespace FSMTest
{
    abstract class GroundState : StateBase
    {
        public GroundState(ref Character character) : base(ref character) {}
        public override IState HandleInput()
        {
            if(Input.A == InputValue.ONE)
            {
                Console.WriteLine("'A' Button press sent to " + this.ToString());
                return new JumpingState(ref character);
            }
            return base.HandleInput();
        }
    }
}