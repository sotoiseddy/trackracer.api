using System;
using System.Collections.Generic;
using System.Linq;
using trackracer.DBContext;
using trackracer.Models;
using trackracer.api.Interfaces;
using trackracer.Models.Accounts;

namespace trackracer.Services
{
    public class TrackingRequestStatusManager : ITrackingRequestStatusManager
    {
        private readonly DatabaseContext _db;

        public TrackingRequestStatusManager(DatabaseContext db)
        {
            _db = db;
        }

        // Save (Create) a new tracking request
        public bool SaveRequest(TrackingRequestStatusModel request)
        {
            try
            {
                var info = _db.TrackingRequestStatusTB.FirstOrDefault(tr => tr.ID == request.ID);
                if (info != null)
                {
                    info.Status = request.Status;
                    _db.SaveChanges();
                }
                else
                {
                    _db.TrackingRequestStatusTB.Add(request);
                    _db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Get all tracking requests
        public List<TrackingRequestStatusModel> GetAllRequestStatuses()
        {
            try
            {
                return _db.TrackingRequestStatusTB.ToList();
            }
            catch (Exception)
            {
                return new List<TrackingRequestStatusModel>();
            }
        }

        // Get a tracking request by SenderID
        public TrackingRequestStatusModel GetRequestStatusBySenderID(Guid senderId)
        {
            try
            {
                return _db.TrackingRequestStatusTB.FirstOrDefault(tr => tr.SenderID == senderId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Get a tracking request by ReceiverID
        public List<TrackingRequestStatusModel> GetTrackingRequestByReceiverID(Guid receiverId)
        {

            try
            {
                return _db.TrackingRequestStatusTB.Where(tr => tr.ReceiverID == receiverId).ToList();
            }
            catch (Exception)
            {
                return new List<TrackingRequestStatusModel>();
            }


        }
    }
}
