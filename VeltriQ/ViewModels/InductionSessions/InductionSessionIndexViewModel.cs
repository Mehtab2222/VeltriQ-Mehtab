namespace VeltriQ.ViewModels.InductionSessions
{
    public class InductionSessionIndexViewModel
    {
        public int SelectedProgramId { get; set; }

        public List<InductionSessionListItemViewModel> Sessions { get; set; }
            = new();
    }
}