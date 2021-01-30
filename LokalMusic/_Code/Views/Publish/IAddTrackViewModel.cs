using LokalMusic._Code.Models.Publish.Album.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Views.Publish
{
    public interface IAddTrackViewModel : IAddTrackModel
    {
    }

    public class HttpPostedFileAbstraction : TagLib.File.IFileAbstraction
    {
        private HttpPostedFile file;

        public HttpPostedFileAbstraction(HttpPostedFile file)
        {
            this.file = file;
        }

        public string Name
        {
            get { return file.FileName; }
        }

        public System.IO.Stream ReadStream
        {
            get { return file.InputStream; }
        }

        public System.IO.Stream WriteStream
        {
            get { throw new Exception("Cannot write to HttpPostedFile"); }
        }

        public void CloseStream(System.IO.Stream stream) { }
    }


}