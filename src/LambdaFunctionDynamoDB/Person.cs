using Amazon.DynamoDBv2.DataModel;

namespace LambdaFunctionDynamoDB;

[DynamoDBTable("Person")]
public class Person
{
    [DynamoDBHashKey]
    public int PersonId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}