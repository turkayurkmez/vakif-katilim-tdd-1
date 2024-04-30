using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using Speakers.API.Controllers;
using Speakers.Domain;
using Speakers.Service;


namespace Speakers.Tests
{
    public class SpeakersTests
    {
        private SpeakerController controller;

        private Mock<ISpeakerService> _mockSpeakerService;
        private IEnumerable<Speaker> _mockSpeakers;
        public SpeakersTests()
        {
            var speakers = new List<Speaker>()
            {
                new Speaker{ Name ="Türkay", LastName="Ürkmez"},
                new Speaker{ Name = "Burak", LastName="Ağıt"},
                new Speaker { Name = "Melinda", LastName = "Günebakan" },
                new Speaker { Name = "Melahat", LastName = "Sümbül" },
                new Speaker { Name = "Melike", LastName = "Candan" },
            };

            //Mock<ISpeakerService> mockSpeakerService = new Mock<ISpeakerService>();
            //mockSpeakerService.SetupSet(sp => { sp.Speakers = speakers; });
            //mockSpeakerService.Setup(sp => sp.SearchSpeakersByName(It.IsAny<string>())).Returns())

            _mockSpeakerService = new Mock<ISpeakerService>();
            _mockSpeakers = speakers;
           
            this.controller = new SpeakerController(_mockSpeakerService.Object);
        }

        private void setupMockObjectForUnitTest(string value)
        {
            _mockSpeakerService.Setup(sp => sp.SearchSpeakersByName(It.IsAny<string>())).Returns(_mockSpeakers.Where(s => s.FullName.Contains(value, StringComparison.OrdinalIgnoreCase)));
        }
        [Fact]
        public void ItExists()
        {
            //var controller = new SpeakerController();

            var result = controller.Search("Türk");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Search_Return_Collection_Of_Speakers()
        {

            string value = "Türk";
            // var controller = new SpeakerController();
            setupMockObjectForUnitTest(value);
            var result = controller.Search(value) as OkObjectResult;


            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Speaker>>(result.Value);
        }

  

        [Fact]
        public void Given_Exact_Match_Then_One_Speaker_In_Collection()
        {
            var value = "Türkay";
            setupMockObjectForUnitTest(value);
            var response = controller.Search(value) as OkObjectResult;
            var speakers = (response.Value as IEnumerable<Speaker>).ToList();
            Assert.Single(speakers);
            Assert.Equal("Türkay", speakers.First().Name);
        }

        [Theory]
        [InlineData("Türkay")]
        [InlineData("TürKAy")]
        [InlineData("türkAy")]
        public void Given_Case_Insensitive_Match_Then_Speaker_In_Collection(string searchString)
        {
            setupMockObjectForUnitTest(searchString);
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (result.Value as IEnumerable<Speaker>).ToList();
            Assert.Single(speakers);
            Assert.Equal("Türkay", speakers.First().Name);
        }
        [Fact]
        public void Given_No_Match_Then_Empty_Collection()
        {
            var value = "XXX";
            setupMockObjectForUnitTest(value);
            var result = controller.Search(value) as OkObjectResult;
            var speakers = result.Value as IEnumerable<Speaker>;
            Assert.Empty(speakers);
        }


        [Fact]
        public void Given_3_Match_Then_Collection_With_3_Speakers()
        {
            var value = "mel";
            setupMockObjectForUnitTest(value);
            var result = controller.Search(value) as OkObjectResult;
            var speakers = result.Value as IEnumerable<Speaker>;
            Assert.Equal(3, speakers.Count());
            Assert.Contains(speakers, s => s.Name == "Melinda");
            Assert.Contains(speakers, s => s.Name == "Melike");
            Assert.Contains(speakers, s => s.Name == "Melahat");



        }


    }
}