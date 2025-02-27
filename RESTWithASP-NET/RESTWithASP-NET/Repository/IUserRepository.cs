﻿using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Model;

namespace RESTWithASP_NET.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User RefreshUserInfo(User user);
    }
}
