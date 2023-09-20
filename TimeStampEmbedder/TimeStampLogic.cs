using System.Security.Cryptography.X509Certificates;

namespace TimeStampEmbedder
{
    public class TimestampPdf
    {
        private const string TsaUrl = "http://timestamp.digicert.com";
        private const string Pattern = "YourPattern_{0}.pdf";
        private const string DestinationFolder = @"C:\Users\t-endo\Desktop";


        public void TimestampAndCopyPdf(string selectedFilePath)
        {
            try
            {


                // Create a unique file name
                string newFileName = string.Format(Pattern, DateTime.Now.ToString("yyyyMMddHHmmss"));


                byte[] selectedPdf = File.ReadAllBytes(selectedFilePath);

                // Append the timestamp to the copied PDF
                //byte[] pdfWithTimestamp = AppendTimestampToPdf(selectedPdf, timestamp);

                // Combine the destination folder and the new file name to create the full destination path
                string destinationPath = Path.Combine(DestinationFolder, newFileName);

                File.Copy(selectedFilePath, destinationPath);
                // Save the PDF with the timestamp
                //File.WriteAllBytes(destinationPath, pdfWithTimestamp);

                Console.WriteLine("PDF copied and timestamped successfully.");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //private byte[] GenerateTimestamp()
        //{
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(TsaUrl);
        //        request.Method = "POST";
        //        request.ContentType = "application/timestamp-query";

        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        Stream responseStream = response.GetResponseStream();

        //        TimeStampResponse tspResponse = new TimeStampResponse(responseStream);
        //        responseStream.Close();

        //        if (tspResponse.Status == 0) // 0 indicates success
        //        {
        //            TimeStampToken token = tspResponse.TimeStampToken;
        //            if (token != null)
        //            {
        //                return token.GetEncoded();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error generating timestamp: " + ex.Message);
        //    }

        //    return null;
        //}

        //private byte[] AppendTimestampToPdf(byte[] pdfData, byte[] timestamp)
        //{
        //    try
        //    {
        //        // Create a CMS SignedDataGenerator
        //        CmsSignedDataGenerator generator = new CmsSignedDataGenerator();

        //        // Add the timestamp as an unsigned attribute to the CMS signature
        //        CmsAttributeTableGenerator attrGen = new DefaultSignedAttributeTableGenerator(new AttributeTable(new Dictionary<DerObjectIdentifier, Asn1Encodable>
        //        {
        //    { CmsAttributes.CounterSignature, new DerSet(new DerOctetString(timestamp)) }
        //}));

        //        generator.AddSigner(yourSignerPrivateKey, yourSignerCertificate, CmsSignedDataGenerator.DigestSha256, attrGen);
        //        generator.AddCertificates(new X509Certificate[] { yourSignerCertificate });

        //        // Generate the signed data
        //        CmsSignedData signedData = generator.Generate(new CmsProcessableByteArray(pdfData), true);

        //        // Get the CMS signature bytes (including the PDF and timestamp)
        //        byte[] cmsSignature = signedData.GetEncoded();

        //        return cmsSignature;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error appending timestamp to PDF: " + ex.Message);
        //    }

        //    return null;
        //}
    }
}