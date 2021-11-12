using System;
using System.Collections.Generic;
using System.Text;
using Day29_Libri.Entities;

namespace Day29_Libri
{
    interface IDbManagerPaperBook : IDbManager<PaperBook>
    {

        public bool ModifyQuantity(int id, int quantity);


    }
}
