using System;
using System.Collections.Generic;
using System.Text;

namespace CetLibrary.Service
{
    class ServiceProvider
    {
        private static CetUserService _instance = new CetUserService();

        public static CetUserService GetUserService()
        {
            return _instance;
        }
    }
}
