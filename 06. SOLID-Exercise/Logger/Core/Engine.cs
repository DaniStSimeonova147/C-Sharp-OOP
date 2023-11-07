using System;

using Logger.Models.Factorys;
using Logger.Models.Contracts;

namespace Logger.Core
{
  public  class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorTokens = command.Split("|");

                string level = errorTokens[0];
                string date = errorTokens[1];
                string message = errorTokens[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
