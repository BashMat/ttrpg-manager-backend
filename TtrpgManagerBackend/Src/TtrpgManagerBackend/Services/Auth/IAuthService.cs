﻿using TtrpgManagerBackend.Dto.User;

namespace TtrpgManagerBackend.Services.Auth
{
	public interface IAuthService
	{
		public Task<ServiceResponse<UserSignUpResponseDto>> SignUp(UserSignUpRequestDto requestData);

		public Task<ServiceResponse<string>> LogIn(UserLogInRequestDto requestData);
	}
}
