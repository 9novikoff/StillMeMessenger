namespace MessagingContracts.MessageContracts;

public class MessageGetPage
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string UserId { get; set; }
}