#nullable enable
namespace MoneyWatcher.Businness.Utils.ResponseMessage
{
    public static class ResponseCreater
    {
        public static ResponseData CreateResponse(bool status,string message, object? data)
        {
            return new ResponseData
            {
                Data = data,
                Message = message,
                Status = status
            };
        }
    }
}