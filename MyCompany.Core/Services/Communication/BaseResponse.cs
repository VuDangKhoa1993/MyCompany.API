using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.API.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }
   
        /// <summary>
        /// Create a success response 
        /// </summary>
        /// <param name="resource">saved resource</param>
        public BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        /// <summary>
        /// Create a failed response
        /// </summary>
        /// <param name="message">error message</param>
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
