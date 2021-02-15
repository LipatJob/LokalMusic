using LokalMusic._Code.Repositories.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Finance
{
    public class ArtistPaymentPresenter
    {
        private ArtistPaymentRepository repository;

        public ArtistPaymentPresenter(ArtistPaymentRepository repository)
        {
            this.repository = repository;
        }

        internal DataTable GetRemainingBalances()
        {
            return repository.GetRemainingBalances();
        }

        internal DataTable GetRecentPayments()
        {
            return repository.GetRecentPayments();
        }

        internal void PayArtists()
        {
            repository.PayArtists();
        }
    }
}