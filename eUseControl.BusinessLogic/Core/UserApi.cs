using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.DBModel.Seed;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Enums;
using eUseControl.Helpers;

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
        internal HttpCookie Cookie(string loginCredenntial)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredenntial)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredenntial))
                    curent = (from e in db.Sessions where e.Username == loginCredenntial select e).FirstOrDefault();
                else
                    curent = (from e in db.Sessions where e.Username == loginCredenntial select e).FirstOrDefault();

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredenntial,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }
        internal URegisterResp RegisterState(UsersDbTable user)
        {
            using (var db = new UserContext())
            {
                user.Level = URole.User;
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
        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UsersDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersDbTable, UserMinimal>());
            var mapper = new Mapper(config);
            //var userminimal = Mapper.Map<UserMinimal>(curentUser);
            var userminimal = mapper.DefaultContext.Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
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
