using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace ComHub
{
    public static class GnuPG
    {
        public static string DecryptFile(string encryptedFilePath, string ext)
        {
            FileInfo info = new FileInfo(encryptedFilePath);
            string encryptedFileName = info.FullName;

            string decryptedFileName = Path.ChangeExtension(encryptedFilePath, "ext");

            //string decryptedFileName = @"c:\gnupg\result3.txt"; //info.FullName.Substring(0, info.FullName.LastIndexOf('.')) + "Dec.TXT";


            string password = System.Configuration.ConfigurationManager.AppSettings["passphrase"];
            //"$aur0m0n"; 

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");

            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            psi.WorkingDirectory = System.Configuration.ConfigurationManager.AppSettings["gnupgDir"];

            System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);

            string sCommandLine = @"echo " + password + "|gpg.exe --passphrase-fd 0 --batch --verbose --yes --output " + decryptedFileName + @" --decrypt """ + encryptedFileName;

            //echo $aur0m0n|gpg.exe --passphrase-fd 0 --output result2.txt --decrypt test.gpg

            process.StandardInput.WriteLine(sCommandLine);
            process.StandardInput.Flush();
            process.StandardInput.Close();

            process.WaitForExit();

            string result = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.Close();

            return decryptedFileName;
        }   
    }
}
