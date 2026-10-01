namespace Api.Requests
{
    public sealed record UpdateTodoRequest(Guid Id,string Title,bool Completed);

}