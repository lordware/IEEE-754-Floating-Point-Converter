using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace ConsoleApp3
{
    class IEEE
    {
        private string _enteredVal;
        private float _actuallyVal;
        private double _errorCon;
        private string _hexVal;
        private string _bin;

        public string HexVal
        {
            get { return _hexVal; }
        }

        public string Bin
        {
            get { return _bin; }
        }

        public string EnteredVal
        {
            get { return _enteredVal; }
            set { _enteredVal = value; }
        }

        public float ActuallyVal
        {
            get { return _actuallyVal; }
        }

        public double ErrorCon
        {
            get { return _errorCon; }
        }
        
        private float toAct()
        {
            return float.Parse(_enteredVal);
        }

        private double calcError()
        {
            var act = string.Format("{0:G17}", _actuallyVal);
            var actNor = _actuallyVal.ToString();
            actNor += new string('0', act.Length - actNor.Length);
            double res = Math.Abs(Convert.ToDouble(act) - Convert.ToDouble(actNor));
            return res;
        }

        private void Converts()
        {
            var bytes = BitConverter.GetBytes(_actuallyVal);
            var i = BitConverter.ToInt32(bytes, 0);
            this._hexVal = "0x" + i.ToString("X8");
            this._bin = Convert.ToString(Convert.ToInt32(_hexVal, 16), 2).PadLeft(32, '0');
        }

        public void validateInput()
        {
            if (float.TryParse(this.EnteredVal, out float x))
            {
                return;
            }
            else
            {
                throw new ArgumentException($"Invalid input \"{this.EnteredVal}\"");
            }
        }

        public void Calculate()
        {
            _actuallyVal = toAct();
            _errorCon = calcError();
            Converts();
        }
    }
}
