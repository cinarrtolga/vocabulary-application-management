namespace vocabularyManagementTool.Model
{
    public class MemberViewModel{
        public string Username {get; set;}
        public string Password {get; set;}
    }

    public class MemberResponseViewModel {
        public int MemberId {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public bool Status {get; set;}
    }

    public class MemberViewModelByWebApi {
        public MemberResponseViewModel success {get; set;}
    }
}