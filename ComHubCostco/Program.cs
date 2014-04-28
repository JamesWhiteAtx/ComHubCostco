using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Xml.Serialization;
using System.Xml;
using FTP;
using ComHub;
using System.Xml.Schema;
using System.Xml.Linq;


namespace ComHubCostco
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDirs();
        }

        static void MakeConfirm()
        {
            string poNumber;
            string vendorsInvoiceNumber;
            string partnerTrxId;
            DateTime partnerTrxDt;

            DateTime shipDate;
            string serviceLevel1;
            string trackingNumber;
            double weight;

            string merchantLineNumber;
            string trxVendorSKU;
            string trxMerchantSKU;
            string trxQty;

            OrderMessageBatch orderBatch = OrderMessageBatch.Deserialize(@"C:\CommerceHub\Order.xml");
            hubOrder order = orderBatch.hubOrder[0];
            
            ConfirmMessageBatch confirmMessage = new ConfirmMessageBatch();
            confirmMessage.CostcoSetup();

            poNumber = order.poNumber; //"00000033568603";
            partnerTrxId = "1234567"; // rw invoice, ship record?
            partnerTrxDt = DateTime.Today; // rw invioce date. ship record date?
            vendorsInvoiceNumber = "1234567"; //rw so, invoice?

            hubConfirm newHubConfirm = confirmMessage.AddHubConfirm(partnerTrxId, partnerTrxDt, poNumber, vendorsInvoiceNumber);

            lineItem lineItem = order.lineItem[0];

            //string packageDetailID = "P001";
            shipDate = DateTime.Today;
            serviceLevel1 = "UPSN_CG"; //Contact CommerceHub to obtain a complete list of codes that apply to this element.
            trackingNumber = "1232123";
            string weightStr = lineItem.poLineData.unitShippingWeight.Text[0];
            Double.TryParse(weightStr, out weight);
            //weight = Convert.ToDecimal(weightStr, new CultureInfo("en-US")); // 25.3;

            packageDetail newackageDetail = newHubConfirm.AddPackageDetail(shipDate, serviceLevel1, trackingNumber, weight);

            merchantLineNumber = lineItem.merchantLineNumber;  // 1;
            trxVendorSKU = lineItem.vendorSKU;                 // "M1034";
            trxMerchantSKU = lineItem.merchantSKU;             //"ZZ123213";
            trxQty = lineItem.qtyOrdered;                      //2;

            hubAction newHubAction = newHubConfirm.AddHubActionShip(merchantLineNumber, trxVendorSKU, trxMerchantSKU, trxQty,
                newackageDetail);

            confirmMessage.ValidateXml();

            Console.WriteLine("fino");
        }

        /*
         * C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC>xsd /classes /language:CS c:\CommerceHub\Order.xsd /outputdir:c:\CommerceHub /namespace:ComHub.Order
         * http://dotnetdust.blogspot.com/2010/05/correctly-creating-classes-using-xsdexe.html 
         * http://stackoverflow.com/questions/751511/validating-an-xml-against-referenced-xsd-in-c-sharp
         */

        static object ObjFromXml(Type type, string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            string xml = doc.InnerXml;

            XmlSerializer serializer = new XmlSerializer(type);
            Object batch = serializer.Deserialize(new StringReader(xml));

            return batch;
        }

        static void ListDirs()
        {
            CHFtp costcoFtp = new CHFtp("Costco");
            costcoFtp.ListFtpOrders();
            Console.WriteLine("press key");
            Console.ReadKey();
            costcoFtp.ListFtpPayments();
            Console.WriteLine("press key");

        }
    }

//static void download()
//        {
//            string hostName = System.Configuration.ConfigurationManager.AppSettings["hostName"];
//            string userName = System.Configuration.ConfigurationManager.AppSettings["userName"];
//            string password = System.Configuration.ConfigurationManager.AppSettings["password"];
//            string dowloadDir = System.Configuration.ConfigurationManager.AppSettings["dowloadDir"];

//            FTPclient ftp = new FTPclient(hostName, userName, password);
//            //ftp.Download("costco/outgoing/orders/source.gpg", "targ.txt", true);

//            FTPdirectory dir = ftp.ListDirectoryDetail();
//            FTPdirectory files = dir.GetFiles("");

//            foreach (var file in files)
//            {
//                if (file.Filename == "Isis_IP_Update_2k.reg")
//                {
//                    Console.WriteLine(file.FullName + " " + file.Permission + " " + file.Filename);
//                    FileInfo targ = new FileInfo(dowloadDir +"\\"+ file.Filename);
//                    ftp.Download(file, targ, true);
//                }
//            }

//            Console.ReadLine();
//        }

//        static void getDirs()
//        {
//            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://ihub1.commercehub.com/costco/outgoing/orders/");
//            ftpRequest.Credentials = new NetworkCredential("roadwirellc", "Hhjf93Nsj8");
//            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
//            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
//            StreamReader streamReader = new StreamReader(response.GetResponseStream());

//            List<string> directories = new List<string>();

//            string line = streamReader.ReadLine();
//            while (!string.IsNullOrEmpty(line))
//            {
//                Console.WriteLine(line);
//                directories.Add(line);
//                line = streamReader.ReadLine();
//            }

//            streamReader.Close();

//            Console.ReadLine();

//========================================

            //// Get the object used to communicate with the server.
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ihub1.commercehub.com/");
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //// This example assumes the FTP site uses anonymous logon.
            //request.Credentials = new NetworkCredential("roadwirellc", "Hhjf93Nsj8");

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //Stream responseStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());

            //Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            //reader.Close();
            //response.Close();
        //}

        //static void WriteFile()
        //{
        //    FileInfo targetFI = new FileInfo(@"C:\gnupg\" + "12345.bumpus.pgp");

        //    using (FileStream fs = targetFI.OpenWrite())
        //    {
        //        try
        //        {
        //            using (StreamWriter fw = new StreamWriter(fs))
        //            {
        //                fw.Write("sadadasdsadsadsadas");
        //            }

        //            fs.Flush();
        //            fs.Close();
        //        }
        //        catch (Exception)
        //        {
        //            //catch error and delete file only partially downloaded
        //            fs.Close();
        //            //delete target file as it's incomplete
        //            targetFI.Delete();
        //            throw;
        //        }
        //    }

        //}

}
