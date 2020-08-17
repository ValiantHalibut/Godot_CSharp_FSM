using System;

namespace FSMTest
{
    class JumpingState : StateBase
    {
        private float _hangTime = 0.0f;
        public JumpingState(ref Character character) : base(ref character) {}
        public override IState Update(float delta) 
        {
            _hangTime += delta;
            if(_hangTime <= 1.0f) {
                Console.WriteLine("--- Jumping for " + _hangTime.ToString() + " seconds...");
                return this;
            }
            Console.WriteLine("--- Landed after " + _hangTime + " seconds.");
            return null;
        }
    }
}