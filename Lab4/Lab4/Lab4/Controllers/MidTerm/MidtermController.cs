using Lab4.Models.MidTerm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers.MidTerm
{
    class Temp
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public string[] Choices { get; set; }
        
    }
    public class MidtermController : Controller
    {
        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TakeTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TakeTest(List<TestQuestion> answers)
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            questions = GetQuesitons();
            return View(questions);
        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            return View();
        }

        public List<TestQuestion> GetQuesitons()
        {

            List<Temp> questions = new List<Temp>();
            List<TestQuestion> realqs = new List<TestQuestion>();
            string json = System.IO.File.ReadAllText(Server.MapPath("~/JSON/midterm.json"));
            var questionst = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Temp>>(json);
            foreach (var question in questionst)
            {
                if (question.Type == "TrueFalseQuestion")
                {
                    TrueFalseQuestion t = new TrueFalseQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                }
                else if (question.Type == "ShortAnswerQuestion")
                {
                    ShortAnswerQuestion t = new ShortAnswerQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                }
                else if (question.Type == "LongAnswerQuestion")
                {
                    LongAnswerQuestion t = new LongAnswerQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                }
                else if (question.Type == "MultipleChoiceQuestion")
                {
                    LongAnswerQuestion t = new LongAnswerQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                }
            }

            return realqs;
        }
    }
}