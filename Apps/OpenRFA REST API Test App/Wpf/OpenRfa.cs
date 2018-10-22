using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf
{
    class OpenRfa
    {
        public static string baseUrl = "http://dev.openrfa.org/";
        public static string restEndPoint = "rest/";
        public static string pathGetToken = baseUrl + restEndPoint + "user/token.json";
    }
}
