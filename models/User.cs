using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
