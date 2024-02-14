using System;
using Entities.ModelsDto;
using Entities.ModelsDTO;
using Microsoft.AspNetCore.Identity;

namespace Services.Abstract
{
	public interface IAuthenticationService
	{
        //Kullanıcı kayıt imzası
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        //Kullanıcı doğrulama işlemi
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        //Tokken oluşturma metodu
        Task<TokenDto> CreateTokken(bool populateExp);
        //Token Yenileme metodu
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}

