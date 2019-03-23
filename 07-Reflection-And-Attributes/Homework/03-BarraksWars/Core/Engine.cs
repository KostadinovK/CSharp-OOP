namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            var commandNameArr = commandName.ToLower().ToCharArray();
            commandNameArr[0] = Char.ToUpper(commandNameArr[0]);

            commandName = string.Join("", commandNameArr) + "Command";

            var commandType = Type.GetType("_03BarracksFactory.Core.Commands." + commandName);

            var command = commandType.GetMethod("Execute");
            var instance = Activator.CreateInstance(commandType, new object[]{ data, repository, unitFactory});
            result = (string)command.Invoke(instance, null);
            return result;
        }
    }
}
