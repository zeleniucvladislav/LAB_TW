﻿using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IRegister
    {
        URegisterResp UserRegisterAction(URegisterData user);
    }
}
