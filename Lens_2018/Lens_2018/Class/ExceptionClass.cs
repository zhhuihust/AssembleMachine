using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lens_2018
{
    public class RunException : Exception
    {
        private readonly string message;

        public RunException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }

    public class PauseException : Exception
    {
        private readonly string message;

        public PauseException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }


    public class StopException : Exception
    {
        private readonly string message;

        public StopException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }


    public class LoadDataException : Exception
    {
        private readonly string message;

        public LoadDataException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }

    public class RestartException : Exception
    {
        private readonly string message;

        public RestartException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }

    public class XMLException : Exception
    {
        private readonly string message;

        public XMLException(string msg)
            : base(msg)
        {
            this.message = msg;
        }
    }



}
