using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Colegio.InterfacesDeDominio
{
    //Interface Segregation Principle (ISP)
    public interface IEnsenanza
    {
        void Enseñar(int docenteId);
    }
}
