namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public interface IMotherboard
    {
        /// <summary>
        /// Loads the integer value which is held in the RAM Memory.
        /// </summary>
        /// <returns>Return the integer value that's held in the RAM Memory</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves an integer value in the RAM Memory.
        /// </summary>
        /// <param name="value">The value that is to be saved.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Passes the <paramref name="text"/> given as a parameter to the Video Card, which processes it
        /// </summary>
        /// <param name="text">the string to be visualized</param>
        void DrawOnVideoCard(string text);
    }
}
