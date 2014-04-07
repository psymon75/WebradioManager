using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebradioManager
{
    public class Bdd
    {
        private BddControls _controls;

        public BddControls Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }
    }
}
