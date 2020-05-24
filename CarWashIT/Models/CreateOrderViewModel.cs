using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashIT.Models
{
    public class CreateOrderViewModel
    {
        // create client; 
        // create car number;
        // create car;
        // link client and car;
        // link car number and car(one-to-one);
        // create order;
        // link order and car(many-to-many);


        public string Client_FirstName { get; set; }
        public string Client_LastName { get; set; }
        public string Client_Email { get; set; }
        public string Client_PhoneNumber { get; set; }
        
        //Car has CarNumber
        public string CarNum_Type { get; set; }
        public string CarNum_Number { get; set; }

        //Car owned by Client
        public string Car_Mark { get; set; }
        public string Car_Model { get; set; }
        public string Car_Type { get; set; }

        public float Order_Price { get; set; }
        public DateTime Order_CreationDate { get; set; }
        public DateTime Order_DeadLine { get; set; }
    }
}
