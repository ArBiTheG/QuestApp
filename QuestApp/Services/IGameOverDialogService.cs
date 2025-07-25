using QuestApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    interface IGameOverDialogService
    {
        bool? ShowDialog(GameOver gameOver);
    }
}
