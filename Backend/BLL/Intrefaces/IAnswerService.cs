using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface IAnswerService
    {
        //IEnumerable<Answer> GetAll();
        AnswerDTO GetById(int id);
        void Add(AnswerDTO entity);
        //void Update(T entity);
        //void Delete(int id);

        //IEnumerable<AnswerDTO> GetAnswersByTestStatisticId(int id);
        IEnumerable<AnswerDTO> GetAnswersWithAnswerOptionsByTestStatisticId(int id);
    }
}
