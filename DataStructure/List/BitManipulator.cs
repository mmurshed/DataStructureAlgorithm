using System;
namespace Vector
{
    public static class BitManipulator
    {
        /*
         * This method shifts 1 over by i bits, creating a value that looks like
         * 00010000. By performing an AND with num, we clear all bits other than
         * the bit at bit i. Finally, we compare that to 0. If that new value is
         * not zero, then bit i must have a 1. Otherwise, bit i is a 0.
        */
        public static int GetBit(int num, int i)
        {
            int mask = 1 << i; // 0001000
            return num & mask;
        }

        /*
         * Set Bit shifts 1 over byi bits, creating a value like 00010000.
         * By performing an OR with num, only the value at bit i will change.
         * All other bits of the mask are zero and will not affect num.
        */
        public static int SetBit(int num, int i)
        {
            int mask = 1 << i; // 0001000
            return num | mask;
        }

        /*
         * This method operates in almost the reverse of SetBit.
         * First, we create a number like 11101111 by creating the reverse of it 
         * (00010000) and negating it. Then, we perform an AND with num. 
         * This will clear the ith bit and leave the remainder unchanged.
        */
        public static int Unset(int num, int i)
        {
            int mask = ~(1 << i); // 11101111
            return num & mask;
        }

        /*
         * To set the ith bit to a value v, we first clear the bit at position i 
         * by using a mask that looks like 11101111. Then, we shift the intended
         * value, v, left by i bits. This will create a number with bit i equal
         * to v and all other bits equal to 0. Finally, we OR these two numbers,
         * updating the ith bit ifv is 1 and leaving it as 0 otherwise.
        */
        public static int Update(int num, int i, bool bitis1)
        {
            // 1. Unset
            int mask = ~(1 << i); // 11101111
            num = num & mask;

            // 2. Set
            int value = bitis1 ? 1 : 0;
            int maskV = value << i; // Either 00000 or 10000

            return num | maskV; // Set
        }

        /*
         * To clear all bits from the most significant bit through i
         * (inclusive), we create a mask with a 1 at the ith bit (1 << i).Then,
         * we subtract 1 from it, giving us a sequence of 0s followed by i 1s.
         * We then AND our number with this mask to leave just the last i bits.
        */
        public static int ClearMSBthroughI(int num, int i)
        {
            int mask = (1 << i) - 1; // 000011
            return num & mask;
        }

        /*
         * To clear all bits from i through 0 (inclusive), we take a sequence of
         * all 1s (which is -1) and shift it left by i + 1bits. This gives us a 
         * sequence of 1s (in the most significant bits) followed by i 0 bits.
        */
        public static int ClearIthrough0(int num, int i)
        {
            int mask = -1 << (i + 1); // 111000
            return num & mask;
        }

        public static string ToString(int num, int pad = 32)
        {
            return Convert.ToString(num, 2).PadLeft(pad, '0');
        }
    }
}