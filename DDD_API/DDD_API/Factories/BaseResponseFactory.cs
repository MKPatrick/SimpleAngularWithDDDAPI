using DDD_API.DTO.BaseResponse;

namespace DDD_API.Factories
{
	public static class BaseResponseFactory
	{
		public static IBaseResponse Create<AddiontalResponseInformation>(AddiontalResponseInformation additionalInfo)
		{
			var response = new BaseResponse<AddiontalResponseInformation>();
			response.Result = additionalInfo;
			return response;
		}

		public static IBaseResponse Create()
		{
			IBaseResponse response = new BaseResponse();
			return response;
		}

	}
}
