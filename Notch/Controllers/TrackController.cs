namespace Notch.Controllers
{
    using System.Web.Mvc;
    using Notch.Domain;
    using Notch.Infrastructure.Business;

    public class TrackController : BaseController
    {
        public ActionResult Index()
        {
            using (var trackDM = this.Factory.GetService<ITrackDM>(this.RequestContext))
            {
                var tracks = trackDM.GetTracks();

                return View(tracks);
            }
        }

        public ActionResult AddOrUpdate(Track track)
        {
            using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
            {
                if (ModelState.IsValid)
                {
                    if (track.Id != 0)
                    {
                        trackDm.Update(track);

                        return RedirectToAction("Index");
                    }

                    trackDm.AddTrack(track);
                }

                return PartialView("_CreateEditTrack", track);
            }
        }

        public ActionResult DeleteTrack(int id)
        {
            using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
            {
                trackDm.DeleteTrack(id);

                return RedirectToAction("Index");
            }
        }
    }
}