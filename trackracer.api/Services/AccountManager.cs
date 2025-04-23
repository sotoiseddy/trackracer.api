using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using trackracer.DBContext;
using trackracer.Interfaces;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using trackracer.Models.Accounts;

namespace trackracer.Services
{
    public class AccountManager : IAccountsManager
    {
        //Test
        private const string Salt = "iIjG8DGesRt4aM9KUYh+AQ==";
        DatabaseContext _db = new();
        public AccountManager(DatabaseContext db)
        {
            _db = db;
        }

        //public bool RegistrationMethod(RegistrationModel registrationModel)
        //{
        //    try
        //    {
        //        //1 for student, 2 for teacher,3 for admin
        //        registrationModel.Type =1;
        //        var isEmailExsit = _db.RegistrationModelTB.Where(x => x.UserName.ToLower() == registrationModel.UserName.ToLower()).ToList();
        //        if (isEmailExsit.Count() > 0)
        //        {
        //            return false;
        //        };
        //        // Compute the hash of the password with the hardcoded salt
        //        string passwordHash = ComputeHash(registrationModel.Password, Salt);

        //        // Update the UserModel properties with hashed password and salt
        //        registrationModel.Password = passwordHash;

        //        // Add the user to the database and save changes
        //        _db.RegistrationModelTB.Add(registrationModel);
        //        _db.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //Login method
        public bool RegistrationMethod(RegistrationModel registrationModel)
        {
            try
            {
                // Validate input (no empty username or password)
                if (string.IsNullOrWhiteSpace(registrationModel.UserName) ||
                    string.IsNullOrWhiteSpace(registrationModel.Password))
                {
                    return false; // Invalid input
                }

                // Check if username already exists
                bool isUsernameExists = _db.RegistrationModelTB
                    .Any(x => x.UserName.ToLower() == registrationModel.UserName.ToLower());

                if (isUsernameExists)
                {
                    return false; // Username is already taken
                }

                // Validate user Type (1 = Student, 2 = Teacher, 3 = Admin)
                if (registrationModel.Type < 1 || registrationModel.Type > 7)
                {
                    return false; // Invalid Type
                }

                // Hash the password
                registrationModel.Password = ComputeHash(registrationModel.Password, Salt);

                // Save to database
                _db.RegistrationModelTB.Add(registrationModel);
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegistrationMethod: {ex.Message}"); // Log the error
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            try
            {
                // Find the user by email
                var user = _db.RegistrationModelTB.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());

                // If user not found or password does not match, return false
                if (user == null || !VerifyPassword(password, user.Password, Salt))
                {
                    return false;
                }

                // User found and password matches
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }


        public RegistrationModel GetUser(string username)
        {
            try
            {
                // Retrieve the service provider profile based on the userId
                var serviceProviderProfile = _db.RegistrationModelTB.FirstOrDefault(sp => sp.UserName== username);

                return serviceProviderProfile;
            }
            catch (Exception ex)
            {
                // Handle exception (you might want to log this exception)
                return null; // Return null in case of an exception
            }
        }

        public bool ChangePassword(Guid UserID,string currentpassword,string newpassword)
        {
            try
            {
                // Find the user by email
                var user = _db.RegistrationModelTB.FirstOrDefault(x => x.UserID== UserID);

                if (user == null)
                {
                    return false; // User not found
                }

                // Verify if the current password matches
                if (!VerifyPassword(currentpassword, user.Password, Salt))
                {
                    return false; // Current password doesn't match
                }

                // Compute the hash of the new password with the hardcoded salt
                string newPasswordHash = ComputeHash(newpassword, Salt);

                // Update the user's password
                user.Password = newPasswordHash;

                // Save changes to the database
                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
        }

        public List<RegistrationModel> GetAllStudentsData()
        {
            try
            {
                // Retrieve all users where Type == 1 (students)
                var students = _db.RegistrationModelTB.Where(x => x.Type != 1).ToList();
                return students;
            }
            catch (Exception ex)
            {
                // Handle exception (logging can be added here)
                return new List<RegistrationModel>(); // Return an empty list if an error occurs
            }
        }


        //encryptionmethod
        private string ComputeHash(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Derive a new salted hash for the password
            using (var rfc2898 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hash = rfc2898.GetBytes(20); // 20 bytes for SHA-1
                return Convert.ToBase64String(hash);
            }
        }
        //checking the encrypted password
        private bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            // Compute the hash of the provided password with the stored salt
            string computedHash = ComputeHash(password, salt);
            // Compare with the stored hashed password
            return hashedPassword == computedHash;
        }

        public bool UpdateUser(RegistrationModel registrationModel)
        {
            //1 for student, 2 for teacher,3 for admin
            RegistrationModel user = _db.RegistrationModelTB.FirstOrDefault(x => x.UserID == registrationModel.UserID);
            if (user == null) 
            {
                return false;
            }

            user.UserName = registrationModel.UserName;
            user.Password = registrationModel.Password;
            user.Type = registrationModel.Type;
          //  user = registrationModel;
            _db.Update(user);
            _db.SaveChanges();
            return true;
        }

        public List<RegistrationModel> GetAllStudents()
        {
            try
            {
                // Retrieve the service provider profile based on the userId
                var serviceProviderProfiles = _db.RegistrationModelTB

                    .ToList();
                

                return serviceProviderProfiles;
            }
            catch (Exception ex)
            {
                // Handle exception (you might want to log this exception)
                return new List<RegistrationModel>(); // Return null in case of an exception
            }
        }


    }
}
