using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Model;

namespace RESTWithASP_NET.Repository
{
    public interface IUserRepository
    {
        users ValidateCredentials(UserVO user);

        users ValidateCredentials(string username);

        bool RevokeToken(string username);

        users RefreshUserInfo(users user);
    }
}
