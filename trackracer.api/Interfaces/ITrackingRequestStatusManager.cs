using trackracer.Models.Accounts;

namespace trackracer.api.Interfaces
{
    public interface ITrackingRequestStatusManager
    {
      
        public bool SaveRequest(TrackingRequestStatusModel request);
        public List<TrackingRequestStatusModel> GetAllRequestStatuses();
        public TrackingRequestStatusModel GetRequestStatusBySenderID(Guid SenderID);
        public TrackingRequestStatusModel GetTrackingRequestByReceiverID(Guid ReceiverID);
       

    }
}
