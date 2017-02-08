using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IValueCalculator calc;

        private Product[] products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        public HomeController(IValueCalculator calcParam, IValueCalculator calc2)
        {
            calc = calcParam;
        }
        public ActionResult Index()
        {
            /* (Listing 6-13 note) The following statements were removed during refactoring
            // create an instance of a Ninject kernel
            IKernel ninjectKernel = new StandardKernel();
            // configure implementation
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // use Ninject to create an object
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            */

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}