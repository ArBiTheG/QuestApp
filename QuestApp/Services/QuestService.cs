using QuestApp.Data.DataAccess;
using QuestApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    internal class QuestService
    {
        IDataProvider<Test> _dataProvider;

        public QuestService()
        {
            _dataProvider = new JSONDataProvider<Test>("quests.json");

            _dataProvider.SaveData(MockJsonData());
        }

        public Test GetTest()
        {
            var test = _dataProvider.LoadData()?.ToArray();
            if (test != null)
                if (test.Length > 0)
                    return test[0];
            return new Test("Квест не загружен","Не удалось загрузить квест, поскольку был не найден");
        }

        public List<Test> MockJsonData()
        {
            return new List<Test>()
            {
                new Test("Test", "DescriptionTest")
                {
                    Questions = new List<Question>(){
                        new Question(Guid.Parse("f8f19551-dbc8-45f2-892d-c898de996876"),"Question1", "DescriptionQuestion1")
                        {
                            Answers = new List<Answer>()
                            {
                                new Answer("Answer1", "DescriptionAnswer1")
                                {
                                    RewardScore = 10,
                                    NavigateQuestion = Guid.Parse("24625bd9-6538-4084-ac89-11e91c86dc62")
                                },
                                new Answer("Answer2", "DescriptionAnswer2")
                                {
                                    RewardScore = 10,
                                    NavigateQuestion = Guid.Parse("09690b6a-94d6-4992-a366-4d61a87efbc6")
                                },
                            }
                        },

                        new Question(Guid.Parse("24625bd9-6538-4084-ac89-11e91c86dc62"),"Question2", "DescriptionQuestion2")
                        {
                            Answers = new List<Answer>()
                            {
                                new Answer("Answer3","DescriptionAnswer3")
                                {
                                    RewardScore = 10,
                                    NavigateQuestion = Guid.Parse("f8f19551-dbc8-45f2-892d-c898de996876")
                                },
                            }
                        },

                        new Question(Guid.Parse("09690b6a-94d6-4992-a366-4d61a87efbc6"),"Question3", "DescriptionQuestion3")
                        {
                            Answers = new List<Answer>()
                            {
                                new Answer("Answer4","DescriptionAnswer4")
                                {
                                    RewardScore = 10,
                                    NavigateQuestion = Guid.Parse("f8f19551-dbc8-45f2-892d-c898de996876"),
                                    GameOver = new GameOver()
                                    {
                                        Name = "Поздравляю",
                                        Description = "Вы закончили игру"
                                    }
                                },
                            }
                        }
                    }
                }
            };

        }
    }
}
