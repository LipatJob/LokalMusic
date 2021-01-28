﻿using Azure.Storage.Blobs;
using System;
using System.Configuration;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class FileSystemHelper
    {
        public const string PICTURE_CONTAINER_NAME = "profilepictures";
        public const string ALBUMCOVER_CONTAINER_NAME = "albumcover";
        public const string TRACKS_CONTAINER_NAME = "tracks";
        public const string CLIPS_CONTAINER_NAME = "clips";

        private const string CONNECTION_STRING_NAME = "lokalmusic-fs";

        public static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings[CONNECTION_STRING_NAME];
        }

        /// <summary>
        /// Uploads file to BlobStorage and returns URL of file
        /// </summary>
        /// <param name="filename">The new name of the the after being uploaded</param>
        /// <param name="containerName">The name of the container where the file will be uploaded</param>
        /// <param name="file">Posted file from website</param>
        /// <param name="overwrite">  Will overwrite file in container if true else will throw error on duplicate files</param>
        /// <returns>The URL of the file</returns>
        public static string UploadFile(string filename, string containerName, HttpPostedFile file, bool overwrite = false)
        {
            if (file == null) { throw new ArgumentException("File must not be null"); }

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
    }
}