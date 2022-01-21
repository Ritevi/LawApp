using LawApp.Common.Models.Domain;
using LawApp.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawApp.Bll.Services
{
    class AdminService : IAdminService
    {
        private readonly IQuestionRepository _questionRepository;

        public AdminService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task PopulateDbAsync()
        {
            var nextQuestion = new Question()
            {
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Id = Guid.NewGuid(),
                        NextQuestions = null,
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Id = Guid.NewGuid(),
                                Text = "answer2Tag1"
                            },
                            new Tag()
                            {
                                Id = Guid.NewGuid(),
                                Text = "answer2Tag2"
                            }
                        },
                        Text = "answer2"
                    }
                },
                CategoryNumber = 2,
                Id = Guid.NewGuid(),
                Text = "second question"
            };

            var question = new Question()
            {
                Answers = new List<Answer>()
                {
                    new Answer()
                    {
                        Id = Guid.NewGuid(),
                        NextQuestions = new List<Question>()
                        {
                            nextQuestion
                        },
                        Tags = new List<Tag>()
                        {
                            new Tag()
                            {
                                Id = Guid.NewGuid(),
                                Text = "answer1Tag1"
                            },
                            new Tag()
                            {
                                Id = Guid.NewGuid(),
                                Text = "answer1Tag2"
                            }
                        },
                        Text = "answer1"
                    }
                },
                CategoryNumber = 1,
                Id = Guid.NewGuid(),
                Text = "first question"
            };

            await _questionRepository.AddAsync(question);
        }
    }
}
