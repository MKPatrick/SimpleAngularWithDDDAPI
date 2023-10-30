namespace DDD_API.DTO.BaseResponse
{
	public class BaseResponse<T> : IBaseResponse
	{

		public string Message { get; set; }
		public T Result { get; set; }
	}

	public class BaseResponse : IBaseResponse
	{
		public string Message { get; set; }

	}
}
