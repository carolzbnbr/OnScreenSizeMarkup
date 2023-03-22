using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Core.Exceptions;
using OnScreenSizeMarkup.Forms.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnScreenSizeMarkup.Forms
{
    //[ContentProperty(nameof(TypeName))]
    public class OnScreenSizeExtension : IMarkupExtension<object>
    {
        static readonly object defaultNull = new();

        private Dictionary<ScreenCategories, object> categoryPropertyValues = new() {
        { ScreenCategories.ExtraSmall, defaultNull},
        { ScreenCategories.Small, defaultNull},
        { ScreenCategories.Medium,  defaultNull},
        { ScreenCategories.Large,  defaultNull},
        { ScreenCategories.ExtraLarge,  defaultNull},
    };

        /// <summary>
        /// Xaml internal usage
        /// </summary>
        public OnScreenSizeExtension()
        {
            DefaultSize = defaultNull;
        }

        /// <summary>
        /// Default value assumed when the other property values were not provided for the current device. 
        /// </summary>
        public object DefaultSize { get; set; }


        /// <summary>
        /// Defines a value used when the screen size is categorized as <see cref="ScreenCategories.ExtraSmall"/>
        /// </summary>
        public object ExtraSmall
        {
            get => categoryPropertyValues[ScreenCategories.ExtraSmall]!;
            set => categoryPropertyValues[ScreenCategories.ExtraSmall] = value;
        }
        /// <summary>
        /// Defines a value used when the screen size is categorized as <see cref="ScreenCategories.Small"/>
        /// </summary>
        public object Small
        {
            get => categoryPropertyValues[ScreenCategories.Small]!;
            set => categoryPropertyValues[ScreenCategories.Small] = value;
        }

        /// <summary>
        /// Defines a value used when the screen size is categorized as <see cref="ScreenCategories.Medium"/>
        /// </summary>
        public object Medium
        {
            get => categoryPropertyValues[ScreenCategories.Medium]!;
            set => categoryPropertyValues[ScreenCategories.Medium] = value;
        }

        /// <summary>
        /// Defines a value used when the screen size is categorized as <see cref="ScreenCategories.Large"/>
        /// </summary>
        public object Large
        {
            get => categoryPropertyValues[ScreenCategories.Large]!;
            set => categoryPropertyValues[ScreenCategories.Large] = value;
        }

        /// <summary>
        /// Defines a value used when the screen size is categorized as <see cref="ScreenCategories.ExtraLarge"/>
        /// </summary>
        public object ExtraLarge
        {
            get => categoryPropertyValues[ScreenCategories.ExtraLarge]!;
            set => categoryPropertyValues[ScreenCategories.ExtraLarge] = value;
        }



        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException();

            BindableProperty bp;
            PropertyInfo pi = null;
            Type propertyType = null;

            if (valueProvider.TargetObject is Setter setter)
            {
                bp = setter.Property;
            }
            else
            {
                bp = valueProvider.TargetProperty as BindableProperty;
                pi = valueProvider.TargetProperty as PropertyInfo;
            }

            propertyType = bp?.ReturnType ?? pi?.PropertyType ?? throw new InvalidOperationException("Não foi posivel determinar a propriedade para fornecer o valor.");

            var value = GetValue(serviceProvider);


            // Resolve StaticResource if needed
            value = ResolveStaticResource(serviceProvider, value);

            return value!.ConvertTo(propertyType, bp!);
        }

        private static object ResolveStaticResource(IServiceProvider serviceProvider, object value)
        {

            if (value is StaticResourceExtension staticResource)
            {
                var resolvedValue = staticResource.ProvideValue(serviceProvider);
                if (resolvedValue is string stringValue)
                {
                    return stringValue;
                }

                return resolvedValue;
            }
            else if (value is DynamicResourceExtension dynamicResource)
            {
                var resolvedValue = dynamicResource.ProvideValue(serviceProvider);
                if (resolvedValue is string stringValue)
                {
                    return stringValue;
                }

                return resolvedValue;
            }

            return value;
        }
        
        private object GetValue(IServiceProvider serviceProvider)
        {
            var screenSize = ScreenCategoryExtension.GetCategory();

            if (screenSize != ScreenCategories.NotSet)
            {
                if (categoryPropertyValues[screenSize] != defaultNull)
                {
                    return categoryPropertyValues[screenSize]!;
                }
            }

            if (DefaultSize == defaultNull)
            {
                throw new XamlParseException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(DefaultSize)} set.");
            }
            else
            {
                return DefaultSize;
            }
        }


    }
}