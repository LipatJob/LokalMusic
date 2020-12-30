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
        public const string PICTURE_CONTAINER_NAME = "profilepictures";

        public static bool TryUploadFile(string filename, string containerName, HttpPostedFile file, out string fileLocation)
        {
            try
            {
                fileLocation = UploadFile(filename, containerName, file);
                return true;
            }
            catch (Exception)
            {
                fileLocation = "";
                return false;
            }
        }

        public static string UploadFile(string filename, string containerName, HttpPostedFile file, bool overwrite = false)
        {
            file.InputStream.Position = 0;
            BlobClient blobClient = GetBlobContainerClient(containerName).GetBlobClient(filename);
            using (var inputStream = file.InputStream)
            {
                blobClient.Upload(inputStream, overwrite: overwrite);
            }
            return blobClient.Uri.AbsoluteUri;
        }

        private static BlobContainerClient GetBlobContainerClient(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(GetConnectionString());
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["lokalmusic-fs"];
        }
    }
}