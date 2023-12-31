﻿using System;
using System.Collections.Generic;

using Logger.Core;
using Logger.Models.Factorys;
using Logger.Models.Contracts;

namespace Logger
{
    public class StartUp

    {
        public static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Logger.Models.Logger(appenders);

            Engine engine = new Engine(logger);

            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();

                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];
                string levelStr = "INFO";

                if (appenderInfo.Length == 3)
                {
                    levelStr = appenderInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory
                                        .GetAppender(appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                   Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }
    }
}
