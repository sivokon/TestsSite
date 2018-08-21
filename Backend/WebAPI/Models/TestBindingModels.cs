//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace WebAPI.Models
//{
//    public class NewTestBindingModel
//    {
//        [Required]
//        [StringLength(50, ErrorMessage = "Too long test title. Test title can not contain more than {1} characters")]
//        public string Title { get; set; }

//        [Required]
//        public int CategoryId { get; set; }

//        [StringLength(2000, ErrorMessage = "Too long test description. Description can not contain more than {1} characters")]
//        public string Descr { get; set; }

//        [Required]
//        [Range(1, 200, ErrorMessage = "The duration of test can range only from {1} to {2} minutes")]
//        public int DurationMin { get; set; }

//        [Required]
//        public List<NewTestQuestionBindingModel> Questions { get; set; }    
//    }

//    public class NewTestQuestionBindingModel
//    {
//        [Required]
//        [StringLength(1500, ErrorMessage = "Too long question. Question can not contain more than {1} characters")]
//        public string Body { get; set; }

//        [Required]
//        [Range(1, 500, ErrorMessage = "Test can not have more then {2} questions")]
//        public int Index { get; set; }

//        [Required]
//        public List<NewTestOptionBindingModel>  Options { get; set; }
//    }

//    public class NewTestOptionBindingModel
//    {
//        [Required]
//        [StringLength(500, ErrorMessage = "Too long option. Option can not contain more than {1} characters")]
//        public string Body { get; set; }

//        [Required]
//        [Range(1, 20, ErrorMessage = "Question can not have more then {2} options")]
//        public int Index { get; set; }

//        [Required]
//        public bool IsCorrect { get; set; }
//    }

//    public class UpdateTestInfoBindingModel
//    {
//        [Required]
//        [StringLength(50, ErrorMessage = "Too long test title. Test title can not contain more than {1} characters")]
//        public string Title { get; set; }

//        [Required]
//        public int CategoryId { get; set; }

//        [StringLength(2000, ErrorMessage = "Too long test description. Description can not contain more than {1} characters")]
//        public string Descr { get; set; }

//        [Required]
//        [Range(1, 200, ErrorMessage = "The duration of test can range only from {1} to {2} minutes")]
//        public int DurationMin { get; set; }
//    }

//}






using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class NewTestBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Too long test title. Test title can not contain more than {1} characters")]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(2000, ErrorMessage = "Too long test description. Description can not contain more than {1} characters")]
        public string Descr { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "The duration of test can range only from {1} to {2} minutes")]
        public int DurationMin { get; set; }

        [Required]
        public List<NewQuestionBindingModel> Questions { get; set; }
    }

    public class NewQuestionBindingModel
    {
        //[Required]
        //public int TestId { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "Too long question. Question can not contain more than {1} characters")]
        public string Body { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Test can not have more then {2} questions")]
        public int Index { get; set; }

        [Required]
        public List<NewOptionBindingModel> Options { get; set; }

        //[Required]
        //public List<NewCorrectOption> CorrectOptions { get; set; }
    }

    public class NewCorrectOption
    {
        [Required]
        public int OptionId { get; set; }

        //[Required]
        //public int QuestionId { get; set; }
    }

    public class NewOptionBindingModel
    {
        //[Required]
        //public int QuestionId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Too long option. Option can not contain more than {1} characters")]
        public string Body { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Question can not have more then {2} options")]
        public int Index { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }

    public class UpdateTestInfoBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Too long test title. Test title can not contain more than {1} characters")]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(2000, ErrorMessage = "Too long test description. Description can not contain more than {1} characters")]
        public string Descr { get; set; }

        [Required]
        [Range(1, 200, ErrorMessage = "The duration of test can range only from {1} to {2} minutes")]
        public int DurationMin { get; set; }
    }
}