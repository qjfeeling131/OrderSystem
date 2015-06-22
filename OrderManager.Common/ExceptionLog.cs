using CommonHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Common
{
    public class ExceptionLog
    {
        private static ILogWrap _log;
        static ExceptionLog()
        {
            _log = new LogWrap();
        }

        //异常日记 txt 
        public static void Write(string message)
        {
            if (_log == null)
                _log = new LogWrap();

            _log.Write(message);
        }


        public static void Write2Email(string message, string email)
        {
            _log.Write(message, new LogMediaEnum[] { LogMediaEnum.EMAIL }, new { Email = email });
        }


    }
}
