using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    /// <summary>
    /// General Api Response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T> where T : class
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Time { get; set; }
        public T Result { get; set; }

        public ApiResponse(){
            this.Time = DateTime.Now.ToString("o");
        }
    }
}