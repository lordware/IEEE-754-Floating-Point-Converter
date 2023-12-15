using System;

namespace ConsoleApp3
{
    class IEEE
    {
        public string HexVal { get; private set; } = string.Empty;
        public string Bin { get; private set; } = string.Empty;
        public string EnteredVal { get; set; } = string.Empty;
        public float ActuallyVal { get; private set; }
        public double ErrorCon { get; private set; }
        
        private float toAct()
        {
            float.TryParse(EnteredVal, out float result);
            return result;
        }

        private double calcError()
        {
            var act = $"{ActuallyVal:G17}";
            var actNor = ActuallyVal.ToString();
            actNor += new string('0', act.Length - actNor.Length);
            return Math.Abs(Convert.ToDouble(act) - Convert.ToDouble(actNor));
        }

        private void Converts()
        {
            var bytes = BitConverter.GetBytes(ActuallyVal);
            var i = BitConverter.ToInt32(bytes, 0);
            this.HexVal = "0x" + i.ToString("X8");
            this.Bin = Convert.ToString(i, 2).PadLeft(32, '0');
        }

        public void validateInput() =>
            _ = float.TryParse(EnteredVal, out _) ? true : throw new ArgumentException($"Invalid input: \"{EnteredVal}\"");

        public void Calculate()
        {
            ActuallyVal = toAct();
            ErrorCon = calcError();
            Converts();
        }
    }
}
