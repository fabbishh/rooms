using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class RoomExistsException : Exception
    {
        public RoomExistsException(string name) : base($"Комната с именем {name} уже существует. Перейдите к редактированию.")
        {
            
        }
    }
}
