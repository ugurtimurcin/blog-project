using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.Utilities.Results.Concrete
{
    public class ErrorResultData<T> : DataResult<T>
    {
        public ErrorResultData(T data, string message) : base(data, false, message)
        {

        }
        public ErrorResultData(T data) : base(data, false)
        {

        }
        public ErrorResultData(string message) : base(default, false, message)
        {

        }
        public ErrorResultData() : base(default, false)
        {

        }
    }
}
