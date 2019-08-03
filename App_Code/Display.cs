using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace part4
{
    public class Display : Component
    {

        private string _size;
        private string _resolution;
        private string _responseTime;

        public Display(string brand, string size, string resolution, string responseTime, string price) : base(brand, price)
        {
            _size = size;
            _resolution = resolution;
            _responseTime = responseTime;
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

        public string Resolution
        {
            get
            {
                return _resolution;
            }

            set
            {
                _resolution = value;
            }
        }

        public string ResponseTime
        {
            get
            {
                return _responseTime;
            }

            set
            {
                _responseTime = value;
            }
        }


        public bool EqualComponent(Display d)
        {
            if (base.EqualComponent(d) && this._size == d.Size && this._resolution == d.Resolution && this._responseTime == d.ResponseTime)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "<b>Monitor: </b>" + this._brand + " / " + this._size + " / " + this._resolution + " / " + this._responseTime + " / " + "(" + this._price + ")";
        }

        public override string GetGridView()
        {
            return "DisplayGridView";
        }

        public override string GetSessionName()
        {
            return "display";
        }
    }
}