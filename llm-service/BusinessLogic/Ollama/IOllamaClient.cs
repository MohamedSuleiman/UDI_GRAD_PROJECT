using System;

namespace Backend;

public interface IOllamaClient
{
    public Task<string> GetUserPromt(string promt);

}
