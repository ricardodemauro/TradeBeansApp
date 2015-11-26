using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using TreadBeans;
using TreadBeans.Sections;
using TreadBeans.ViewModels;

namespace TreadBeans.Views
{
    public sealed partial class GalleryListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, Gallery1Schema> ViewModel { get; set; }

        public GalleryListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, Gallery1Schema>(new GalleryConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
