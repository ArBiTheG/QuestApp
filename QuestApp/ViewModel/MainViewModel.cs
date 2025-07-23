using QuestApp.Model;
using QuestApp.Services;
using QuestApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.ViewModel
{
    internal class MainViewModel
    {
        QuestService _questService;

        RelayCommand _selectAnswerCommand;

        public MainViewModel()
        {
            _questService = new QuestService();

            CurrentQuestion = new Question("Test1", "TestDescription1");

            CurrentQuestion.Answers = new ObservableCollection<Answer>()
            {
                new Answer("TestAnswer1", "TestAnswerDescription1"),
                new Answer("TestAnswer2", "TestAnswerDescription2"),
                new Answer("TestAnswer3", "TestAnswerDescription3"),
                new Answer("TestAnswer4", "TestAnswerDescription4")
            };
        }

        public Test Test { get; set; }
        public Question CurrentQuestion { get; set; }

        public RelayCommand SelectAnswerCommand
        {
            get => _selectAnswerCommand ?? (_selectAnswerCommand = new RelayCommand((obj) =>
            {
                Guid guid;
                if (Guid.TryParse(obj?.ToString(),out guid))
                {
                    //TODO: Выполнение действий при выборе ответа
                }
            }));
        }
    }
}
