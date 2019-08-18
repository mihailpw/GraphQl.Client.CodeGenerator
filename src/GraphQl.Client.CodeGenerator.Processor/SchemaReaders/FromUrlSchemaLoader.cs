using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphQl.Client.CodeGenerator.Infra.Exceptions;
using GraphQl.Client.CodeGenerator.Infra.Models;
using GraphQl.Client.CodeGenerator.Infra.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQl.Client.CodeGenerator.Processor.SchemaReaders
{
    public class FromUrlSchemaReader : ISchemaReader
    {
        private readonly string _uri;
        private readonly int _innerLevelOfType;


        public FromUrlSchemaReader(string uri, int innerLevelOfType = 4)
        {
            _uri = uri.VerifyNotNull(nameof(uri));
            _innerLevelOfType = innerLevelOfType;
        }


        public async Task<GraphQlSchema> LoadSchemaDataAsync()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(_uri, CreateContent()))
                {
                    var content = response.Content != null
                        ? await response.Content.ReadAsStringAsync()
                        : "<null>";
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new GeneratorInvalidOperationException(
                            $"Status code: {response.StatusCode:D} ({response.StatusCode:G}); content: {content}");
                    }

                    try
                    {
                        var jObject = (JObject) JsonConvert.DeserializeObject(content);
                        var schemeJObject = jObject["data"]["__schema"];
                        var dto = schemeJObject.ToObject<GraphQlJsonDto.Schema>();

                        var convertCommand = new ConvertGraphQlJsonDtoToModelCommand();
                        var schema = convertCommand.Execute(dto);

                        return schema;
                    }
                    catch (JsonReaderException e)
                    {
                        throw new GeneratorReaderException("Invalid schema json received.", e);
                    }
                }
            }
        }

        private HttpContent CreateContent()
        {
            var schemaQuery = GraphQlJsonDto.RetrieveSchemaQuery(_innerLevelOfType);

            return new StringContent(
                JsonConvert.SerializeObject(new { query = schemaQuery }),
                Encoding.UTF8,
                "application/json");
        }
    }
}