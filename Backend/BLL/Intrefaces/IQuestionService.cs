using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Common.Models;
using BLL.DTO;

namespace BLL.Intrefaces
{
    public interface IQuestionService
    {
        //IEnumerable<Question> GetAll();
        QuestionDTO GetById(int id);
        void Add(QuestionDTO entity);
        void Update(QuestionDTO entity);
        void Delete(int id);

        IEnumerable<QuestionDTO> GetQuestionsByTestId(int id);
        QuestionDTO GetQuestionByIndexAndTestId(int index, int testId);
        IEnumerable<QuestionDTO> GetQuestionsWithRelatedOptionsByTestId(int id);
    }
}
