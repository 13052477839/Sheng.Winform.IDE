﻿/*********************************************        
作者：曹旭升              
QQ：279060597
访问博客了解详细介绍及更多内容：   
http://blog.shengxunwei.com
**********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;
using Sheng.SailingEase.Components.NavigationComponent.Localisation;
using Sheng.SailingEase.Components.NavigationComponent.View;
using Sheng.SailingEase.Controls.Extensions;
using Sheng.SailingEase.Infrastructure;
using Sheng.SailingEase.Kernal;
namespace Sheng.SailingEase.Components.NavigationComponent
{
    public class NavigationComponent : IModule
    {
        IUnityContainer _container;
        INavigationService _navigationService;
        IProjectService _projectService;
        IEventAggregator _eventAggregator;
        IWorkbenchService _workbenchService;
        public NavigationComponent(IUnityContainer container, IEventAggregator eventAggregator, IWorkbenchService workbenchService)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _workbenchService = workbenchService;
            _navigationService = _container.Resolve<INavigationService>();
            _projectService = _container.Resolve<IProjectService>();
        }
        public void Initialize()
        {
            ConfigureContainer();
            RegisterNavigationItem();
            SubscribeEvent();
        }
        private void RegisterNavigationItem()
        {
            Func<IToolStripItemCodon, bool> projectIsOpend = (codon) => { return _projectService.Current != null; };
            _navigationService.RegisterMenu("Main/Edit[4]", new ToolStripMenuItemCodon("Dictionary",
                Language.Current.Navigation_Menu_MainMenu, Resources.Menu,
                  (sender, codon) => { _workbenchService.Show<ExplorerView>(ExplorerView.SINGLEKEY); })
            {
                IsEnabled = projectIsOpend
            });
            _navigationService.RegisterToolStrip("Main", new ToolStripButtonCodon("Dictionary",
                Language.Current.Navigation_ToolStrip_MainMenu, Resources.Menu,
                (sender, e) => { _workbenchService.Show<ExplorerView>(ExplorerView.SINGLEKEY); })
            {
                IsEnabled = projectIsOpend
            });
        }
        private void ConfigureContainer()
        {
            _container.RegisterInstance<MenuStripArchive>(MenuStripArchive.Instance);
            _container.RegisterInstance<ToolStripArchive>(ToolStripArchive.Instance);
            IArchiveServiceUnity archiveServiceUnity = _container.Resolve<IArchiveServiceUnity>();
            archiveServiceUnity.Register(MenuStripArchive.Instance);
            archiveServiceUnity.Register(ToolStripArchive.Instance);
        }
        private void SubscribeEvent()
        {
        }
    }
}
