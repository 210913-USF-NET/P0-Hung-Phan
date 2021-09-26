using System;
using Models;
using Serilog;


namespace UI
{
    class Program
    {
        //Implements Start() Method in MainMenu.cs 
        static void Main(string[] args)
        {
        Log. Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("../logs/logs.txt").CreateLogger();

        Log.Information("Application Starting.. ");
        
        new MainMenu().Start();

        Log.Information("Application closing.. ");

        Log.CloseAndFlush();
        
        }
    }
}
