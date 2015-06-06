using System;

namespace CultureInstaller.Exceptions
{
    public class CultureIsAlreadyInstalled : Exception
    {
        private readonly string _cultureName;

        public CultureIsAlreadyInstalled()
        { }

        public CultureIsAlreadyInstalled(string cultureName)
        {
            _cultureName = cultureName;
        }

        public override string Message
        {
            get { return string.Format("The culture {0} is already installed.", _cultureName); }
        }
    }
}
