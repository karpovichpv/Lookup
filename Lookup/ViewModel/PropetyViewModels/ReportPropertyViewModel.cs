using Lookup.TSProperties.UserProperties;

namespace Lookup.ViewModel.PropetyViewModels
{
    public class ReportPropertyViewModel : PropertyViewModelBase
    {
        public ReportPropertyViewModel()
        {
            _getter = new UserPropertyGetter();
            Mediator.GetInstance().SetReportPropertiesModel(this);
        }
    }
}