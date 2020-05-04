using System.Linq;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UsersDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == data.Password);
            }
            if (result == null)
            {
                return new ULoginResp { Status = false, StatusMsg = "The username or password is incorrect" };
            }
            return new ULoginResp { Status = true };
        }

        internal URegisterResp RegisterState(UsersDbTable user)
        {
            using (var db = new UserContext())
            {
                if (db.Users.Any(x => x.Username == user.Username))
                {
                    return new URegisterResp() { Status = false, StatusMsg = "The Username already exist! Please try again." };
                }

                if (db.Users.Any(x => x.Email == user.Email))
                {
                    return new URegisterResp() { Status = false, StatusMsg = "The Email already exist! Please try again." };
                }

                db.Users.Add(user);
                db.SaveChanges();
                return new URegisterResp() { Status = true, StatusMsg = "" };
            }
        }
    }
}
/*
public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable user;

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Username);
            }

            using (var db = new UserContext())
            {
                user = (from u in db.Users where u.Username == data.Username select u).FirstOrDefault();
            }


            if (user != null)
            {

            }

            return new ULoginResp();
        }
    } 
*/
