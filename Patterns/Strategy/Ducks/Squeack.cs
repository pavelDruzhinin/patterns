using System;
using Strategy.Ducks.Contracts;

namespace Strategy.Ducks
{
    public class Squeack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeack");
        }
    }
}
