﻿using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public IRegister GetRegisterBL()
        {
            return new UserRegisterBL();
        }
    }
}
