using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.JwtTools
{
    public class JwtConstants
    {
        public const string Issuer="https://localhost/";
        public const string Audience="https://localhost/";
        public const string SecretKey="ahrodcjruscauixa";
        public const int Expires=60;
    }
}
