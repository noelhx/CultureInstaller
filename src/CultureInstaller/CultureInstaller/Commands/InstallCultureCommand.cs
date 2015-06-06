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

            HasRequiredOption("n|name=", "", v => _name = v);
            HasRequiredOption("bc|basedOnCulture=", "", v => _basedOnCulture = v);
            HasOption("br|basedOnRegion=", "", v => _basedOnRegion = v);
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
