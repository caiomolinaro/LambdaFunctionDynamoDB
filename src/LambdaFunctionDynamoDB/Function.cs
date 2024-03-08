using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaFunctionDynamoDB;

public class Function
{
    public async Task<string> FunctionHandler(ILambdaContext lambdaContext)
    {
        AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
        AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);
        DynamoDBContext dynamoDBContext = new DynamoDBContext(client);

        Person person = await dynamoDBContext.LoadAsync<Person>(1);

        return $"FirstName: {person.FirstName} LastName: {person.LastName}";
    }
}