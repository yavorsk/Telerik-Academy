namespace ComputersBuildingSystem
{
    public class RAMMemory
    {
        internal RAMMemory(int a)
        {
            this.Amount = a;
        }

        public int Value { get; private set; }

        public int Amount { get; private set; }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }

        public int LoadValue()
        {
            return this.Value;
        }
    }
}