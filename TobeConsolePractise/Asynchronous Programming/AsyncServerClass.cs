namespace TobeConsolePractise
{
    class AsyncServerClass
    {
        public static void run()
        {
        }

        public enum Choice
        {
            Abia,
            Anambra,
            Lagos,
            Abuja
        }

        public enum Time
        {
            Two = 2,
            Four = 4,
            Six = 6,
            Eight = 8,
            Ten = 10
        }

        public string GetWeather(Choice ch, Time t)
        {
            System.Threading.Thread.Sleep((int)t * 1000);
            string weather;
            switch (ch)
            {
                case Choice.Abia:
                    weather = "Abia= 10 degrees";
                    break;
                case Choice.Abuja:
                    weather = "Abuja= 20 degrees";
                    break;
                case Choice.Anambra:
                    weather = "Anambra= 30 degrees";
                    break;
                case Choice.Lagos:
                    weather = "Lagos= 40 degrees";
                    break;
                default:
                    weather = "Unknown degrees";
                    break;
            }
            return weather;
        }

        public int Add(int a, int b, int delayInSecs)
        {
            System.Threading.Thread.Sleep(delayInSecs * 1000);
            return a + b;
        }
    }

}
