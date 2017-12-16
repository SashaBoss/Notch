using Notch.Infrastructure.Business;

namespace Notch.Controllers
{
    using System.Web.Mvc;

    public class TrackController : BaseController
    {
        // GET: Track
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