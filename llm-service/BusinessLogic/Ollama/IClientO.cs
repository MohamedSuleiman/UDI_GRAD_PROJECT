
namespace LlmService;

public interface IClientO
{
    public Task<string> GetUserPromt(int chatID, string promt);

}
