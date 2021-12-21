using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking
{
    class Person
    {
        public void SetName(string name)
        {
            this._name = name;
        }
        public string GetName()
        {
            return this._name;
        }
        private string _name;
    }
}
