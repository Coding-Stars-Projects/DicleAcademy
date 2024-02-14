using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.Exception;
using Entities.ModelsDto;
using Entities.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Abstract;

namespace Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private User? _user;

        public AuthenticationService(IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        // Yeni bir refresh token oluşturur
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        // Token oluşturma işlemini gerçekleştirir
        public async Task<TokenDto> CreateTokken(bool populateExp)
        {
            // AppSettings'ten konfigürasyon bilgileri alınır
            var signinCredentials = GetSigninCreatials();

            // Kullanıcı için talep edilen rollerin alınması
            var claims = await GetClaims();

            // Token seçeneklerinin oluşturulması
            var tokenOptions = await GeneratedTokenOptions(signinCredentials, claims);

            // Yeni bir refresh token oluşturulur
            var refreshToken = GenerateRefreshToken();
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);

            // Access Token ve Refresh Token DTO'sunun oluşturulması ve döndürülmesi
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        // Token yenileme işlemini gerçekleştirir
        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user is null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                    user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequestException();
            _user = user;
            return await CreateTokken(populateExp: false);
        }

        // Access Token'dan bir Principal nesnesi oluşturur
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            // JwtSettings'ten gizli anahtar alınır
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            // Token doğrulama parametrelerinin belirlenmesi
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            // Token doğrulama işlemi
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            // Algoritma kontrolü
            if (jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token.");
            }
            return principal;
        }

        // Token seçeneklerini oluşturur
        private async Task<SecurityToken> GeneratedTokenOptions(SigningCredentials signinCredentials, Task<List<Claim>> claimsTask)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            // Claims verilerinin alınması (roller)
            var claims = await claimsTask;

            // Token seçeneklerinin oluşturulması
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["ValidateIssuer"],
                audience: jwtSettings["ValidateAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["Expires"])),
                signingCredentials: signinCredentials
            );

            return tokenOptions;
        }

        // Kullanıcıya ait claims verilerini alır (roller)
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,_user.UserName)
        };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        // Şifrelenmiş bir SigningCredentials oluşturur
        private SigningCredentials GetSigninCreatials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = System.Text.Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        // Kullanıcı kaydı işlemini gerçekleştirir
        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);

            return result;
        }

        // Kullanıcıyı doğrular
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
            var result = (_user is not null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));
            if (!result)
            {
                // _logger.LogError("Kullanıcı Adı veya Parolanız hatalı");
                Console.WriteLine("Kullanıcı Adı veya Parolanız hatalı");
            }
            return result;
        }
    }
}

