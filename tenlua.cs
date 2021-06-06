using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    public class tenlua : maybay
    {
        public int targetID;
        public tenlua(int id)
        {
            targetID = id;
            _current = new toado(0, 300, 300, 0, 4000, "abc");
            _to = new toado(1, 600, 600, 0, 0, "abc");
            _category = "Tên lửa";
            _color = Color.Yellow;
            ID = 1000;
        }

    }
}
