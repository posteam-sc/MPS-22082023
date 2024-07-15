using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public interface ITransformer
    {
        void Save(Transformer tf);
        void UpdateTransformer(Transformer tf);
        void DeleteTransformer(Transformer tf);
    }
}
