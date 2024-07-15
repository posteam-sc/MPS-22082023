using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class PoleController : IPole
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeletePole(Pole p)
        {
            Pole pole = mBMSEntities.Poles.Where(x => x.PoleID== p.PoleID).SingleOrDefault();
            pole.Active = p.Active;
            pole.DeletedDate = DateTime.Now;
            pole.DeletedUserID = p.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Pole p)
        {
            mBMSEntities.Poles.Add(p);
            mBMSEntities.SaveChanges();
        }

        public void UpdatePole(Pole p)
        {
            Pole pole = mBMSEntities.Poles.Where(x => x.PoleID == p.PoleID).SingleOrDefault();
            pole.PoleNo = p.PoleNo;
            pole.GPSX = p.GPSX;
            pole.GPSY = p.GPSY;
            pole.TransformerID =p.TransformerID;
            pole.UpdatedUserID = p.UpdatedUserID;
            pole.UpdatedDate = DateTime.Now;
            mBMSEntities.Poles.AddOrUpdate(pole); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
