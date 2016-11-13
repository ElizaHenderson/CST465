using Lab4.Models.MidTerm;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public List<string> Choices { get; set; }
        
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
            return View(GetQuesitons());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(List<TestQuestion> answers)
        {
            List<TestQuestion> questions = new List<TestQuestion>();
            questions = GetQuesitons();
            if(ModelState.IsValid)
            {
                foreach(var questiony in answers)
                {
                    questiony.Question = questions[questiony.ID-1].Question;
                }
                TempData["TestData"] = answers;
                return View("DisplayResults", answers);
            }
            return View(answers);
            
        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            List <TestQuestion> data = new List<TestQuestion>();
            data = (List<TestQuestion>)TempData["TestData"];
            return View(data);
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
                    realqs.Add(t);
                }
                else if (question.Type == "ShortAnswerQuestion")
                {
                    ShortAnswerQuestion t = new ShortAnswerQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                    realqs.Add(t);
                }
                else if (question.Type == "LongAnswerQuestion")
                {
                    LongAnswerQuestion t = new LongAnswerQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                    realqs.Add(t);
                }
                else if (question.Type == "MultipleChoiceQuestion")
                {
                    MultipleChoiceQuestion t = new MultipleChoiceQuestion();
                    t.ID = question.ID;
                    t.Question = question.Question;
                    t.choices = new List<string>(question.Choices);
                    realqs.Add(t);
                }
            }
            return realqs;
        }
    }
}