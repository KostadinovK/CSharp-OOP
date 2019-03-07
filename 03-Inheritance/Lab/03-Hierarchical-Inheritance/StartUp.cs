using System;

namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();

            Cat cat = new Cat();

            dog.Eat();
            dog.Bark();

            cat.Eat();
            cat.Meow();
        }
    }
}
