using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TreadBeans;
using TreadBeans.Sections;
using TreadBeans.ViewModels;

namespace TreadBeans.Views
{
    public sealed partial class TopProductsListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, TopProducts1Schema> ViewModel { get; set; }

        public TopProductsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, TopProducts1Schema>(new TopProductsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
