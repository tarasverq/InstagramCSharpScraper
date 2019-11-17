using System;
using System.Runtime.Serialization;

namespace InstagramCSharpScraper.Exceptions
{
    [Serializable]
    public class InstagramException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InstagramException()
        {
        }

        public InstagramException(string message) : base(message)
        {
        }

        public InstagramException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InstagramException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}