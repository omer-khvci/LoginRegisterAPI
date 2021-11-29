using SayfamaHosgeldinAPI.Entities;
using SayfamaHosgeldinAPI.Entities.DTO;

namespace SayfamaHosgeldinAPI.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(long id);
        bool Add(UserForRegisterDto user, long userId);
        bool Update(long id, UserForLoginDto user);

        bool Delete(long id);

        List<User> GetByUsername(string userName);

    }
}
