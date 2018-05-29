using System;
using System.Text;

namespace DataStructure.Vector
{
    public class BitVector
    {
        public int Size { get; }

        public int[] Vector { get; }
        private const int Unit = 8 * sizeof(int);

        public BitVector(int size)
        {
            Size = size;
            Vector = new int[Size / Unit];
        }

        private Tuple<int, int> GetLocation(int n)
        {
            if(n >= Size)
            {
                throw new ArgumentException("Out of range.");
            }
            int loc = n / Unit;
            int bit = n % Unit;

            return new Tuple<int, int>(loc, bit);
        }

        /*
         * This method shifts 1 over by i bits, creating a value that looks like
         * 00010000. By performing an AND with num, we clear all bits other than
         * the bit at bit i. Finally, we compare that to 0. If that new value is
         * not zero, then bit i must have a 1. Otherwise, biti is a 0.
        */
        public bool Get(int n)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            int num = Vector[loc];

            int mask = 1 << bit; // 0001000

            return (num & mask) != 0;
        }


        /*
         * Set Bit shifts 1 over byi bits, creating a value like 00010000.
         * By performing an OR with num, only the value at bit i will change.
         * All other bits of the mask are zero and will not affect num.
        */
        public void Set(int n)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            int num = Vector[loc];

            int mask = 1 << bit; // 0001000

            Vector[loc] = num | mask;
        }

        /*
         * This method operates in almost the reverse of setBit. First, we 
         * create a number like 11101111 by creating the reverse of it 
         * (00010000) and negating it. Then, we perform an AND with num. 
         * This will clear the ith bit and leave the remainder unchanged.
        */
        public void Unset(int n)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            int num = Vector[loc];

            int mask = ~(1 << bit); // 11101111

            Vector[loc] = num & mask;
        }

        /*
         * To set the ith bit to a value v, we first clear the bit at position i 
         * by using a mask that looks like 11101111. Then, we shift the intended
         * value, v, left by i bits. This will create a number with bit i equal
         * to v and all other bits equal to 0. Finally, we OR these two numbers,
         * updating the ith bit ifv is 1 and leaving it as 0 otherwise.
        */
        public void Update(int n, bool bitis1)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            int num = Vector[loc];

            // 1. Unset
            int mask = ~(1 << bit); // 11101111
            num = num & mask;

            // 2. Set
            int value = bitis1 ? 1 : 0;
            int maskV = value << bit; // Either 00000 or 10000

            Vector[loc] = num | maskV; // Set
        }

        /*
         * Reset everything to zero.
        */
        public void Clear()
        {
            for (int i = 0; i < Vector.Length; i++)
                Vector[i] = 0;
        }

        /*
         * To clear all bits from the most significant bit through i
         * (inclusive), we create a mask with a 1 at the ith bit (1 << i).Then,
         * we subtract 1 from it, giving us a sequence of 0s followed by i 1s.
         * We then AND our number with this mask to leave just the last i bits.
        */
        public void ClearMSBthroughI(int n)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            for (int i = Vector.Length - 1; i > loc; i--)
                Vector[i] = 0;

            int num = Vector[loc];

            int mask = (1 << bit) - 1; // 000011

            Vector[loc] = num & mask;
        }

        /*
         * To clear all bits from i through 0 (inclusive), we take a sequence of
         * all 1s (which is -1) and shift it left by i + 1bits. This gives us a 
         * sequence of 1s (in the most significant bits) followed by i 0 bits.
        */
        public void ClearIthrough0(int n)
        {
            var locB = GetLocation(n);
            int loc = locB.Item1;
            int bit = locB.Item2;

            for (int i = loc - 1; i > 0; i--)
                Vector[i] = 0;

            int num = Vector[loc];

            int mask = (-1 << (bit + 1)); // 111000
            Vector[loc] = num & mask;
        }

        public override string ToString()
        {
            StringBuilder num = new StringBuilder(Vector.Length * Unit + 1);
            for (int i = Vector.Length - 1; i >= 0; i--)
            {
                num.Append(Convert.ToString(Vector[i], 2).PadLeft(Unit, '0'));
            }
            return num.ToString();
        }
    }
}
