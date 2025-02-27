using RESTWithASP_NET.Data.VO;

namespace RESTWithASP_NET.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
