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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComHubCostco
{
    class Program
    {
        public static void Main(string[] args)
        {
            AppSettingsService app = new AppSettingsService();
            Console.WriteLine(app.Costco.Dir.Encrypt.Orders.FileSpec("file.ext"));
            Console.ReadKey();
        }

        //
        static string GetEncryptDir()
        {
            string merchant = "Costco";
            string dirRoot = System.Configuration.ConfigurationManager.AppSettings["dirRoot" + merchant];
            string dirEncrypt = System.Configuration.ConfigurationManager.AppSettings["dirEncrypt" + merchant];
            string dirConfirms = System.Configuration.ConfigurationManager.AppSettings["dirConfirms" + merchant];
            return Path.Combine(dirRoot, dirEncrypt, dirConfirms);
        }
        static string GetXmlDir()
        {
            string merchant = "Costco";
            string dirRoot = System.Configuration.ConfigurationManager.AppSettings["dirRoot" + merchant];
            string dirDecrypt = System.Configuration.ConfigurationManager.AppSettings["dirDecrypt" + merchant];
            string dirConfirms = System.Configuration.ConfigurationManager.AppSettings["dirConfirms" + merchant];
            return Path.Combine(dirRoot, dirDecrypt, dirConfirms);
        }

        static void ListAppSettins()
        {
            AppSettingsService app = new AppSettingsService();
            Console.WriteLine(app.Costco.Dir.Encrypt.Orders.Path);
            Console.WriteLine(app.Costco.Dir.Encrypt.Confirms.Path);
            Console.WriteLine(app.Costco.Dir.Decrypt.Orders.Path);
            Console.WriteLine(app.Costco.Dir.Decrypt.Confirms.Path);
        
        Console.WriteLine(app.Costco.PartnerID);
        Console.WriteLine(app.Costco.PartyName);
        Console.WriteLine(app.Costco.FtpHost);
        Console.WriteLine(app.Costco.FtpOrders);
        Console.WriteLine(app.Costco.FtpPayment);
        Console.WriteLine(app.Costco.FtpUser);
        Console.WriteLine(app.Costco.FtpPass);
        Console.WriteLine(app.GnupgDir);
        Console.WriteLine(app.Passphrase);
            
            Console.ReadKey();
        }

        static string json = @"{'confId':2,
        'Confirms':[{'ID':1,'PartnerTrxId':'005500','PartnerTrxDt':'wersdf','PoNumber':'00000110421565','VendorsInvoiceNumber':'werwerwer','pkgId':3,
                'Packages':[{'ID':'P_1001','ShipDate':'werwer','ServiceLevel1':'345345','TrackingNumber':'ertert','Weight':'45345','$$hashKey':'007'},
                            {'ID':'P_1002','ShipDate':'werwerwr','ServiceLevel1':'ertert','TrackingNumber':'ert','Weight':'4545','$$hashKey':'009'},
                            {'ID':'P_1003','ShipDate':'34536345','ServiceLevel1':'ert','TrackingNumber':'eryert','Weight':'4545','$$hashKey':'00B'}],
                            'actId':1,
                'Actions':[{'ID':1,'Shipment':true,'MerchantLineNumber':'ssd','TrxVendorSKU':'asd','TrxMerchantSKU':'asd','TrxQty':'4545.6',
                                'PackageIDs':['P_1002','P_1001'],'$$hashKey':'00D'}],'$$hashKey':'005','conf':{'PartnerTrxId':'234234'}},
            {'ID':2,'PartnerTrxId':null,'PartnerTrxDt':'ertertrt','PoNumber':'ertr','VendorsInvoiceNumber':'ertyetr','pkgId':2,
                'Packages':[{'ID':'P_2001','ShipDate':'2233434','ServiceLevel1':'3434','TrackingNumber':'345435','Weight':'345','$$hashKey':'00O'},
                            {'ID':'P_2002','ShipDate':'34545','ServiceLevel1':'3453','TrackingNumber':'34545','Weight':'3455435','$$hashKey':'00Q'}],'actId':2,
                'Actions':[{'ID':1,'Shipment':true,'MerchantLineNumber':'234234','TrxVendorSKU':'fgreter','TrxMerchantSKU':'345345','TrxQty':'121312',
                                'PackageIDs':['P_2002'],'$$hashKey':'00M'},
                            {'ID':2,'Shipment':true,'MerchantLineNumber':'345','TrxVendorSKU':'54365','TrxMerchantSKU':'456456','TrxQty':'456546',
                                'PackageIDs':['P_2001'],'$$hashKey':'00S'}],'$$hashKey':'00J','conf':{'PartnerTrxId':'ert'}}]}";
            //"{\"confId\":2,\"Confirms\":[{\"ID\":1,\"PartnerTrxId\":null,\"PartnerTrxDt\":\"wersdf\",\"PoNumber\":\"00000110421565\",\"VendorsInvoiceNumber\":\"werwerwer\",\"pkgId\":3,\"Packages\":[{\"ID\":\"P_1001\",\"ShipDate\":\"werwer\",\"ServiceLevel1\":\"345345\",\"TrackingNumber\":\"ertert\",\"Weight\":\"45345\",\"$$hashKey\":\"007\"},{\"ID\":\"P_1002\",\"ShipDate\":\"werwerwr\",\"ServiceLevel1\":\"ertert\",\"TrackingNumber\":\"ert\",\"Weight\":\"4545\",\"$$hashKey\":\"009\"},{\"ID\":\"P_1003\",\"ShipDate\":\"34536345\",\"ServiceLevel1\":\"ert\",\"TrackingNumber\":\"eryert\",\"Weight\":\"4545\",\"$$hashKey\":\"00B\"}],\"actId\":1,\"Actions\":[{\"ID\":1,\"Shipment\":true,\"MerchantLineNumber\":\"ssd\",\"TrxVendorSKU\":\"asd\",\"TrxMerchantSKU\":\"asd\",\"TrxQty\":\"4545.6\",\"PackageIDs\":[\"P_1002\",\"P_1001\"],\"$$hashKey\":\"00D\"}],\"$$hashKey\":\"005\",\"conf\":{\"PartnerTrxId\":\"234234\"}},{\"ID\":2,\"PartnerTrxId\":null,\"PartnerTrxDt\":\"ertertrt\",\"PoNumber\":\"ertr\",\"VendorsInvoiceNumber\":\"ertyetr\",\"pkgId\":2,\"Packages\":[{\"ID\":\"P_2001\",\"ShipDate\":\"2233434\",\"ServiceLevel1\":\"3434\",\"TrackingNumber\":\"345435\",\"Weight\":\"345\",\"$$hashKey\":\"00O\"},{\"ID\":\"P_2002\",\"ShipDate\":\"34545\",\"ServiceLevel1\":\"3453\",\"TrackingNumber\":\"34545\",\"Weight\":\"3455435\",\"$$hashKey\":\"00Q\"}],\"actId\":2,\"Actions\":[{\"ID\":1,\"Shipment\":true,\"MerchantLineNumber\":\"234234\",\"TrxVendorSKU\":\"fgreter\",\"TrxMerchantSKU\":\"345345\",\"TrxQty\":\"121312\",\"PackageIDs\":[\"P_2002\"],\"$$hashKey\":\"00M\"},{\"ID\":2,\"Shipment\":true,\"MerchantLineNumber\":\"345\",\"TrxVendorSKU\":\"54365\",\"TrxMerchantSKU\":\"456456\",\"TrxQty\":\"456546\",\"PackageIDs\":[\"P_2001\"],\"$$hashKey\":\"00S\"}],\"$$hashKey\":\"00J\",\"conf\":{\"PartnerTrxId\":\"ert\"}}]};";

        //static void confFromJson()
        //{
        //    JObject batch = JObject.Parse(json);

        //    string poNumber;
        //    string vendorsInvoiceNumber;
        //    string partnerTrxId;
        //    string partnerTrxDt;

        //    hubConfirm newHubConfirm;

        //    string packageID;
        //    string shipDate;
        //    string serviceLevel1;
        //    string trackingNumber;
        //    string weight;

        //    packageDetail newackageDetail;

        //    bool shipment;
        //    string merchantLineNumber;
        //    string trxVendorSKU;
        //    string trxMerchantSKU;
        //    string trxQty;
        //    string[] pkgIDs;

        //    hubAction newHubAction;

        //    ConfirmMessageBatch confirmBatch = new ConfirmMessageBatch();
        //    confirmBatch.CostcoSetup();

        //    var confirms = from c in batch["Confirms"]
        //                   select c;
        //    foreach (var c in confirms)
        //    {
        //        poNumber = (string)c["PoNumber"];
        //        partnerTrxId = (string)c["PartnerTrxId"];
        //        partnerTrxDt = (string)c["PartnerTrxDt"];
        //        vendorsInvoiceNumber = (string)c["VendorsInvoiceNumber"];
                
        //        newHubConfirm = confirmBatch.AddHubConfirm(partnerTrxId, partnerTrxDt, poNumber, vendorsInvoiceNumber);


        //        var packages = from p in c["Packages"]
        //                       select p;
        //        foreach (var p in packages)
        //        {
        //            packageID = (string)p["ID"];
        //            shipDate = (string)p["ShipDate"];
        //            serviceLevel1 = (string)p["ServiceLevel1"];
        //            trackingNumber = (string)p["TrackingNumber"];
        //            weight = (string)p["Weight"];

        //            newackageDetail = newHubConfirm.AddPackageDetail(shipDate, serviceLevel1, trackingNumber, weight);
        //        }
                
        //        var actions = from a in c["Actions"]
        //                      select a;
        //        foreach (var a in actions) 
        //        {
        //            shipment = (bool)a["Shipment"];
        //            merchantLineNumber = (string)a["MerchantLineNumber"];
        //            trxVendorSKU = (string)a["TrxVendorSKU"];
        //            trxMerchantSKU = (string)a["TrxMerchantSKU"];
        //            trxQty = (string)a["TrxQty"];

        //            pkgIDs = (from i in a["PackageIDs"]
        //                      select (string)i).ToArray();

        //            newHubAction = newHubConfirm.AddHubActionShip(merchantLineNumber, trxVendorSKU, trxMerchantSKU, trxQty,
        //                pkgIDs);
        //        }

        //    }
            
        //    confirmBatch.ValidateXml();
        //}

        //static void MakeConfirm()
        //{
        //    string poNumber;
        //    string vendorsInvoiceNumber;
        //    string partnerTrxId;
        //    string partnerTrxDt;

        //    string shipDate;
        //    string serviceLevel1;
        //    string trackingNumber;
        //    string weight;

        //    string merchantLineNumber;
        //    string trxVendorSKU;
        //    string trxMerchantSKU;
        //    string trxQty;

        //    OrderMessageBatch orderBatch = OrderMessageBatch.Deserialize(@"C:\CommerceHub\Order.xml");
        //    hubOrder order = orderBatch.hubOrder[0];
            
        //    ConfirmMessageBatch confirmMessage = new ConfirmMessageBatch();
        //    confirmMessage.CostcoSetup();

        //    poNumber = order.poNumber; //"00000033568603";
        //    partnerTrxId = "1234567"; // rw invoice, ship record?
        //    partnerTrxDt = "20141204"; // rw invioce date. ship record date?
        //    vendorsInvoiceNumber = "1234567"; //rw so, invoice?

        //    hubConfirm newHubConfirm = confirmMessage.AddHubConfirm(partnerTrxId, partnerTrxDt, poNumber, vendorsInvoiceNumber);

        //    lineItem lineItem = order.lineItem[0];

        //    //string packageDetailID = "P001";
        //    shipDate = String.Format("{0:yyyyMMdd}", DateTime.Today);
        //    serviceLevel1 = "UPSN_CG"; //Contact CommerceHub to obtain a complete list of codes that apply to this element.
        //    trackingNumber = "1232123";
        //    weight = lineItem.poLineData.unitShippingWeight.Text[0];

        //    packageDetail newackageDetail = newHubConfirm.AddPackageDetail(shipDate, serviceLevel1, trackingNumber, weight);

        //    merchantLineNumber = lineItem.merchantLineNumber;  // 1;
        //    trxVendorSKU = lineItem.vendorSKU;                 // "M1034";
        //    trxMerchantSKU = lineItem.merchantSKU;             //"ZZ123213";
        //    trxQty = lineItem.qtyOrdered;                      //2;

        //    hubAction newHubAction = newHubConfirm.AddHubActionShip(merchantLineNumber, trxVendorSKU, trxMerchantSKU, trxQty,
        //        newackageDetail.packageDetailID);

        //    confirmMessage.ValidateXml();

        //    Console.WriteLine("fino");
        //}

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
