using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    public interface IDialogWindowService
    {
        bool? ShowDialog(string title, string message);
    }
}
