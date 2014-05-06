using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ComHub
{
    public interface IFileService
    {
        FileInfo[] CostcoDecryptFilesOrder(IAppSettingsService appSettings);
        FileInfo[] CostcoDecryptFilesConfirm(IAppSettingsService appSettings);

        FileInfo[] CostcoEncryptFilesOrder(IAppSettingsService appSettings);
        FileInfo[] CostcoEncryptFilesConfirm(IAppSettingsService appSettings);

        FileInfo CostcoEncryptFileOrder(string fileName, IAppSettingsService appSettings);
        FileInfo CostcoDecryptFileConfirm(string fileName, IAppSettingsService appSettings);

        OrderMessageBatch CostcoMessageBatchOrder(string fileName, IAppSettingsService appSettings);
        ConfirmMessageBatch CostcoMessageBatchConfirm(string fileName, IAppSettingsService appSettings);
    }

    public class FileService : IFileService
    {
        const string CostcoDecryptExt = "xml";
        const string CostcoDecryptFilePattern = "*." + CostcoDecryptExt;
        const string CostcoEncryptExt = "gpg";
        const string CostcoEncryptFilePattern = "*." + CostcoEncryptExt;

        private FileInfo[] CostcoDecryptFiles(string dirFiles)
        {
            DirectoryInfo d = new DirectoryInfo(dirFiles);
            return d.GetFiles(CostcoDecryptFilePattern);
        }

        public FileInfo[] CostcoDecryptFilesOrder(IAppSettingsService appSettings)
        {
            return CostcoDecryptFiles(appSettings.Costco.Dir.Decrypt.Orders.Path);
        }

        public FileInfo[] CostcoDecryptFilesConfirm(IAppSettingsService appSettings)
        {
            return CostcoDecryptFiles(appSettings.Costco.Dir.Decrypt.Confirms.Path);
        }

        private FileInfo[] CostcoEncryptFiles(string dirFiles)
        {
            DirectoryInfo d = new DirectoryInfo(dirFiles);
            return d.GetFiles(CostcoEncryptFilePattern);
        }

        public FileInfo[] CostcoEncryptFilesOrder(IAppSettingsService appSettings)
        {
            return CostcoEncryptFiles(appSettings.Costco.Dir.Encrypt.Orders.Path);
        }

        public FileInfo[] CostcoEncryptFilesConfirm(IAppSettingsService appSettings)
        {
            return CostcoEncryptFiles(appSettings.Costco.Dir.Encrypt.Confirms.Path);
        }

        public FileInfo CostcoEncryptFileOrder(string fileName, IAppSettingsService appSettings)
        {
            string fileSpec = appSettings.Costco.Dir.Encrypt.Orders.FileSpec(fileName);
            return new FileInfo(fileSpec);
        }

        public FileInfo CostcoDecryptFileConfirm(string fileName, IAppSettingsService appSettings)
        {
            string fileSpec = appSettings.Costco.Dir.Decrypt.Confirms.FileSpec(fileName);
            return new FileInfo(fileSpec);
        }

        public OrderMessageBatch CostcoMessageBatchOrder(string fileName, IAppSettingsService appSettings)
        {
            string filePath = Path.Combine(appSettings.Costco.Dir.Decrypt.Orders.Path, fileName);
            return OrderMessageBatch.Deserialize(filePath);
        }

        public ConfirmMessageBatch CostcoMessageBatchConfirm(string fileName, IAppSettingsService appSettings)
        {
            string filePath = Path.Combine(appSettings.Costco.Dir.Decrypt.Confirms.Path, fileName);
            return ConfirmMessageBatch.Deserialize(filePath);
        }
    }

}
