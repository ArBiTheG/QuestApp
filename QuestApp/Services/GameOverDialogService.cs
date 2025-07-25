using QuestApp.Data.Entity;
using QuestApp.Model;
using QuestApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    class GameOverDialogService : IGameOverDialogService
    {
        public bool? ShowDialog(GameOver gameOver)
        {
            GameOverWindow dialog = new GameOverWindow(gameOver);
            return dialog.ShowDialog();
        }
    }
}
