using eUseControl.Domain.Enums;
using System.Collections.Generic;

namespace eUseControl.Web.Models
{
    public class UserData
    {
        public string Username { get; set; }

        public URole Level { get; set; }
    }
}