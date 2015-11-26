using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using TreadBeans;
using TreadBeans.Sections;
using TreadBeans.ViewModels;

namespace TreadBeans.Views

{
    public sealed partial class GalleryDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<DynamicStorageDataConfig, Gallery1Schema> ViewModel { get; set; }

        public GalleryDetailPage()
               : base(true)
        {
            this.ViewModel = new DetailViewModel<DynamicStorageDataConfig, Gallery1Schema>(new GalleryConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
