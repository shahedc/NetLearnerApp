using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetLearner.Portal.Utils
{
    public class LoggingEvents
    {
        public const int ProcessStarted = 1000;

        public const int Step1KickedOff = 1001;
        public const int Step1InProcess = 1002;
        public const int Step1Completed = 1003;

        public const int Step2KickedOff = 2001;
        public const int Step2InProcess = 2002;
        public const int Step2Completed = 2003;

        public const int SomeErrorOccurred = 4000;
        public const int SpecificErrorOccurred = 4001;
    }
}
