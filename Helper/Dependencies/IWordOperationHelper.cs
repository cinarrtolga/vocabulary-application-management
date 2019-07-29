using System.Collections.Generic;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper.Dependencies
{
    public interface IWordOperationHelper
    {
        List<WordsViewModel> GetWordsByWebApi(string token);
        bool InsertNewWordByWebApi(WordsViewModel requestBody, string token);
        bool UpdateWordByWebApi(WordsViewModel requestBody, string token);
        bool DeleteWordByWebApi(WordsViewModel requestBody, string token);
    }
}