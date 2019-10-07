using System.Net;

namespace INOM.Entities.Services.Parameters.Dto
{
    public class ResponseDto
    {
        public ResultDto Result { get; set; }
        public ResponseDto()
        {
            this.Result = new ResultDto();
        }
    }

    public class ResultDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public int Time { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
}
