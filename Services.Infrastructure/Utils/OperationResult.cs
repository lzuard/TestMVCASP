using System;

namespace Services.Infrastructure.Utils
{
    public class OperationResult<TResult>
    {
        public class OperationResultError
        {
            public string Message { get; }

            public OperationResultError(string message)
            {
                this.Message = message;
            }
        }
        
        public bool IsSuccess { get; }
        
        public OperationResultError Error { get; }
        
        public TResult Result
        {
            get
            {
                if (IsSuccess)
                {
                    return _result;
                }
                
                throw new Exception(Error.Message);
            }
        }

        private readonly TResult _result;
        
        public OperationResult(TResult result)
        {
            IsSuccess = true;
            _result = result;
        }

        public OperationResult(OperationResultError error)
        {
            IsSuccess = false;
            Error = error;
        }
    }
}