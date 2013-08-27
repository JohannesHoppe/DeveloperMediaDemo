using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using DeveloperMediaDemo.Models;
using Machine.Specifications;
using NSubstitute;

namespace DeveloperMediaDemo.Controllers
{
    [Subject(typeof(NoteController))]  
    public class When_getting_notes
    {
        static NoteController controller;
        static List<Note> result;

        Establish context = () =>
        {
            INoteRepository repository = Substitute.For<INoteRepository>();
            repository.ReadAll().Returns(TestData.Notes);
            controller = new NoteController(repository);
        };

        Because of = () => result = controller.GetAll().ToList();

        It should_return_three_notes = () => result.Count.ShouldEqual(3);
    }

    [Subject(typeof(NoteController))]
    public class When_searching_for_an_unknown_note
    {
        static NoteController controller;
        static HttpResponseMessage result;

        Establish context = () =>
        {
            INoteRepository repository = Substitute.For<INoteRepository>();
            controller = new NoteController(repository)
                             {
                                 Request = new HttpRequestMessage(HttpMethod.Get, "http://test/api/note/search/test"),
                                 Configuration = new HttpConfiguration()
                             };

            repository.ReadAll().Returns(TestData.Notes);
        };

        private Because of = () =>
                                 {
                                     Task<HttpResponseMessage> task = controller.GetSearch("test").ExecuteAsync(new CancellationToken());
                                     task.Wait();
                                     result = task.Result;
                                 };

        It should_respond_with_not_found_status_code = () => result.StatusCode.ShouldEqual(HttpStatusCode.NotFound);
    }
}