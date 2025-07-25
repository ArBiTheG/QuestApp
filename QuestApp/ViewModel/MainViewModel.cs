using QuestApp.Data.Entity;
using QuestApp.Model;
using QuestApp.Services;
using QuestApp.Utils;
using QuestApp.View;
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
        IDialogWindowService dialogWindowService;
        IGameOverDialogService gameOverDialogService;

        QuestService _questService;
        QuestModel _questModel;


        Question _currentQuestion;
        Actor _curentActor;
        RelayCommand _resetQuestCommand;
        RelayCommand _selectAnswerCommand;

        public MainViewModel()
        {
            dialogWindowService = new DialogWindowService();
            gameOverDialogService = new GameOverDialogService();

            _questService = new QuestService();
            StartNewQuest();
        }
        private void StartNewQuest()
        {
            _questModel = new QuestModel(_questService.GetTest());
            _questModel.QuestionChanged += QuestModel_QuestionChanged;
            _questModel.GameOvered += QuestModel_GameOvered;

            CurrentQuestion = _questModel.CurrentQuestion;
            CurrentActor = _questModel.Actor;
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
        public Actor CurrentActor
        {
            get => _curentActor;
            set
            {
                _curentActor = value;
                OnPropertyChanged(nameof(CurrentActor));
            }
        }

        public RelayCommand ResetQuestCommand
        {
            get => _resetQuestCommand ?? (_resetQuestCommand = new RelayCommand((obj) =>
            {
                if (dialogWindowService.ShowDialog("Подтверждение","Вы действительно хотите начать новую игру?") == true)
                {
                    StartNewQuest();
                }
            }));
        }

        public RelayCommand SelectAnswerCommand
        {
            get => _selectAnswerCommand ?? (_selectAnswerCommand = new RelayCommand((obj) =>
            {
                Guid guid;
                if (Guid.TryParse(obj?.ToString(),out guid))
                {
                    _questModel.SelectAnswerForCurrentQuestion(guid);
                }
            }));
        }
        private void QuestModel_QuestionChanged()
        {
            CurrentQuestion = _questModel.CurrentQuestion;
            CurrentActor = _questModel.Actor;
        }

        private void QuestModel_GameOvered(GameOver gameOver)
        {
            if (gameOverDialogService.ShowDialog(gameOver) == true)
            {
                StartNewQuest();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
