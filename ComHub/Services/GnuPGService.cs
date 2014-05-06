using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComHub;
using System.IO;

namespace ComHub
{
    public interface IGnuPGService
    {
        FileInfo DecryptCostcoOrderFile(string encryptedFilePath, IAppSettingsService appSettings);
        FileInfo EncryptCostcoConfirmFile(string decryptedFilePath, IAppSettingsService appSettings);
    }

    public class GnuPGService : IGnuPGService
    {
        const string CostcoDecryptExt = "xml";

        public FileInfo DecryptCostcoOrderFile(string encryptedFilePath, IAppSettingsService appSettings)
        {
            string decryptedFileName = GnuPG.DecryptFile(encryptedFilePath, appSettings.Costco.Dir.Decrypt.Orders.Path, CostcoDecryptExt);
            
            return new FileInfo(decryptedFileName);
        }

        public FileInfo EncryptCostcoConfirmFile(string encryptedFilePath, IAppSettingsService appSettings)
        {
            string encryptedFileName = GnuPG.EncryptFile(encryptedFilePath, appSettings.Costco.Dir.Encrypt.Confirms.Path);

            return new FileInfo(encryptedFileName);
        }
    }
}
