namespace Notch.Controllers
{
    using System.Web.Mvc;
    using Notch.Infrastructure.Business;

    public class TrackKnockoutController : BaseController
    {
        public ActionResult Index()
        {
            using (var trackDM = this.Factory.GetService<ITrackDM>(this.RequestContext))
            {
                var tracks = trackDM.GetTracks();

                return View(tracks);
            }
        }
    }
}