using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTP;
using System.IO;

namespace ComHub
{
    public interface ICHFtpService
    {
        List<FTPfileInfo> GetCostcoOrders();
        FileInfo DownloadCostoOrder(string fileName, IAppSettingsService appSettings);
    }

    public class CHFtpService : ICHFtpService
    {
        public List<FTPfileInfo> GetCostcoOrders()
        {
            CHFtp costcoFtp = new CHFtp("Costco");
            List<FTPfileInfo> orders = costcoFtp.GetFtpOrders();
            return orders;
        }

        public FileInfo DownloadCostoOrder(string fileName, IAppSettingsService appSettings)
        {
            string encryptedFilePath = Path.Combine(appSettings.Costco.Dir.Encrypt.Orders.Path, fileName);
            CHFtp costcoFtp = new CHFtp("Costco");
            
            costcoFtp.Download(fileName, encryptedFilePath, true);

            return new FileInfo(encryptedFilePath);
        }
    }
}
