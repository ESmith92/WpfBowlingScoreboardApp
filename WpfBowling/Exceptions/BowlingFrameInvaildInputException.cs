using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfBowling.Exceptions
{
    internal class BowlingFrameInvaildInputException : Exception
    {
        public string InvalidScoreInput { get; set; }

        public BowlingFrameInvaildInputException(string invalidScoreInput)
        {
            InvalidScoreInput = invalidScoreInput;
        }

        public BowlingFrameInvaildInputException(string? message, string invalidScoreInput) : base(message)
        {
            InvalidScoreInput = invalidScoreInput;
        }

        public BowlingFrameInvaildInputException(string? message, Exception? innerException, string invalidScoreInput) : base(message, innerException)
        {
            InvalidScoreInput = invalidScoreInput;
        }

        protected BowlingFrameInvaildInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
