using System.Collections.Generic;
using System.Linq;
using DeveloperMediaDemo.Models;
using Machine.Specifications;
using NSubstitute;

namespace DeveloperMediaDemo.Controllers
{
    [Subject(typeof(NoteController))]  
    public class When_requesting_notes
    {
        static NoteController subject;
        static List<Note> result;

        Establish context = () =>
        {
            INoteRepository repository = Substitute.For<INoteRepository>();
            repository.ReadAll().Returns(TestData.Notes);
            subject = new NoteController(repository);
        };

        Because of = () => result = subject.GetAll().ToList();

        It should_return_three_notes = () => result.Count.ShouldEqual(3);
    }
}