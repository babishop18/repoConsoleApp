using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repoConsoleApp
{
    public enum DelStatus
        {
            Scheduled = 1,
            EnRoute,
            Complete,
            Canceled
        }

    public class Delivery
    {
        
        public int DelID {get; set;}
        //deliveryID

        public DateTime DelDate {get; set;}

        public DelStatus DelStat {get; set;}
    
        public int ItemID {get; set;}

        public int ItemQuantity {get; set;}

        public int CustomerID {get; set;}
        
        public Delivery(){}

        public Delivery(int delID, DateTime delDate, DelStatus delStat, int itemID, int itemQuantity, int customerID)
        {
            DelID=delID;
            DelDate=delDate;
            DelStat=delStat;
            ItemID=itemID;
            ItemQuantity=itemQuantity;
            CustomerID=customerID;
        }


        

    }
}