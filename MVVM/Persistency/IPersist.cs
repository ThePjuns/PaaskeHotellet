using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Persistency
{
   public interface IPersist<T>
    {
        void Create(T TObject);

        List<T> Read();

        void Update(T TObject, T OObject);

        void Delete(T TObject);



        

        
    }
}
