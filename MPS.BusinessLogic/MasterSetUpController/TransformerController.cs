using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class TransformerController : ITransformer
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteTransformer(Transformer tf)
        {
            Transformer transformer = mBMSEntities.Transformers.Where(x => x.TransformerID == tf.TransformerID).SingleOrDefault();
            transformer.Active = tf.Active;
            transformer.DeletedDate = DateTime.Now;
            transformer.DeletedUserID = tf.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Transformer tf)
        {
            mBMSEntities.Transformers.Add(tf);
            mBMSEntities.SaveChanges();
        }

        public void UpdateTransformer(Transformer tf)
        {
            Transformer transformer = mBMSEntities.Transformers.Where(x => x.TransformerID == tf.TransformerID).SingleOrDefault();
            transformer.TransformerName = tf.TransformerName;
            transformer.CountryOfOrgin = tf.CountryOfOrgin;
            transformer.EfficiencyLoad = tf.EfficiencyLoad;
            transformer.FullLoadLoss = tf.FullLoadLoss;
            transformer.ImpendanceVoltage = tf.ImpendanceVoltage;
            transformer.NoloadLoss = tf.NoloadLoss;
            transformer.RatedOutputPower = tf.RatedOutputPower;
            transformer.Standard = tf.Standard;
            transformer.TappingRange = tf.TappingRange;
            transformer.QuarterID = tf.QuarterID;
            transformer.Model = tf.Model;
            transformer.TypeofCooling = tf.TypeofCooling;
            transformer.VectorGroup = tf.VectorGroup;
            transformer.VoltageRatio = tf.VoltageRatio;
            transformer.Maker = tf.Maker;
            transformer.Status = tf.Status;
            transformer.UpdatedUserID = tf.UpdatedUserID;
            transformer.UpdateDate =tf.UpdateDate;
            mBMSEntities.Transformers.AddOrUpdate(transformer); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
