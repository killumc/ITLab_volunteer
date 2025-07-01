using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
    public class DonationModel
    {
        public int ID { get; set; }
        public int? DonationAmount { get; set; }
        public CardModel Project { get; set; }
    }
}
