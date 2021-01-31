using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Cart;
using LokalMusic._Code.Presenters.Cart;
using LokalMusic._Code.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public string AddProductToCart(string productId)
        {
            // add try catch
            int addToCartStatus = AddToCartHelper.AddProductToCart(int.Parse(productId));
            return AddToCartHelper.GetAddToCartMessage(addToCartStatus);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public string ProcessCheckout(object forCheckout, string paymentProvider)
        {
            List<CheckoutItem> cart = new List<CheckoutItem>();

            // format ["["#", "", "#", ""]", "[#, "", #]", ""]
            string unparsedCartItems = forCheckout.ToString();

            // split product groups 
            string[] itemGroups = Regex.Split(unparsedCartItems, @",(?=[^\]]*(?:\[|$))");

            foreach (string item in itemGroups)
            {
                // split individual groups to get individual data
                string[] tempItems = Regex.Split(item, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                // clean each data
                for (int i = 0; i < tempItems.Length; i++)
                {
                    tempItems[i] = tempItems[i].Replace(']', ' ').Replace('[', ' ').Replace('"', ' ').Trim();
                }

                CheckoutItem cartItem = new CheckoutItem(
                    int.Parse(tempItems[0]),
                    tempItems[1].ToString(),
                    Decimal.Round(Decimal.Parse(tempItems[2].ToString()), 2),
                    tempItems[3].ToString());

                cart.Add(cartItem);
            }

            bool status = new CartPresenter(new CartRepository()).ProcessCustomerOrder(cart, paymentProvider);

            return status ? "Your order and payment has been processed successfully. You can view product in your collections." : "Something went wrong. Try again later.";
        }
    }
}
