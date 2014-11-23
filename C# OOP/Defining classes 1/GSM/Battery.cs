using System;

namespace GSM
{
    // 3.Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

    public enum BatteryType
    {
       LiIon, NiMH, NiCd
    }

    public class Battery
    {
        private BatteryType model;
        private double? hoursIdle;
        private double? hoursTalk;

        private readonly static Battery iPhone5sBattery = new Battery(BatteryType.LiIon, 250, 10);

        public Battery(BatteryType model) : this(model, null, null)
        {
        }

        public Battery(BatteryType model, double? hoursIdle, double? hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public BatteryType Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hours idle should be positive!");
                }
                this.hoursIdle = value;
            }
        }

        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set 
            {
                if (value <=0)
                {
                    throw new ArgumentException("Hours talk should be positive!");
                }
                this.hoursTalk = value;
            }
        }

        public static Battery IPhone5SBattery
        {
            get { return iPhone5sBattery; }
        }
    }
}
