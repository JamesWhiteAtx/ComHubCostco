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
        bool UploadCostcoConfirm(string fileName, IAppSettingsService appSettings);
    }

    public class CHFtpService : ICHFtpService
    {
        public List<FTPfileInfo> GetCostcoOrders()
        {
            CostcoCHFtp costcoFtp = new CostcoCHFtp();
            List<FTPfileInfo> orders = costcoFtp.GetFtpOrders();
            return orders;
        }

        public FileInfo DownloadCostoOrder(string fileName, IAppSettingsService appSettings)
        {
            string encryptedFilePath = Path.Combine(appSettings.Costco.Dir.Encrypt.Orders.Path, fileName);

            CostcoCHFtp costcoFtp = new CostcoCHFtp();
            costcoFtp.DownloadOrder(fileName, encryptedFilePath, true);

            return new FileInfo(encryptedFilePath);
        }

        public bool UploadCostcoConfirm(string fileName, IAppSettingsService appSettings)
        {
            string encryptedFilePath = Path.Combine(appSettings.Costco.Dir.Encrypt.Confirms.Path, fileName);

            CostcoCHFtp costcoFtp = new CostcoCHFtp();
            return costcoFtp.UploadConfirm(encryptedFilePath);
        }
    }
}
