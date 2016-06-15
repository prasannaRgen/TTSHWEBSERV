using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGen.UAT.Entity
{
    class Regulatory_Submission_Interval_master
    {
        private int _i_ID;
        private string _s_Name;
        private string _s_Description;
        private int _i_CreatedBy_ID;
        private int _i_ModifyBy_ID;
        private DateTime? _dt_Created_Date;
        private DateTime? _dt_Modify_Date;

        public Regulatory_Submission_Interval_master()
        {
            _i_ID = 0;
            _s_Name = string.Empty;
            _s_Description = string.Empty;
            _i_CreatedBy_ID = 0;
            _i_ModifyBy_ID = 0;
            _dt_Created_Date = null;
            _dt_Modify_Date = null;

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
        public int i_CreatedBy_ID
        {
            get { return _i_CreatedBy_ID; }
            set { _i_CreatedBy_ID = value; }
        }
        public int i_ModifyBy_ID
        {
            get { return _i_ModifyBy_ID; }
            set { _i_ModifyBy_ID = value; }
        }
        public DateTime? dt_Created_Date
        {
            get { return _dt_Created_Date; }
            set { _dt_Created_Date = value; }
        }
        public DateTime? dt_Modify_Date
        {
            get { return _dt_Modify_Date; }
            set { _dt_Modify_Date = value; }
        }


    }
}
