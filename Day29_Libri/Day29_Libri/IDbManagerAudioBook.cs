using System;
using System.Collections.Generic;
using System.Text;
using Day29_Libri.Entities;


namespace Day29_Libri
{
    interface IDbManagerAudioBook: IDbManager<AudioBook>
    {

        public bool ModifyDuration(int id, int duration);
    }
}
