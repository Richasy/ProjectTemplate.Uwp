// Copyright (c) Richasy. All rights reserved.

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace $safeprojectname$.Controls.App
{
    /// <summary>
    /// 应用搜索框.
    /// </summary>
    public sealed partial class AppSearchBox : AppSearchBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppSearchBox"/> class.
        /// </summary>
        public AppSearchBox()
        {
            InitializeComponent();
            CoreViewModel = Locator.Current.GetService<AppViewModel>();
        }

        private AppViewModel CoreViewModel { get; }

        private void OnSearchBoxSubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            // TODO: 搜索.
        }
    }

    /// <summary>
    /// <see cref="AppSearchBox"/> 的基类.
    /// </summary>
    public class AppSearchBoxBase : ReactiveUserControl<AppViewModel>
    {
    }
}
