using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGen.UAT.Entity
{
    class Grant_Type_Master
    {

        private int _i_ID;
        private string _s_Name;
        private string _s_Description;

        public Grant_Type_Master()
        {
            _i_ID = 0;
            _s_Name = string.Empty;
            _s_Description = string.Empty;

        }

        public int i_ID
        {
            get { return _i_ID; }
            set { _i_ID = value; }
        }
        public string s_Name
        {
            get { return _s_Name; }
            set { _s_Name = value; }
        }
        public string s_Description
        {
            get { return _s_Description; }
            set { _s_Description = value; }
        }


    }
}
