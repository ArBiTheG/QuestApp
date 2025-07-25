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
        Actor _currentActor;

        public delegate void ChangeQuestionHandler();
        public delegate void GameOverHandler(GameOver gameOver);
        public event ChangeQuestionHandler QuestionChanged;
        public event GameOverHandler GameOvered;

        public QuestModel(Test test)
        {
            _test = test;
            _currentQuestion = GetFirstQuestion();
            _currentActor = new Actor("Игрок","Описание");
        }
        private Question GetFirstQuestion()
        {
            return _test.Questions.FirstOrDefault(new Question("Вопрос не найден","Не удалось загрузить первый вопрос, поскольку его не существует"));
        }
        private Question GetQuestionByGuid(Guid? guid)
        {
            return _test.Questions.FirstOrDefault(q => q.Guid == guid, new Question("Вопрос не найден", "Не удалось загрузить следующий вопрос, поскольку его не существует"));
        }

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set {
                _currentQuestion = value;
                QuestionChanged?.Invoke();
            }
        }
        public Actor Actor => _currentActor;

        public void SelectAnswerForCurrentQuestion(Guid guid)
        {
            Answer? answer = _currentQuestion.Answers.FirstOrDefault(answer => answer.Guid == guid);
            if (answer != null)
            {
                _currentActor.Score += answer.RewardScore;
                if (answer.GameOver != null)
                {
                    GameOvered?.Invoke(answer.GameOver);
                    return;
                }

                if (answer.NavigateQuestion != null)
                {
                    CurrentQuestion = GetQuestionByGuid(answer.NavigateQuestion);
                }
            }
        }
    }
}
