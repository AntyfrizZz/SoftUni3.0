using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    public class GoldenEditionBook : Book
    {

        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public GoldenEditionBook(string author, string title, double price)
            : base(author, title, price)
        {
        }

        #endregion Constructors

        //===========================

        #region Properties

        public override double Price => base.Price * 1.3;

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}
