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
    public class OurProductsConfig : SectionConfigBase<DynamicStorageDataConfig, OurProducts1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, OurProducts1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<OurProducts1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=e1be1849-a2ce-48e9-9351-2a1bdcc0c72d&appId=4f8c5fc2-7c8e-4561-9730-0f47dea72222"),
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
                return NavigationInfo.FromPage("OurProductsListPage");
            }
        }

        public override ListPageConfig<OurProducts1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<OurProducts1Schema>
                {
                    Title = "our products",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                        viewModel.Description = item.Description.ToSafeString();
                        viewModel.Image = item.Image.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("OurProductsDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<OurProducts1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, OurProducts1Schema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Subtitle.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = item.Image.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<OurProducts1Schema>>
				{
				};

                return new DetailPageConfig<OurProducts1Schema>
                {
                    Title = "our products",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "our products"; }
        }

    }
}
