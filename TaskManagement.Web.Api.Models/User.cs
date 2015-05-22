using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Web.Api.Models
{
    public class User
    {
        private List<Link> _links;

        public long UserId { get; set; }
        private string Username { get; set; }
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
