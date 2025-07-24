using QuestApp.Data.Entity;
using QuestApp.Model;
using QuestApp.Services;
using QuestApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.ViewModel
{
    internal class MainViewModel: INotifyPropertyChanged
    {
        QuestService _questService;
        QuestModel _questModel;


        Question _currentQuestion;
        RelayCommand _selectAnswerCommand;

        public MainViewModel()
        {
            _questService = new QuestService();
            _questModel = new QuestModel(_questService.GetTest());

            CurrentQuestion = _questModel.CurrentQuestion;
        }

        public Question CurrentQuestion 
        { 
            get => _currentQuestion;
            set 
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        public RelayCommand SelectAnswerCommand
        {
            get => _selectAnswerCommand ?? (_selectAnswerCommand = new RelayCommand((obj) =>
            {
                Guid guid;
                if (Guid.TryParse(obj?.ToString(),out guid))
                {
                    _questModel.SelectAnswerForCurrentQuestion(guid);
                    CurrentQuestion = _questModel.CurrentQuestion;
                }
            }));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
