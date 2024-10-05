using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Framework
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool IsException { get; set; }
        public string InnerException { get; set; }
        public string Value { get; set; }
        public object Tag { get; set; }
        public string ExRef { get; set; }
        public bool Flag { get; set; }
        public int Code { get; set; }

        /// <summary>
        /// General constructor
        /// Returns IsSuccess = false
        /// </summary>
        public Response() { }

        /// <summary>
        /// Returns IsSuccess = false 
        /// </summary>
        /// <param name="isException"></param>
        /// <param name="message"></param>
        public Response(bool isException, string message)
        {
            IsSuccess = false;
            IsException = isException;
            Message = message;
        }

        /// <summary>
        /// Returns IsSuccess = (code >= 0)
        /// </summary>
        /// <param name="code"></param>
        public Response(int code = 0)
        {
            IsSuccess = code >= 0;
            Code = code;

        }

        /// <summary>
        /// Returns IsSuccess = true
        /// </summary>
        /// <param name="value"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public Response(string value, int code = 0, string message = "")
        {
            IsSuccess = true;
            Value = value;
            Code = code;
            Message = message;

        }


    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
