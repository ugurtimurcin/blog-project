using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.Utilities.Results.Concrete
{
    class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
