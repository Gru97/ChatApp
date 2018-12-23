using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ViewModel
{
    public class UserAddEditModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public bool agreement { get; set; }

    }
}
