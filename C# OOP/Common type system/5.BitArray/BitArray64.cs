using System;
using System.Collections;
using System.Collections.Generic;

// 5. Define a class BitArray64 to hold 64 bit values inside an ulong value. 
// Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

class BitArray64 : IEnumerable<int>
{
    private ulong bitHolder;

    public ulong BitHolder { get; private set; }

    public BitArray64(ulong bitHolder)
    {
        this.BitHolder = bitHolder;
    }

    public override bool Equals(object obj)
    {
        BitArray64 passedBitArray = obj as BitArray64;

        if (passedBitArray == null)
        {
            return false;
        }

        if (this.BitHolder != passedBitArray.BitHolder )
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return (int)(this.BitHolder ^ (ulong)int.MaxValue);
    }

    public static bool operator ==(BitArray64 bitArr1, BitArray64 bitArr2)
    {
        return object.Equals(bitArr1, bitArr2);
    }

    public static bool operator !=(BitArray64 bitArr1, BitArray64 bitArr2)
    {
        return !object.Equals(bitArr1, bitArr2);
    }

    public int this[int position]
    {
        get
        {
            if (position < 0 || 63 < position)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return (int)((this.BitHolder >> position) & 1);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 63; i >= 0; i--)
		{
            yield return this[i];
		}
    }
}