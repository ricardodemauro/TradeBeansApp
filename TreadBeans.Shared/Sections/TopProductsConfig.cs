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
    public class TopProductsConfig : SectionConfigBase<DynamicStorageDataConfig, TopProducts1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, TopProducts1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<TopProducts1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=9040dbbe-fc87-46bb-890e-43610b1f6d1e&appId=4f8c5fc2-7c8e-4561-9730-0f47dea72222"),
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
                return NavigationInfo.FromPage("TopProductsListPage");
            }
        }

        public override ListPageConfig<TopProducts1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<TopProducts1Schema>
                {
                    Title = "top products",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = item.Image.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("TopProductsDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<TopProducts1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, TopProducts1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "image";
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = "";
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = "info";
                    viewModel.Title = "";
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = "";
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<TopProducts1Schema>>
				{
				};

                return new DetailPageConfig<TopProducts1Schema>
                {
                    Title = "top products",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "top products"; }
        }

    }
}
