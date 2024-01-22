using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class Result : IResult
    {
        public Result(bool success, List<string> messageList) : this(success)
        {
            MessageList = messageList;
        }
        public Result(bool success,string message): this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }

        public List<string> MessageList { get; }
    }
}