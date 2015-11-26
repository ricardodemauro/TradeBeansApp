using System;
using System.Collections.Generic;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using Windows.Storage;
using TreadBeans.Config;
using TreadBeans.ViewModels;

namespace TreadBeans.Sections
{
    public class GalleryConfig : SectionConfigBase<DynamicStorageDataConfig, Gallery1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, Gallery1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<Gallery1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=e7ba9ee8-a677-4fa4-8f0b-e56c1741c3d9&appId=4f8c5fc2-7c8e-4561-9730-0f47dea72222"),
                    AppId = "4f8c5fc2-7c8e-4561-9730-0f47dea72222",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("GalleryListPage");
            }
        }

        public override ListPageConfig<Gallery1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Gallery1Schema>
                {
                    Title = "gallery",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = null;
                        viewModel.SubTitle = null;
                        viewModel.Description = null;
                        viewModel.Image = item.Image.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("GalleryDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<Gallery1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Gallery1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = "";
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<Gallery1Schema>>
				{
				};

                return new DetailPageConfig<Gallery1Schema>
                {
                    Title = "gallery",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "gallery"; }
        }

    }
}
