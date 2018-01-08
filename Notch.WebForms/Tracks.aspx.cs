namespace Notch.WebForms
{
    using System;
    using Notch.Domain;
    using Notch.Infrastructure.Business;
    using System.Web.UI.WebControls;

    public partial class Tracks : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTracks();
            }
        }

        private void PopulateTracks()
        {
            using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
            {
                var tracks = trackDm.GetTracks();
                trackList.DataSource = tracks;
                trackList.DataBind();
                trackList.Rows[0].Visible = false;
            }
        }

        protected void trackList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Page.Validate("Add");
                if (Page.IsValid)
                {
                    var fRow = trackList.FooterRow;
                    var txtName = (TextBox)fRow.FindControl("txtName");
                    var txtBPM = (TextBox)fRow.FindControl("txtBPM");
                    using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
                    {
                        trackDm.AddTrack(new Track
                        {
                            Name = txtName.Text.Trim(),
                            BPM = Convert.ToInt16(txtBPM.Text)
                        });
                    }
                    PopulateTracks();
                }
            }
        }

        protected void trackList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            trackList.EditIndex = e.NewEditIndex;
            PopulateTracks();
        }

        protected void trackList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            trackList.EditIndex = -1;
            PopulateTracks();
        }

        protected void trackList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");

            if (!Page.IsValid)
            {
                return;
            }

            var dataKey = trackList.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                int trackId = (int)dataKey["Id"];
                var txtName = (TextBox)trackList.Rows[e.RowIndex].FindControl("txtName");
                var txtBPM = (TextBox)trackList.Rows[e.RowIndex].FindControl("txtBPM");

                using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
                {
                    var track = trackDm.GetTrack(trackId);

                    if (track != null)
                    {
                        track.Name = txtName.Text.Trim();
                        track.BPM = Convert.ToInt16(txtBPM.Text.Trim());
                        trackDm.Update(track);
                    }
               
                    trackList.EditIndex = -1;
                    PopulateTracks();
                }
            }
        }

        protected void trackList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = trackList.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                int trackId = (int)dataKey["Id"];

                using (var trackDm = this.Factory.GetService<ITrackDM>(this.RequestContext))
                {
                    var track = trackDm.GetTrack(trackId);

                    if (track != null)
                    {
                        trackDm.DeleteTrack(trackId);
                        PopulateTracks();
                    }
                }
            }
        }
    }
}