using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TreadBeans;
using TreadBeans.Sections;
using TreadBeans.ViewModels;

namespace TreadBeans.Views
{
    public sealed partial class OurProductsListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, OurProducts1Schema> ViewModel { get; set; }

        public OurProductsListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, OurProducts1Schema>(new OurProductsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
