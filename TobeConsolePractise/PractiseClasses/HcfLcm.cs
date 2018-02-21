namespace TobeConsolePractise
{
    class HcfLcm
    {
        public static void Run()
        {
            int hcf = Hcf(500, 60);
        }

        static int Hcf(int bigger, int smaller)
        {
            if (smaller == 0)
                return bigger;

            return Hcf(smaller, bigger % smaller);
        }

        static int Lcm(int a, int b)
        {
            int a1 = a;
            int b1 = b;

            while (a1 != b1)
            {
                if (a1 < b1)
                    a1 += a;
                else
                    b1 += b;
            }

            return a1;
        }
        
        static int LcmRec(int a, int b)
        {
            return a * b / Hcf(a, b);
        }
    }
}
