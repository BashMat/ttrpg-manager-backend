﻿namespace TtrpgManagerBackend.Dto.User
{
	public class UserInfoDto
	{
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
