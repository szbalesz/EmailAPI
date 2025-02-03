namespace EmailAPI.Models.Dtos
{
    public record EmailRequestDto(string To, string Subject, string Body);
}
