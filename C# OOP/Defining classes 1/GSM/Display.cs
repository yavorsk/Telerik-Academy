using System;

namespace GSM
{
    public class Display
    {
        private int? displayHeight;
        private int? displayWidth;
        private long? colours;

        private readonly static Display iPhone5sDisplay = new Display(1136, 640, 16000000);

        public Display():this(null, null, 16000000)
        {
        }

        public Display(int? displayHeight, int? displayWidth, long colours)
        {
            this.displayHeight = displayHeight;
            this.displayWidth = displayWidth;
            this.colours = colours;
        }

        public int? DisplayHeight
        {
            get { return this.displayHeight; }
            set 
            {
                if (value <= 100)
                {
                    throw new ArgumentException("Display height is too small! Display height should be more than 100 pixels!");
                }

                this.displayHeight = value;
            }
        }

        public int? DisplayWidth
        {
            get { return this.displayWidth; }
            set
            {
                if (value <= 100)
                {
                    throw new ArgumentException("Display width is too small! Display width should be more than 100 pixels!");
                }

                this.displayWidth = value;
            }
        }

        public long? Colours
        {
            get { return this.colours; }
            set 
            {
                if (value < 2)
                {
                    throw new ArgumentException("Number of colors should be more than 1!");
                }

                this.colours = value;
            }
        }

        public static Display IPhone5SDisplay
        {
            get { return iPhone5sDisplay; }
        }
    }
}
