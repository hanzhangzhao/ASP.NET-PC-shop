using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class OS : Component
    {
        private string _version;
        public OS(string brand, string version, string price) : base(brand, price)
        {
            _version = version;
        }

        public string Version
        {
            get
            {
                return _version;
            }

            set
            {
                _version = value;
            }
        }

        public bool EqualOS(OS os)
        {
            if (this._brand == os.Brand && this._version == os.Version && this._price == os.Price)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return "<b>Operating System: </b>" + this._version + " / " + "(" + this._price + ")";
        }


        public override string GetGridView()
        {
            return "OSGridView";
        }

        public override string GetSessionName()
        {
            return "OS";
        }
    }
}