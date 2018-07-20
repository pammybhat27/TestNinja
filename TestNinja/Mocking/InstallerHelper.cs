﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader _fileDownloader;
        private string _setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {    
                string url = string.Format("http://example.com/{0}/{1}",
                                    customerName,
                                    installerName);

                _fileDownloader.DownLoadFile(url,_setupDestinationFile);
              
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}