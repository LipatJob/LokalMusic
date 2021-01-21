using LokalMusic._Code.Presenters.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace LokalMusic.Store
{
    /// <summary>
    /// Summary description for AddToCartServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AddToCartServices : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod]
        public string AddTrackToCart(string trackId)
        {
            int addStatus = AddToCartPresenter.AddTrackToCart(int.Parse(trackId), 0, 0);
            return AddToCartPresenter.GetAddToCartMessage(addStatus);
        }
    }
}
