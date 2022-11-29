using BlogApp.Shared.Utilities.Result.Abstract;
using BlogApp.Shared.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Utilities.Result.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus) 
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultstatus , string message)
        {
            ResultStatus = resultstatus;
            Message = message;
               
        }

        public Result(ResultStatus resultstatus, string message, Exception exception)
        {
            ResultStatus = resultstatus;
            Message = message;
            Exception = exception;

        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}


//new Result(ResultStatus.Success)
