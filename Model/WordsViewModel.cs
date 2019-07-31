using System.Collections.Generic;

namespace vocabularyManagementTool.Model
{
    public class WordsViewModel
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string Mean { get; set; }
        public bool Status { get; set; }
        public int Version { get; set; }
    }

    public class WordsViewModelByWebApi {
        public List<WordsViewModel> success {get; set;}
    }
}