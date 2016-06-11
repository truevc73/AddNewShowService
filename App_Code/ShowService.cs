using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShowService" in code, svc and config file together.
public class ShowService : IShowService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public int ArtistAdd(ArtistLite a)
    {
        int result = 1;
        Artist art = new Artist();
        art.ArtistName = a.artistName;
        art.ArtistEmail = a.artistEmail;
        art.ArtistWebPage = a.artistWeb;
        art.ArtistDateEntered = a.artistDate;
        try
        {
            db.Artists.Add(art);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            result = 0;
            throw ex;
        }
        return result;

    }

    public void ShowAdd(ShowLite sl)
    {
        Show s = new Show();
        s.ShowName = sl.Title;
        s.ShowDate = sl.Date;
        s.ShowDateEntered = DateTime.Now;
        s.ShowTime = sl.StartTime;
        s.ShowTicketInfo = sl.TicketInfo;
        db.Shows.Add(s);
        db.SaveChanges();
    }

    public void ShowDetailAdd(ShowDetailLite sl)
    {
        var skey = from s in db.Shows
                   where s.ShowName.Equals(sl.Title)
                   select new { s.ShowKey };
        int key = 0;
        foreach (var k in skey)
        {
            key = (int)k.ShowKey;
        }
        ShowDetail sh = new ShowDetail();
        sh.ShowDetailArtistStartTime = sl.StartTime;
        sh.ShowDetailAdditional = sl.Additional;
        sh.ShowKey = key;
        db.ShowDetails.Add(sh);
        db.SaveChanges();
    }

    public int VenueLogin(string password, string username)
    {
        int result = db.usp_venueLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.Venues
                      where k.VenueName.Equals(username)
                      select new { k.VenueKey };

            foreach (var k in key)
            {
                result = (int)k.VenueKey;
            }
        }
        return result;
    }

    public int VenueRegistration(VenueLite v)
    {
        int result = db.usp_RegisterVenue(
            v.VenueName, v.venueAddress, v.venueCity,
             v.venueState, v.venueZipCode, v.venuePhone,
              v.venueEmail, v.venueWebPage, v.venueAgeRestriction,
               v.venueLoginUserName, v.venuLoginPasswordPlain);
        return result;
    }
}
