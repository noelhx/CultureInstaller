using ManyConsole;
using System;

namespace CultureInstaller.Commands
{
    public class UninstallCultureCommand : ConsoleCommand
    {
        private string _name;

        public UninstallCultureCommand()
        {
            IsCommand("uninstall", "Uninstalls a culture from the current system.");

            HasRequiredOption("n|name=", "", v => _name = v);
        }

        public override int Run(string[] remainingArguments)
        {
            try
            {
                CultureManager.Uninstall(_name);
                Console.WriteLine("The culture {0} has been sucessfully uninstalled.", _name);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Failed to uninstall a culture: {0} doesn't exist on the current system.", _name);
            }
            return 0;
        }
    }
}
