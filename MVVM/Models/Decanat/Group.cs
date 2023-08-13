using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models.Decanat
{
    class Group
    {
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
