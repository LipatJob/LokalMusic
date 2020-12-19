using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class FileSystemHelper
    {
        public static bool TryUploadFile(string filename, string containerName, HttpPostedFile file)
        {
            try
            {
                UploadFile(filename, containerName, file);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void UploadFile(string filename, string containerName, HttpPostedFile file)
        {
            BlobClient blobClient = GetBlobContainerClient(containerName).GetBlobClient(filename);
            using (var inputStream = file.InputStream)
            {
                blobClient.Upload(inputStream);
            }
        }

        private static BlobContainerClient GetBlobContainerClient(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(GetConnectionString());
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);
            return containerClient;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["lokalmusic-fs"];
        }
    }
}