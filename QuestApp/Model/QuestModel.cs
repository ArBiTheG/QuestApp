using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class QuestModel
    {
        Test _test;
        Question _currentQuestion;

        public QuestModel(Test test)
        {
            _test = test;
            _currentQuestion = GetFirstQuestion();
        }
        private Question GetFirstQuestion()
        {
            return _test.Questions.FirstOrDefault(new Question());
        }
        private Question GetQuestionByGuid(Guid? guid)
        {
            return _test.Questions.FirstOrDefault(q => q.Guid == guid, new Question());
        }

        public Question CurrentQuestion => _currentQuestion;

        public void SelectAnswerForCurrentQuestion(Guid guid)
        {
            Answer? answer = _currentQuestion.Answers.FirstOrDefault(answer => answer.Guid == guid);
            if (answer != null)
            {
                if (answer.NavigateQuestion != null)
                {
                    _currentQuestion = GetQuestionByGuid(answer.NavigateQuestion);
                }
            }
        }
    }
}
