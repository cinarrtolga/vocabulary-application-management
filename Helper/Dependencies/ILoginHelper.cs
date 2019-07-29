using vocabularyManagementTool.Model;

namespace vocabularyManagementTool.Helper.Dependencies
{
    public interface ILoginHelper{
         bool LoginMember(MemberViewModel member, string token);
    }
}