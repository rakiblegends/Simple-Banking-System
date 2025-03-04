using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingSystem
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public bool IsVoter()
        {
            return Age>18;
        }
    }
}
