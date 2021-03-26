using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Glosserie.API.Exceptions
{
    public class ListNameAlreadyExistsException : Exception
    {
        public string ListName { get; set; }

        public ListNameAlreadyExistsException(string listName)
        {
            ListName = listName;
        }

        public ListNameAlreadyExistsException(string message, string listName) : base(message)
        {
            ListName = listName;
        }

        public ListNameAlreadyExistsException(string message, Exception innerException, string listName) : base(message, innerException)
        {
            ListName = listName;
        }

    }
}
