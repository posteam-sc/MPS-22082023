using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.BillingController
{
    
    public class BillCode7LayerController : IBillCode7Layer
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteBillCode7Layer(BillCode7Layer bc)
        {
            BillCode7Layer billCode7Layer = mBMSEntities.BillCode7Layer.Where(x => x.BillCode7LayerID == bc.BillCode7LayerID).SingleOrDefault();
            billCode7Layer.Active = bc.Active;
            billCode7Layer.DeletedDate = DateTime.Now;
            billCode7Layer.DeletedUserID = bc.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(BillCode7Layer bc)
        {
            mBMSEntities.BillCode7Layer.Add(bc);
            mBMSEntities.SaveChanges();
        }

        public void UpdateBillCode7Layer(BillCode7Layer bc)
        {
            BillCode7Layer billCode7Layer = mBMSEntities.BillCode7Layer.Where(x => x.BillCode7LayerID == bc.BillCode7LayerID).SingleOrDefault();
            billCode7Layer.BillCode7LayerNo = bc.BillCode7LayerNo;      
            billCode7Layer.BillCodeLayerType = bc.BillCodeLayerType;        
            billCode7Layer.UpdatedUserID = bc.UpdatedUserID;
            billCode7Layer.UpdatedDate = DateTime.Now;
            mBMSEntities.BillCode7Layer.AddOrUpdate(billCode7Layer); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
