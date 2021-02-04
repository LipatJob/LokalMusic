using LokalMusic._Code.Helpers;

namespace LokalMusic._Code.Models.Fan
{
    public class CollectionItem
    {
        public string CoverLink { get; set; }
        public string ProductName { get; set; }
        public string ArtistName { get; set; }
        public string ProductType { get; set; }
        public int ArtistId { get; set; }
        public int TrackId { get; set; }
        public int AlbumId { get; set; }

        public string GetUrl
        {
            get
            {
                string url;
                if (ProductType.ToLower() == "album")
                {
                    url = $"/Store/{ArtistId}/{AlbumId}";
                }
                else
                {
                    url = $"/Store/{ArtistId}/{AlbumId}/{TrackId}";
                }
                return NavigationHelper.CreateAbsoluteUrl(url);
            }
        }
    }
}