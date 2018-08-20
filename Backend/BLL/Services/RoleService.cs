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
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void Add(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            _unitOfWork.Roles.Add(role);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.Roles.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void Update(RoleDTO entity)
        {
            Role role = _mapper.Map<Role>(entity);
            _unitOfWork.Roles.Update(role);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            IEnumerable<Role> roles = _unitOfWork.Roles.GetAll();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public RoleDTO GetById(int id)
        {
            Role role = _unitOfWork.Roles.GetById(id);
            return _mapper.Map<RoleDTO>(role);
        }

        public RoleDTO GetRoleByTitle(string title)
        {
            Role role = _unitOfWork.Roles.GetRoleByTitle(title);
            return _mapper.Map<RoleDTO>(role);
        }

    }
}
