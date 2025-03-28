﻿using Microsoft.EntityFrameworkCore;
using RESTWithASP_NET.Data.VO;

namespace RESTWithASP_NET.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        public bool RevokeToken(string username);
    }
}
