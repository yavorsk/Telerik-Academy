using System;

namespace GSM
{
    // 7. Create a class Call to hold a call performed through a GSM. 
    // It should contain date, time, dialed phone number and duration (in seconds).

    public class Call
    {
        private DateTime timeOfCall;
        private long dialedNumber;
        private TimeSpan durationOfCall;

        public Call(DateTime timeOfCall, long dialedNumber, TimeSpan durationOfCall)
        {
            this.timeOfCall = timeOfCall;
            this.dialedNumber = dialedNumber;
            this.durationOfCall = durationOfCall;
        }

        public DateTime TimeOfCall
        {
            get { return this.timeOfCall; }
            set { this.timeOfCall = value; }
        }

        public long DialedNumber
        {
            get { return this.dialedNumber; }
            set { this.dialedNumber = value; }
        }

        public TimeSpan DurationOfCall
        {
            get { return this.durationOfCall; }
            set { this.durationOfCall = value; }
        }
    }
}
