using System;

namespace Ducks
{
    public class Squeack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeack");
        }
    }
}
