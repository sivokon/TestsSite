using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface IOptionService
    {
        OptionDTO GetById(int id);
        void Add(OptionDTO entity);
        void Update(OptionDTO entity);
        void Delete(int id);

        IEnumerable<OptionDTO> GetOptionsByQuestionId(int id);
    }
}
