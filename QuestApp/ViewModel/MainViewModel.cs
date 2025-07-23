using QuestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.ViewModel
{
    internal class MainViewModel
    {
        QuestService _questService;

        public MainViewModel()
        {
            _questService = new QuestService();
        }
    }
}
