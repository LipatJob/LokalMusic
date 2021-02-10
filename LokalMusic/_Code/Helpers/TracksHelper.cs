using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Models.Store.Details;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using LokalMusic.Store.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class TracksHelper
    {

        public static Track GetTrack(int trackId)
        {
            return ProductDetailsRepository.GetTrackDetails(trackId);
        }

    }
}