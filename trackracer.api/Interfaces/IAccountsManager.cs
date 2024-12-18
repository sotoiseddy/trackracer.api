using MyModel.Accounts.Registrationclass;

namespace trackracer.Interfaces
{
    public interface IAccountsManager
    {
        public bool RegistrationMethod(RegistrationModel registrationModel);
        public bool Login(string username, string password);
        public RegistrationModel GetUser(string username);
        public List<RegistrationModel> GetAllStudents();
        public bool UpdateUser(RegistrationModel registrationModel);
        public bool ChangePassword(Guid UserID, string currentpassword, string newpassword);
        public List<RegistrationModel> GetAllStudentsData();
    }
    
}
