using Newtonsoft.Json;
using PactNet.Mocks.MockHttpService;
using ProCodeGuide.ContractPact.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProCodeGuide.ContractPact
{
    public class ConsumerPactTest : IClassFixture<ContractPact.ContractPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPactTest(ContractPact.ContractPact data)
        {
            _mockProviderService = data.MockPoviderService;
            _mockProviderService.ClearInteractions(); //note: clear any previously registred interaction before ther test is run
            _mockProviderServiceBaseUri = data.MockPoviderServiceBaseUri;
        }

        [Fact]
        public async void GetString_VarifyIfItReturns()
        {
            //Arange
            _mockProviderService
                    .Given("String test unique unun")
                    .UponReceiving("A Get request to retrieve string")
                    .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
                    {
                        Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Get,
                        Path = "/api/Maths"
                        //Headers = new Dictionary<string, object>
                        //{
                        //    { "Accept", "application/json"}
                        //}
                    })
                    .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, object>
                        {
                            { "Content-Type", "application/json; charset-utf-8"}
                        },
                        Body = "Test"

                    });

            var consumer = new APIClient(_mockProviderServiceBaseUri);

            //var httpClient = new HttpClient();
            //var response = await httpClient.GetAsync($"{_mockProviderServiceBaseUri}/api/Maths");
            //var json = await response.Content.ReadAsStringAsync();
            //var resString = JsonConvert.DeserializeObject<string>(json);

            //Assert.Equal("Test", json);

            //Act
            var result =await consumer.GetString();
            
            ////Assert
            Assert.Equal("Test", result);

            _mockProviderService.VerifyInteractions();


        }

        [Fact]
        public void GetString_VarifyIfItReturns_GetTestValue()
        {
            //Arange
            _mockProviderService
                    .Given("String GetTestValue")
                    .UponReceiving("A Get request to retrieve string GetTestValue")
                    .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
                    {
                        Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Get,
                        Path = "/api/Maths/GetTestValue",
                        Headers = new Dictionary<string, object>
                        {
                            { "Accept", "application/json"}
                        }
                    })
                    .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
                    {
                        Status = 200,
                        Headers = new Dictionary<string, object>
                        {
                            { "Content-Type", "application/json, charset-utf-8"}
                        },
                        Body = "Test"

                    });

            var consumer = new APIClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetTestString();
            //Assert
            Assert.Equal("Test", result);

            _mockProviderService.VerifyInteractions();


        }


        //[Fact]
        //public void GetString_VarifyIfItReturns_Fall()
        //{
        //    //Arange
        //    _mockProviderService
        //            .Given("String test")
        //            .UponReceiving("A Get request to retrieve string")
        //            .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
        //            {
        //                Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Get,
        //                Path = "/api/Maths",
        //                Headers = new Dictionary<string, object>
        //                {
        //                    { "Accept", "application/json"}
        //                }
        //            })
        //            .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
        //            {
        //                Status = 200,
        //                Headers = new Dictionary<string, object>
        //                {
        //                    { "Content-Type", "application/json, charset-utf-8"}
        //                },
        //                Body = "Test"

        //            });

        //    var consumer = new APIClient(_mockProviderServiceBaseUri);

        //    //Act
        //    var result = consumer.GetString();

        //    //Assert
        //    Assert.Equal("Test", result);

        //    _mockProviderService.VerifyInteractions();


        //}

        //[Fact]
        //public void GetSum_VarifyIfItReturns_Sum()
        //{
        //    //Arange
        //    _mockProviderService
        //            .Given("String sum")
        //            .UponReceiving("A POST request to retrieve SUM of numbers")
        //            .With(new PactNet.Mocks.MockHttpService.Models.ProviderServiceRequest
        //            {
        //                Method = PactNet.Mocks.MockHttpService.Models.HttpVerb.Post,
        //                Path = "/api/Maths/Add",
        //                Headers = new Dictionary<string, object>
        //                {
        //                    { "Content-Type", "application/json; charset=utf-8"}
        //                },
        //                Body =
        //                new
        //                {
        //                    x1 = 2,
        //                    x2 = 3
        //                }
        //            })
        //            .WillRespondWith(new PactNet.Mocks.MockHttpService.Models.ProviderServiceResponse
        //            {
        //                Status = 200,
        //                Headers = new Dictionary<string, object>
        //                {
        //                    { "Content-Type", "text/plain, charset-utf-8"}
        //                },
        //                Body = "5"

        //            });

        //    var consumer = new APIClient(_mockProviderServiceBaseUri);

        //    //Act
        //    var result = consumer.GetSum(2,3);
        //    var newRes = result.Result;
        //    //Assert
        //    Assert.Equal("5", newRes);

        //    _mockProviderService.VerifyInteractions();


        //}

    }
}
