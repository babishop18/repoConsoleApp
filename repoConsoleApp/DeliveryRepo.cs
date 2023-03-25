using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repoConsoleApp
{
    public class DeliveryRepo
    {
        public readonly List<Delivery> _deliveryList = new List<Delivery>();

        //create
        public Boolean AddDelivery (Delivery delivery)
        {
            int startingcount = _deliveryList.Count;
            _deliveryList.Add(delivery);
            bool SuccessfullyAdded = _deliveryList.Count > startingcount;
            return SuccessfullyAdded;
        }

        //read
        public List<Delivery> GetAllDeliveries()
        {
            return _deliveryList;
        }

        public Delivery FindDelByID(int delID)
        {
            foreach (Delivery delivery in _deliveryList)
            {
                if (delivery.DelID == delID)
                {
                    return delivery;
                }
            }
            return default;
        }

        public Delivery FindDelByStat(DelStatus delStat)
        {
            foreach (Delivery delivery in _deliveryList)
            {
                if (delivery.DelStat == delStat)
                {
                    return delivery;
                }
            }
            return default;
        }

        //update
        public bool UpdateDeliveryInfo(int delID, Delivery newDelInfo)
        {
            Delivery oldDelInfo = FindDelByID(delID);
            if (oldDelInfo != default)
            {
                oldDelInfo.CustomerID = newDelInfo.CustomerID;
                oldDelInfo.DelDate = newDelInfo.DelDate;
                oldDelInfo.DelStat = newDelInfo.DelStat;
                oldDelInfo.ItemID = newDelInfo.ItemID;
                oldDelInfo.ItemQuantity = newDelInfo.ItemQuantity;
                return true;
            } 
            else {return false;}
        }
        //delete
        public bool DeleteDelivery(int delID)
        {
            Delivery deleteByDelID = FindDelByID(delID);

            if (deleteByDelID != default)
            {
                bool removeDel = _deliveryList.Remove(deleteByDelID);
                return removeDel;
            }
            else{return false;}
        }

        public bool verifyDelivery(int delID)
        {
            if(FindDelByID(delID) != null)
            {
                return true;
            }
            else {return false;}
        }


    }
}