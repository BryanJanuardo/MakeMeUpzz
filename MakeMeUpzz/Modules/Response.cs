using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Modules
{
    public class Response<T>
    {
        public string message;
        public bool success;
        public T value;

        private Response (string message, bool success, T value){
            this.message = message;
            this.success = success;
            this.value = value;
        }

        public static Response<T> createResponse(string message, bool success, T value) 
        {
            return new Response<T> (message, success, value);
        }
    }
}