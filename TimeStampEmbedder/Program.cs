namespace TimeStampEmbedder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TimeStamp Embedder!");
            Thread.Sleep(1000);
            Console.WriteLine("Type pdf path");
            string pdfPath = Console.ReadLine();
            while (!IsPdfFile(pdfPath))
            {
                Console.WriteLine("Please enter valid path to PDF");
                pdfPath = Console.ReadLine();
            }

            TimestampPdf timestampPdf = new TimestampPdf();

            timestampPdf.TimestampAndCopyPdf(pdfPath);

            Console.WriteLine("look your desktop!");


        }

        private static bool IsPdfFile(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return string.Equals(fileExtension, ".pdf", StringComparison.OrdinalIgnoreCase);
        }
    }
}