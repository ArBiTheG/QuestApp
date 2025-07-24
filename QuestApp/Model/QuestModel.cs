using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestApp.Data.Entity;

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
            return _test.Questions.FirstOrDefault(new Question("Вопрос не найден","Не удалось загрузить первый вопрос, поскольку его не существует"));
        }
        private Question GetQuestionByGuid(Guid? guid)
        {
            return _test.Questions.FirstOrDefault(q => q.Guid == guid, new Question("Вопрос не найден", "Не удалось загрузить следующий вопрос, поскольку его не существует"));
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
