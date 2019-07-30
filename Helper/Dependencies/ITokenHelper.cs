using System.Threading.Tasks;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper.Dependencies
{
    public interface ITokenHelper
    {
        bool CheckToken();
        Task<string> CreateToken ();
    }
}