//13.* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

using System;

class MergeSortAlgo
{
    static int[] MergeSort(int[] array)
    {
        if (array.Length == 1)
        {
            return array;
        }

        int middle = array.Length / 2;
        int[] leftArr = new int[middle];
        int[] rightArr = new int[array.Length - middle];
        for (int i = 0; i < middle; i++)
        {
            leftArr[i] = array[i];
        }
        for (int i = 0; i < array.Length - middle; i++)
        {
            rightArr[i] = array[i+middle];
        }
        leftArr = MergeSort(leftArr);
        rightArr = MergeSort(rightArr);

        return MergeArrays(leftArr, rightArr);
    }

    static int[] MergeArrays(int[] leftArr, int[] rightArr)
    {
        int[] mergedArray = new int[leftArr.Length+rightArr.Length];

        int leftCounter = 0;
        int rightCounter = 0;

        for (int i = 0; i < mergedArray.Length; i++)
        {
            if ((leftCounter == leftArr.Length) || ((rightCounter < rightArr.Length) && (rightArr[rightCounter]<= leftArr[leftCounter])))
            {
                mergedArray[i] = rightArr[rightCounter];
                rightCounter++;
            }
            else if ((rightCounter == rightArr.Length) || ((leftCounter < leftArr.Length) && (leftArr[leftCounter]<=rightArr[rightCounter])))
            {
                mergedArray[i] = leftArr[leftCounter];
                leftCounter++;
            }
        }

        return mergedArray;
    }

    static void Main()
    {
        int[] inputArray = { 3, -7, 1, 2, -16, 4, 8, 0, 13, 22, 10, 7, 4, -4, -20 };
        int[] sortedArray = MergeSort(inputArray);

        for (int i = 0; i < sortedArray.Length; i++)
			{
                Console.Write(sortedArray[i] + "  ");
			}
        Console.WriteLine();
    }
}

