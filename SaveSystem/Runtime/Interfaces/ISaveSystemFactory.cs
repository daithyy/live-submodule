using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIRT.SaveSystem
{
    public interface ISaveSystemFactory
    {
        ISaveFileHandler SaveFileHandler();

        ISerialiser Serialiser();
    }
}
