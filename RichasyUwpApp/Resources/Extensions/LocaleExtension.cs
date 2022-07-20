// Copyright (c) Richasy. All rights reserved.

using Splat;
using Windows.UI.Xaml.Markup;

namespace Bili.App.Resources.Extension
{
    /// <summary>
    /// Localized text extension.
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(string))]
    public sealed class LocaleExtension : MarkupExtension
    {
        /// <summary>
        /// Language name.
        /// </summary>
        public LanguageNames Name { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            // 需要添加项目引用.
            return Locator.Current.GetService<IResourceToolkit>()
                                          .GetLocaleString(Name);
        }
    }
}
