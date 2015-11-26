using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.DynamicStorage;
using TreadBeans.Sections;


namespace TreadBeans.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "TreadBeans";
            Info = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new InfoConfig(), visibleItems);
            TopProducts = new ListViewModel<DynamicStorageDataConfig, TopProducts1Schema>(new TopProductsConfig(), visibleItems);
            OurProducts = new ListViewModel<DynamicStorageDataConfig, OurProducts1Schema>(new OurProductsConfig(), visibleItems);
            Gallery = new ListViewModel<DynamicStorageDataConfig, Gallery1Schema>(new GalleryConfig(), visibleItems);
            Blog = new ListViewModel<RssDataConfig, RssSchema>(new BlogConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Info { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, TopProducts1Schema> TopProducts { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, OurProducts1Schema> OurProducts { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, Gallery1Schema> Gallery { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> Blog { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Info;
            yield return TopProducts;
            yield return OurProducts;
            yield return Gallery;
            yield return Blog;
        }
    }
}
