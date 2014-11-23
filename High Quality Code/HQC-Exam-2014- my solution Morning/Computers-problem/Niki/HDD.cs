namespace ComputersBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HDD
    {
        private List<HDD> raidArray;
        private int capacity;
        private Dictionary<int, string> data;

        internal HDD(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.IsInRaid = isInRaid;
            this.NumberOfHardDrivesInRaid = hardDrivesInRaid;
            this.raidArray = new List<HDD>();
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>(this.Capacity);
        }

        internal HDD(int capacity, bool isInRaid, int hardDrivesInRaid, List<HDD> hardDrives)
        {
            this.IsInRaid = isInRaid;
            this.NumberOfHardDrivesInRaid = hardDrivesInRaid;
            this.raidArray = new List<HDD>();
            this.raidArray = hardDrives;
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>(this.Capacity);
        }

        public bool IsInRaid { get; private set; }

        public int NumberOfHardDrivesInRaid { get; private set; }

        public int Capacity
        {
            get
            {
                if (this.IsInRaid)
                {
                    if (!this.raidArray.Any())
                    {
                        return 0;
                    }

                    return this.raidArray.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }

            private set
            {
                this.capacity = value;
            }
        }

        public void SaveData(int address, string newData)
        {
            if (this.IsInRaid)
            {
                foreach (var hardDrive in this.raidArray)
                {
                    hardDrive.SaveData(address, newData);
                }
            }
            else
            {
                this.data[address] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.IsInRaid)
            {
                if (!this.raidArray.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.raidArray.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }
    }
}
