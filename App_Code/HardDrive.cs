using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class HardDrive : Component
    {

        private string _type;
        private string _size;

        public HardDrive(string brand, string type, string size, string price) : base(brand, price)
        {
            _type = type;
            _size = size;
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public bool EqualComponent(HardDrive hdd)
        {
            if (base.EqualComponent(hdd) && this._type == hdd.Type &&
                this._size == hdd.Size)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return "<b>Hard Drive: </b>" + this._brand + " / " + this._size + " / " + this._type + " / " + "(" + this._price + ")";
        }

        public override string GetGridView()
        {
            return "HardDriveGridView";
        }


        public override string GetSessionName()
        {
            return "hardDrive";
        }

    }
}