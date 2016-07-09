using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCouple : Couple
    {
        #region Fields

        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 20;

        private decimal laptopCosts;

        #endregion Fields

        //===================================================================

        #region Constructors

        public YoungCouple(
            decimal salariOne, 
            decimal salariTwo, 
            decimal tvElectricityCosts, 
            decimal fridgeElectricityCosts, 
            decimal laptopCosts) 
            : base(NumberOfRooms, RoomElectricity, salariOne, salariTwo, tvElectricityCosts, fridgeElectricityCosts)
        {
            this.laptopCosts = laptopCosts;
        }

        protected YoungCouple(
            int numberOfRooms, 
            decimal roomElectricity,
            decimal salariOne,
            decimal salariTwo,
            decimal tvElectricityCosts,
            decimal fridgeElectricityCosts,
            decimal laptopCosts)
          : base(numberOfRooms, roomElectricity, salariOne, salariTwo, tvElectricityCosts, fridgeElectricityCosts)
        {
            this.laptopCosts = laptopCosts;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public override decimal Consumption()
        {
            return base.Consumption() + 2 * laptopCosts;
        }

        #endregion Methods
    }
}