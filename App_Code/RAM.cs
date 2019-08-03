using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class RAM : Component
    {
        private string _speed;
        private string _memoryType;

        public RAM(string brand, string speed, string memoryType, string price) : base(brand, price)
        {
            _speed = speed;
            _memoryType = memoryType;
        }

        public string Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public string MemoryType
        {
            get
            {
                return _memoryType;
            }

            set
            {
                _memoryType = value;
            }
        }

        public bool EqualComponent(RAM r)
        {
            if (base.EqualComponent(r) && this._speed == r.Speed && this._memoryType == r.MemoryType)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "<b>RAM: </b>" + this._brand + " / " + this._speed + " / " + this._memoryType + " / " + "(" + this._price + ")";
        }

        public override string GetGridView()
        {
            return "RAMGridView";
        }

        public override string GetSessionName()
        {
            return "ram";
        }
    }
}