using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ComHub
{
    public interface IFileService
    {
        FileInfo[] CostcoOrderFiles(IAppSettingsService appSettings);
        OrderMessageBatch CostcoOrderMessageBatch(string fileName, IAppSettingsService appSettings);
    }

    public class FileService : IFileService
    {
        const string CostcoDecryptExt = "xml";

        public FileInfo[] CostcoOrderFiles(IAppSettingsService appSettings)
        {
            string dirFiles = appSettings.Costco.Dir.Decrypt.Orders.Path;

            DirectoryInfo d = new DirectoryInfo(dirFiles);
            return d.GetFiles("*.xml");
        }

        public OrderMessageBatch CostcoOrderMessageBatch(string fileName, IAppSettingsService appSettings)
        {
            string filePath = Path.Combine(appSettings.Costco.Dir.Decrypt.Orders.Path, fileName);
            return OrderMessageBatch.Deserialize(filePath);
        }
    }




}
