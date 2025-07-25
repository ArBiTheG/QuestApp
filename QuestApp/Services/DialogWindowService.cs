using QuestApp.Model;
using QuestApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    public class DialogWindowService : IDialogWindowService
    {
        public bool? ShowDialog(string title, string message)
        {
            MessageDialogWindow dialog = new MessageDialogWindow(new Message(title, message));
            return dialog.ShowDialog();
        }
    }
}
