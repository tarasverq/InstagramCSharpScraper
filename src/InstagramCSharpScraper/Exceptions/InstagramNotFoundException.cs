using System;
using System.Runtime.Serialization;

namespace InstagramCSharpScraper.Exceptions
{
    [Serializable]
    public class InstagramNotFoundException : InstagramException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InstagramNotFoundException()
        {
        }

        public InstagramNotFoundException(string message) : base(message)
        {
        }

        public InstagramNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InstagramNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}