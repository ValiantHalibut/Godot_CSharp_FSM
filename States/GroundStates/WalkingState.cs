using System;

namespace FSMTest
{
    class WalkingState : GroundState 
    {
        private float _walkTime = 0.0f;
        public WalkingState(ref Character character) : base(ref character) {}
        public override IState HandleInput()
        {
            if(Input.HVal == InputValue.ZERO)
            {
                Console.WriteLine("'Left/Right' button off sent to " + this.ToString() + ", stopping walk.");
                return null;
            }
            return base.HandleInput();
        }
        public override IState Update(float delta)
        {
            _walkTime += delta;
            Console.WriteLine("--- Walking for " + _walkTime + " seconds...");
            return this;
        }
    }
}