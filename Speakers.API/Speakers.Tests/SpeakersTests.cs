using Microsoft.AspNetCore.Mvc;
using Speakers.API.Controllers;
using Speakers.Domain;


namespace Speakers.Tests
{
    public class SpeakersTests
    {
        private SpeakerController controller;

        public SpeakersTests()
        {
            this.controller = new SpeakerController();
        }

        [Fact]
        public void ItExists()
        {
            //var controller = new SpeakerController();

            var result =  controller.Search("Türk");

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Search_Return_Collection_Of_Speakers()
        {
           
            // var controller = new SpeakerController();
            var result = controller.Search("Türk") as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Speaker>>(result.Value);
        }

        [Fact]
        public void Given_Exact_Match_Then_One_Speaker_In_Collection()
        {
            var response = controller.Search("Türkay") as OkObjectResult;
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
            var result = controller.Search(searchString) as OkObjectResult;
            var speakers = (result.Value as IEnumerable<Speaker>).ToList();
            Assert.Single(speakers);
            Assert.Equal("Türkay", speakers.First().Name);
        }
        [Fact]
        public void Given_No_Match_Then_Empty_Collection()
        {
            var result = controller.Search("XXX") as OkObjectResult;
            var speakers = result.Value as IEnumerable<Speaker>;
            Assert.Empty(speakers);
        }


        [Fact]
        public void Given_3_Match_Then_Collection_With_3_Speakers()
        {
            var result = controller.Search("mel") as OkObjectResult;
            var speakers = result.Value as IEnumerable<Speaker>;
            Assert.Equal(3, speakers.Count());
            Assert.Contains(speakers, s => s.Name == "Melinda");
            Assert.Contains(speakers, s => s.Name == "Melike");
            Assert.Contains(speakers, s => s.Name == "Melahat");



        }


    }
}