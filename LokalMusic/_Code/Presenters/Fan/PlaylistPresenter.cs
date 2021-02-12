using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Repositories.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Fan
{
    public class PlaylistPresenter
    {
        protected PlaylistRepository repository;

        public PlaylistPresenter()
        {
            this.repository = new PlaylistRepository();
        }

        public List<PlaylistAlbum> GetAlbums()
        {
            List<PlaylistAlbum> albums = new List<PlaylistAlbum>();

            // get purchased albums and get its complete tracks
            albums.AddRange( repository.GetPlaylistAlbum(AuthenticationHelper.UserId) );

            // get individually purchased tracks and get its album information
            List<int> albumIds = repository.GetAlbumIdOfIndividualTracks(AuthenticationHelper.UserId);

            foreach(int albumId in albumIds)
            {
                // scenario: user can buy a track and buy the album later on.
                // there might be a question on why does that happen, its because the album might upload new tracks later on.
                // So if the user bought the album the additional tracks will be automatically owned. 

                // check this scenario above occured, if it does stop it from retrieving the invidually bought track
                if (! albums.Select(m => m.AlbumId).ToList().Contains(albumId))
                    albums.AddRange( repository.GetPlaylistAlbumOfIndividualTracks(AuthenticationHelper.UserId, albumId) );
            }

            return albums;
        }

        public (List<PlaylistAlbum>, List<PlaylistAlbum>) PartitionPlaylist(List<PlaylistAlbum> albums)
        {

            int n = albums.Count;
            int listCount = 2;
            int partitionContentCount = (int)Math.Ceiling((double)n / listCount);

            if (n <= 1)
                return (albums, null);

            List<PlaylistAlbum> temp = new List<PlaylistAlbum>();

            int i = 0;
            for (; i < partitionContentCount; i++)
            {
                temp.Add(albums[i]);
            }

            List<PlaylistAlbum> partition2 = new List<PlaylistAlbum>();

            for (; i < n; i++)
            {
                partition2.Add(albums[i]);
            }

            return (temp, partition2);

        }

    }
}