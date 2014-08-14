using System;

namespace PathFinderLibrary
{
    public class PathFinderException : Exception
    {
        /// <summary>
        /// Exception pathfinder
        /// </summary>
        /// <param name="message">Message d'information sur l'exception</param>
        public PathFinderException(string message) : base(message) { }
    }
}
