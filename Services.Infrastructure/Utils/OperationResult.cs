using System;

namespace Services.Infrastructure.Utils
{
    public class OperationResult<TResult>
    {
        public bool IsSuccess { get; }
        
        public string Error { get; }
        
        public TResult Result
        {
            get
            {
                if (IsSuccess)
                {
                    return _result;
                }
                
                throw new Exception(Error);
            }
        }

        private readonly TResult _result;
        
        public OperationResult(TResult result)
        {
            IsSuccess = true;
            _result = result;
        }

        public OperationResult(string error)
        {
            IsSuccess = false;
            Error = error;
        }
    }
}