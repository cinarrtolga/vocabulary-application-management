using System.Threading.Tasks;
using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper.Dependencies
{
    public interface ILoginHelper{
         Task<bool> LoginMember(MemberViewModel member, string token);
    }
}