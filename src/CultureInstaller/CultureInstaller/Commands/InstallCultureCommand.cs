using CultureInstaller.Exceptions;
using ManyConsole;
using System;

namespace CultureInstaller.Commands
{
    public class InstallCultureCommand : ConsoleCommand
    {
        private string _name;

        private string _basedOnCulture;

        private string _basedOnRegion;

        public InstallCultureCommand()
        {
            IsCommand("install", "Installs a culture on the current system.");

            HasRequiredOption("n|name=", "the name of the culture to install", v => _name = v);
            HasRequiredOption("c|basedOnCulture=", "the base culture for the installable culture", v => _basedOnCulture = v);
            HasOption("r|basedOnRegion=", "the base region for the installable culture (optional)", v => _basedOnRegion = v);
        }

        public override int Run(string[] remainingArguments)
        {
            try
            {
                CultureManager.Install(_name, _basedOnCulture, _basedOnRegion);
                Console.WriteLine("The culture {0} has been sucessfully installed.", _name);
            }
            catch (CultureIsAlreadyInstalled)
            {
                Console.WriteLine("Failed to install a culture: {0} is already installed.", _name);
            }
            return 0;
        }
    }
}
