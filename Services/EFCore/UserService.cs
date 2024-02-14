using System;
using Services.Abstract;

namespace Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repository, IMapper mapper)
        {
            // Repository yöneticisi ve AutoMapper bağımlılıklarını enjekte et
            _repository = repository;
            _mapper = mapper;
        }

        // Yeni bir kullanıcı oluştur
        public async Task CreateUser(UserForRegistrationDto userDto)
        {
            var user = _mapper.Map<User>(userDto); // DTO'yu User nesnesine eşle
            await _repository.User.GenericCreate(user); // Kullanıcıyı oluştur
            return user;
        }

        // Kullanıcıyı sil
        public async Task DeleteUser(int id)
        {
            var user = _repository.User.GetUser(id); // ID'ye göre kullanıcıyı al
            if (user != null)
            {
                _repository.User.GenericDelete(user); // Kullanıcıyı sil
                _repository.Save(); // Değişiklikleri kaydet
            }
        }

        // Tüm kullanıcıları getir
        public async Task<List<UserForRegistrationDto>> GetAllUsers()
        {
            var users = await _repository.User.GenericRead(); // Tüm kullanıcıları al
            return users.ToList(); // Liste olarak döndür
        }

        // Belirli bir ID'ye sahip kullanıcıyı getir
        public async Task<UserForRegistrationDto> GetUserById(int Id)
        {
            var user = _repository.User.GetUser(id); // ID'ye göre kullanıcıyı al
            return user;
        }

        // Kullanıcı bilgilerini güncelle
        public async Task UpdateUser(UserForRegistrationDto userDto)
        {
            var user = _repository.User.GetUser(id); // ID'ye göre kullanıcıyı al
            if (user != null)
            {
                _mapper.Map<UserForRegistrationDto>(userForRegistrationDto); // DTO'yu kullanıcıya eşle
                _repository.Save(); // Değişiklikleri kaydet
            }
        }
    }

}

