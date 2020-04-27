using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    class UserRegisterBL : UserApi, IRegister
    {
        public URegisterResp UserRegisterAction(URegisterData user) => RegisterState(user);
    }
}
