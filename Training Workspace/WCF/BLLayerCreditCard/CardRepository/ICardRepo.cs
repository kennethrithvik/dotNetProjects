using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayerCreditCard.CardRepository
{
    public interface ICardRepo
    {
        bool ValidateCard(string CCN, DateTime ExpDate);
    }
}
