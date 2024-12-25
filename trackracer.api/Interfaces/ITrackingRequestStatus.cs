using trackracer.Models.Accounts;

namespace trackracer.api.Interfaces
{
    public interface ITrackingRequestStatus
    {
      
        public bool SaveRequest(TrackingRequestStatusModel request);
        public List<TrackingRequestStatusModel> GetAllRequestStatuses();
        public TrackingRequestStatusModel GetRequestStatusBySenderID(Guid SenderID);
        public TrackingRequestStatusModel GetTrackingRequestByReceiverID(Guid ReceiverID);
       

    }
}
