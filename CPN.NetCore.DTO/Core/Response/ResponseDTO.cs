using System;
using System.Collections.Generic;
using System.Text;

namespace CPN.NetCore.DTO.Core.Response
{
    public class ResponseDTO<TData> : BaseDTO<int>
    {
        public bool HasError { get; set; }

        public string Message { get; set; }

        public TData Data { get; set; }

        public ResponseDTO()
        {
            HasError = false;
            Message = string.Empty;
        }

        public ResponseDTO(TData data) : this()
        {
            Data = data;
        }

        public ResponseDTO(bool hasError, string message, TData data = default(TData))
        {
            HasError = HasError;
            Message = message;
            Data = data;
        }
    }
}
