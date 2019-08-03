using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public abstract class Component
    {
        protected string _brand;
        protected string _model;
        protected string _price;

        public Component(string brand, string price)
        {
            _brand = brand;
            _price = price;
        }

        public string Brand
        {
            get
            {
                return _brand;
            }

            set
            {
                _brand = value;
            }
        }

        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public abstract string GetGridView();

        public abstract string GetSessionName();

        public double GetPrice()
        {
            return Convert.ToDouble(this._price.Replace("$", ""));
        }

        protected bool EqualComponent(Component component)
        {
            if (this._brand == component.Brand && this._price == component.Price)
            {
                return true;
            }
            return false;
        }

        public static int GetIndexOfComponent(Component component, List<Component> listOfComponent = null)
        {
            List<Component> displayList;
            if (listOfComponent == null)
            {
                displayList = new List<Component>();
            }
            else
            {
                displayList = listOfComponent;
            }

            for (int i = 0; i < displayList.Count; i++)
            {
                if (displayList[i].EqualComponent(component))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}