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
        MainService _mainService;

        public MainViewModel()
        {
            _mainService = new MainService();
        }
    }
}
