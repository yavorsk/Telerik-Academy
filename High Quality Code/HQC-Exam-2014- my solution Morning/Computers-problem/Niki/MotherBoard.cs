namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class MotherBoard : IMotherboard
    {
        public MotherBoard(RAMMemory ram, IVideoCard videoCard, Cpu processor)
        {
            this.Memory = ram;
            this.VideoCard = videoCard;
            this.Processor = processor;
        }

        public RAMMemory Memory { get; private set; }

        public IVideoCard VideoCard { get; private set; }

        public Cpu Processor { get; set; }

        public int LoadRamValue()
        {
            return this.Memory.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Memory.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
