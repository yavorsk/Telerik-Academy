using System;
using System.Collections.Generic;

namespace GSM
{

    // 1.Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, 
    // battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). 
    // Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    // 2.Define several constructors for the defined classes that take different sets of 
    // arguments (the full information for the class or part of it). 
    // Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

    public class Phone
    {
        // 6.Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static readonly Phone iPhone5S = new Phone("IPhone5S", "Apple Inc.", null, null, Battery.IPhone5SBattery, Display.IPhone5SDisplay);
        
        private readonly string model;
        private readonly string manufacturer;
        private decimal? price;
        private string owner;
        private Battery batteryType;
        private Display displayType;

        // 9.Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
        private List<Call> callHistory = new List<Call>();

        #region constructors
        public Phone(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        public Phone(string model, string manufacturer, decimal? price, string owner, Battery batteryType, Display displayType)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.batteryType = batteryType;
            this.displayType = displayType;
        }
        #endregion

        #region properties
        // 5.Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
        // Ensure all fields hold correct data at any given time.
        public string Model
        {
            get { return this.model; }
        }
  
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
        }
  
        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price should be non negative!");
                }

                this.price = value;
            }
        }
  
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name should not be empty!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name too short! It should be at least 2 letters");
                }
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Name too long! It should be less than 50 letters");
                }
                foreach (char ch in value)
                {
                    if (!IsLetterAllowedInNames(ch))
                    {
                        throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
                    }
                }

                this.owner = value;
            }
        }
  
        public Battery BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }
  
        public Display DisplayType
        {
            get { return this.displayType; }
            set { this.displayType = value; }
        }
  
        public static Phone IPhone5S
        {
            get
            {
                return iPhone5S;
            }
        }
  
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }
        #endregion

        #region methods
        // 4.Add a method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            return string.Format("Phone model: {0}\nPhone manufacturer: {1}\nPhone price: {2}\nPhone owner: {3}\nBattery type: {4}\nHours idle: {5}\nHours talk: {6}\nDisplay height: {7}\nDisplay width: {8}\nDisplay colours: {9}\n",
                this.model, this.manufacturer, this.price.ToString() ?? "[no price specified]", this.owner ?? "[no owner specified]", this.batteryType.Model, this.batteryType.HoursIdle.ToString() ?? "[No hours Idle specified]",
                this.batteryType.HoursTalk.ToString() ?? "[no hours talk specified]", this.displayType.DisplayHeight.ToString() ?? "[no display height specified]", this.displayType.DisplayWidth.ToString() ?? "[no display width specified]", this.displayType.Colours);
        }

        // 10. Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.

        public void AddCalls(Call currentCall)
        {
            this.callHistory.Add(currentCall);
        }

        public void RemoveCall(int index)
        {
            this.callHistory.RemoveAt(index);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        // 11.Add a method that calculates the total price of the calls in the call history. 
        // Assume the price per minute is fixed and is provided as a parameter.

        public decimal CalculatePriceForHeldCalls(decimal pricePerMinute)
        {
            TimeSpan durationOFCalls = TimeSpan.Zero;

            foreach (var heldCall in CallHistory)
            {
                durationOFCalls += heldCall.DurationOfCall;
            }

            decimal result = (decimal)(durationOFCalls.TotalSeconds / 60.0) * pricePerMinute;
            return result;
        }

        private bool IsLetterAllowedInNames(char ch)
        {
            bool isAllowed =
                        char.IsLetter(ch) || ch == '-' || ch == ' ';
            return isAllowed;
        }
        #endregion
    }
}
