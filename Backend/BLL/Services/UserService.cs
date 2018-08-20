using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Intrefaces;
using DAL_Common.Interfaces;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(UserDTO entity)
        {
            User user = _mapper.Map<User>(entity);
            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void Update(UserDTO entity)
        {
            User user = _mapper.Map<User>(entity);
            _unitOfWork.Users.Update(user);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<User> users = _unitOfWork.Users.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetById(int id)
        {
            User user = _unitOfWork.Users.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserByName(string name)
        {
            User user = _unitOfWork.Users.GetUserByName(name);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsersByUsernameKeyWord(string keyWord)
        {
            IEnumerable<User> users = _unitOfWork.Users.GetUsersByUsernameKeyWord(keyWord);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

    }
}
