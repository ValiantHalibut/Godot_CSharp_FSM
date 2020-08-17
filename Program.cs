using System;

namespace FSMTest
{
    public enum InputValue {
        ZERO,
        ONE,
        NEG_ONE
    }
    public static class Input {
        public static InputValue HVal = InputValue.ZERO;
        public static InputValue VVal = InputValue.ZERO;
        public static InputValue A = InputValue.ZERO;
        public static InputValue B = InputValue.ZERO;
    }
    class Program
    {
        static void Main(string[] args)
        {
            const float UPDATE_RATE = 0.5f;
            Func<Character, bool> tick = (c) => {
                c.HandleInput();
                c.Update(UPDATE_RATE);
                return true;
            };
            Character character = new Character();
            character.Initialize(new IdleState(ref character));

            Console.WriteLine("Starting up...");

            for(int i = 0; i < 10; i++) {
                if(i == 1) Input.HVal = InputValue.ONE;
                if(i == 3) Input.HVal = InputValue.ZERO;
                if(i == 5) Input.HVal = InputValue.NEG_ONE;
                if(i == 7) Input.HVal = InputValue.ZERO;
                tick(character);
            }
            
            Console.WriteLine("Done");
        }
    }
}
