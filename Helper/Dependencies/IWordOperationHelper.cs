using System.Threading.Tasks;
using System.Collections.Generic;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper.Dependencies
{
    public interface IWordOperationHelper
    {
        Task<WordsViewModelByWebApi> GetWordsByWebApi(string token);
        Task<bool> InsertNewWordByWebApi(WordsViewModel requestBody, string token);
        Task<bool> UpdateWordByWebApi(WordsViewModel requestBody, string token);
        bool DeleteWordByWebApi(WordsViewModel requestBody, string token);
    }
}