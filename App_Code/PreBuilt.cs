using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class PreBuilt
    {
        private string _system;
        private string _price;
        private string _id;
        private Component _processorPart;
        private Component _ramPart;
        private Component _hardDrivePart;
        private Component _displayPart;
        private Component _OSPart;
        private int _preBuiltIndex;
        public PreBuilt(string id, Component processor, Component ram, Component hardDrive, Component display, Component os)
        {
            _system = processor.ToString() + "<br />" + ram.ToString() + "<br />" + hardDrive.ToString() +
                      "<br />" + display.ToString() + "<br />" + os.ToString();
            _processorPart = processor;
            _ramPart = ram;
            _hardDrivePart = hardDrive;
            _displayPart = display;
            _OSPart = os;
            _id = id;

            TotalPrice();
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string System
        {
            get
            {
                return _system;
            }

            set
            {
                _system = value;
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

        public Component ProcessorPart
        {
            get
            {
                return _processorPart;
            }

            set
            {
                _processorPart = value;
            }
        }

        public Component RamPart
        {
            get
            {
                return _ramPart;
            }

            set
            {
                _ramPart = value;
            }
        }

        public Component HardDrivePart
        {
            get
            {
                return _hardDrivePart;
            }

            set
            {
                _hardDrivePart = value;
            }
        }

        public Component DisplayPart
        {
            get
            {
                return _displayPart;
            }

            set
            {
                _displayPart = value;
            }
        }

        public Component OSPart
        {
            get
            {
                return _OSPart;
            }

            set
            {
                _OSPart = value;
            }
        }

        public int PreBuiltIndex
        {
            get
            {
                return _preBuiltIndex;
            }

            set
            {
                _preBuiltIndex = value;
            }
        }

        


        public static double GetPrice(string price)
        {
            string tempString = price.Replace("$", "");
            return Convert.ToDouble(tempString);
        }

        public void TotalPrice()
        {
            _price = "$" + (GetPrice(_processorPart.Price) + GetPrice(_ramPart.Price) + GetPrice(_hardDrivePart.Price) + GetPrice(_displayPart.Price) +
                            GetPrice(_OSPart.Price)).ToString();
        }
    }
}