using System;

namespace FluentScheduler.Tests.TestApplication
{
    using LLibrary;

    public class ParameterJob : IJob
    {
        public string Parameter { get; set; }

        static ParameterJob()
        {
            L.Register("[parameter]", "Just executed with parameter \"{0}\".");
        }

        public void Execute()
        {
            Console.WriteLine("Hihi");
            L.Log("[parameter]", Parameter);
        }
    }
}
