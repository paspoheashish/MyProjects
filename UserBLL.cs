using EntityLayer;
using InterfaceBusinessLayer;
using InterfaceDataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class UserBLL : IUserBLL
    {
        private readonly IUnitOfWork unitOfWork;

        public UserBLL(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public List<User> GetUsers()
        {
            return unitOfWork.userRepository.Get();
        }

        public User GetUser(int Id)
        {
            return unitOfWork.userRepository.Get(Id);
        }

        public void SaveUser(User user)
        {
            unitOfWork.userRepository.Add(user);
            unitOfWork.CommitChanges();
        }

        public void UpdateUser(int id, User user)
        {
            unitOfWork.userRepository.Update(id, user);
            unitOfWork.CommitChanges();
        }

        public void DeleteUser(int id)
        {
            unitOfWork.userRepository.Remove(id);
            unitOfWork.CommitChanges();
        }

        public List<User> GetUsers(string role)
        {
            return unitOfWork.userRepository.GetUsers(role);
        }

        public void SaveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                unitOfWork.userRepository.Add(user);                
            }
            unitOfWork.CommitChanges();
        }
    }
}
