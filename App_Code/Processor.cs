using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public class Processor : Component
    {

        private string _clock;
        private string _core;

        public Processor(string brand, string model, string clock, string core, string price) : base(brand, price)
        {
            this._model = model;
            this._clock = clock;
            this._core = core;
        }

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
            }
        }
        public string Clock
        {
            get
            {
                return _clock;
            }

            set
            {
                _clock = value;
            }
        }

        public string Core
        {
            get
            {
                return _core;
            }

            set
            {
                _core = value;
            }
        }

        public bool EqualProcessors(Processor p)
        {
            if (base.EqualComponent(p) && this._clock == p.Clock && this._core == p.Core)
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return "<b>Processor: </b>" + this._brand + " / " + this._model + " / " + this._clock + " / " +
                   this._core + " / " + "(" + this._price + ")";
        }

        public override string GetGridView()
        {
            return "ProcessorGridView";
        }

        public override string GetSessionName()
        {
            return "processor";
        }
    }
}