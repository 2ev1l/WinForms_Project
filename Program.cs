namespace ProcessingTimeCalc
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Configuration.Save(Configuration.Instance);
            Application.Run(new MainForm());
            Configuration.Save(Configuration.Instance);
        }
    }
}