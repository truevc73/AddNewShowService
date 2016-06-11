using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShowService" in both code and config file together.
[ServiceContract]
public interface IShowService
{
    [OperationContract]
    int VenueLogin(string password, string username);
    [OperationContract]
    int VenueRegistration(VenueLite v);
    [OperationContract]
    int ArtistAdd(ArtistLite a);
    [OperationContract]
    void ShowAdd(ShowLite sl);
    [OperationContract]
    void ShowDetailAdd(ShowDetailLite sl);

}
[DataContract]
public class ShowLite
{
    [DataMember]
    public string Title { get; set; }
    [DataMember]
    public DateTime Date { get; set; }
    [DataMember]
    public string Artist { get; set; }
    [DataMember]
    public TimeSpan StartTime { get; set; }
    [DataMember]
    public string TicketInfo { get; set; }

}

[DataContract]
public class ShowDetailLite
{
    [DataMember]
    public string Title { get; set; }
    [DataMember]
    public string Additional { get; set; }
    [DataMember]
    public TimeSpan StartTime { get; set; }

}

[DataContract]
public class ArtistLite
{
    [DataMember]
    public string artistName { set; get; }
    [DataMember]
    public string artistEmail { set; get; }
    [DataMember]
    public string artistWeb { set; get; }
    [DataMember]
    public DateTime artistDate { set; get; }
}

[DataContract]
public class VenueLite
{
    [DataMember]
    public string VenueName { set; get; }
    [DataMember]
    public string venueAddress { set; get; }
    [DataMember]
    public string venueCity { set; get; }
    [DataMember]
    public string venueState { set; get; }
    [DataMember]
    public string venueZipCode { set; get; }
    [DataMember]
    public string venuePhone { set; get; }
    [DataMember]
    public string venueEmail { set; get; }
    [DataMember]
    public string venueWebPage { set; get; }
    [DataMember]
    public int venueAgeRestriction { set; get; }
    [DataMember]
    public string venueLoginUserName { set; get; }
    [DataMember]
    public string venuLoginPasswordPlain { set; get; }
}
