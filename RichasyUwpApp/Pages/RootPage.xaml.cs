// Copyright (c) Richasy. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;
using Splat;
using Windows.ApplicationModel.Activation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace $safeprojectname$.Pages
{
    /// <summary>
    /// The page is used for default loading.
    /// </summary>
    public sealed partial class RootPage : RootPageBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Current = this;
            Loaded += OnLoaded;
            SizeChanged += OnSizeChanged;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        /// <summary>
        /// 根页面实例.
        /// </summary>
        public static RootPage Current { get; private set; }

        /// <summary>
        /// 显示顶层视图.
        /// </summary>
        /// <param name="element">要显示的元素.</param>
        public void ShowOnHolder(UIElement element)
        {
            if (!HolderContainer.Children.Contains(element))
            {
                HolderContainer.Children.Add(element);
            }

            HolderContainer.Visibility = Visibility.Visible;

            ViewModel.AddBackStack(
                BackBehavior.ShowHolder,
                ele =>
                {
                    RemoveFromHolder((UIElement)ele);
                },
                element);

            if (element is Control e)
            {
                e.Focus(FocusState.Programmatic);
            }
        }

        /// <summary>
        /// 显示提示信息，并在指定延时后关闭.
        /// </summary>
        /// <param name="element">要插入的元素.</param>
        /// <param name="delaySeconds">延时时间(秒).</param>
        /// <returns><see cref="Task"/>.</returns>
        public async Task ShowTipAsync(UIElement element, double delaySeconds)
        {
            TipContainer.Visibility = Visibility.Visible;
            TipContainer.Children.Add(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
            element.Visibility = Visibility.Collapsed;
            TipContainer.Children.Remove(element);
            if (TipContainer.Children.Count == 0)
            {
                TipContainer.Visibility = Visibility.Collapsed;
            }
        }

        /// <inheritdoc/>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 导航事件.
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            CoreViewModel.InitializePadding();
#if !DEBUG
            CoreViewModel.CheckUpdateCommand.Execute().Subscribe();
#endif
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
            => CoreViewModel.InitializePadding();

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            Back();
        }

        private void OnRequestShowTip(object sender, AppTipNotificationEventArgs e)
           => new TipPopup(e.Message).ShowAsync(e.Type);

        private void Back()
        {
            if (ViewModel.CanBack)
            {
                ViewModel.BackCommand.Execute().Subscribe();
            }
        }
    }

    /// <summary>
    /// <see cref="RootPage"/> 的基类.
    /// </summary>
    public class RootPageBase : AppPage<NavigationViewModel>
    {
    }
}
