using System;
using System.Text;

// 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
// Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
// Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
// clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.

class GenericList<T>
    where T: IComparable
{
    private const int defaultCapacity = 16;

    private T[] elements;
    private int count = 0;

    public GenericList(int capacity)
    {
        elements = new T[capacity];
    }

    public GenericList(): this(defaultCapacity)
    {
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public void Add(T newElement)
    {
        if (count < elements.Length)
        {
            elements[count] = newElement;
            count++;
        }
        else
        {
            elements = Grow(elements);
            elements[count] = newElement;
            count++;
        }
    }

    public T this[int index]
    {
        get 
        {
            if (0 <= index && index < count)
            {
                return elements[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void RemoveAt(int index)
    {
        if (0 <= index && index < count)
        {
            for (int i = index; i < count; i++)
            {
                if (i+1 < elements.Length)
                {
                    elements[i] = elements[i + 1];
                }
                else
                {
                    elements[i] = default(T);
                }
            }
            count--;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void InsertAt(T newElement, int index)
    {
        if (0 <= index && index < count)
        {
            if (count == elements.Length)
            {
                elements = Grow(elements);
            }
            for (int i = count; i > index; i--)
            {
                elements[i] = elements[i-1];
            }
            elements[index] = newElement;
            count++;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            elements[i] = default(T);
        }
        count = 0;
    }

    public int FindElementByValue(T value)
    {
        int index = Array.IndexOf(elements, value);
        return index;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            result.Append(string.Format("element {0}: {1}", i, elements[i]));
            result.AppendLine();
        }

        return result.ToString();
    }

    // 6. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

    private T[] Grow(T[] fullArray)
    {
        T[] resutArray = new T[fullArray.Length * 2];

        for (int i = 0; i < fullArray.Length; i++)
        {
            resutArray[i] = fullArray[i];
        }

        return resutArray;
    }

    // 7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
    // You may need to add a generic constraints for the type T.

    public T Min<T>() where T: IComparable<T>, IComparable
    {
        dynamic minValue = elements[0];

        for (int i = 0; i < count; i++)
        {
            if (elements[i].CompareTo(minValue)<0)
            {
                minValue = elements[i];
            }
        }

        return minValue;
    }

    public T Max<T>() where T : IComparable<T>, IComparable
    {
        dynamic maxValue = elements[0];

        for (int i = 0; i < count; i++)
        {
            if (elements[i].CompareTo(maxValue)>0)
            {
                maxValue = elements[i];
            }
        }

        return maxValue;
    }
}
