using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Security;

namespace TaskManagement.Web.Common.Security
{
    public interface IWebUserSession : IUserSession
    {
        string ApiVersionInUse { get; }
        Uri RequestUri { get; }
        string HttpRequestMethod { get; }
    }
}
