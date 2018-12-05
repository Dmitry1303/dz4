using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    struct Account
    {
        private string _Login, _Password;

        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public Account(string Login,string Password)
            {
            _Login = Login;
            _Password = Password;
            }

        public override string ToString()
        {
            return $"Логин: {_Login}\nПароль: {_Password}";
        }
    }
}
