using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using TreadBeans;
using TreadBeans.Sections;
using TreadBeans.ViewModels;

namespace TreadBeans.Views
{
    public sealed partial class BlogListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public BlogListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new BlogConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
