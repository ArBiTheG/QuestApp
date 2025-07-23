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
        QuestModel _questModel;

        RelayCommand _selectAnswerCommand;

        public MainViewModel()
        {
            _questService = new QuestService();
            _questModel = new QuestModel(_questService.GetTest());

            CurrentQuestion = _questModel.CurrentQuestion;
        }

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
