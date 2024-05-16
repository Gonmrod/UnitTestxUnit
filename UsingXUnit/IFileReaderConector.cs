using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingXUnit
{
    public interface IFileReaderConector
    {
        string ReadString(string fileName);
    }
}
