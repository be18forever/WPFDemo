using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouGouWebGetData.Common;
namespace YouGouWebGetData.Model
{
   public class LoginModel:NotifyBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value;this.DoNofity(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; this.DoNofity(); }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; this.DoNofity(); }
        }
    }
}
