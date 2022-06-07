using System.Collections.Generic;
using OnScreenSizeMarkup.Core;
using Xamarin.Forms;

namespace OnScreenSizeMarkup.Forms
{


    public abstract class OnScreenSizeExtensionBase<T>
    {
        protected static object defaultNull = default(T);
        
        protected  Dictionary<ScreenCategories, T> _values = new () {
            { ScreenCategories.ExtraSmall, default(T)},
            { ScreenCategories.Small, default(T)},
            { ScreenCategories.Medium,  default(T)},
            { ScreenCategories.Large,  default(T)},
            { ScreenCategories.ExtraLarge,  default(T)},
        };
       
        protected Dictionary<ScreenCategories, bool> _valuesDefinitionIndicator = new () {
            { ScreenCategories.ExtraSmall, false},
            { ScreenCategories.Small, false},
            { ScreenCategories.Medium,  false},
            { ScreenCategories.Large,  false},
            { ScreenCategories.ExtraLarge,  false},
        };



        /// <summary>
        /// Tamanho-padrao na tela que deve ser assumido quando não for possivel determinar o tamanho dela com base na lista <see cref="_screenSizes"/>
        /// </summary>
        public T DefaultSize { get; set; }


        public IValueConverter Converter { get; set; }

        public object ConverterParameter { get; set; }

        public T ExtraSmall
        {
            get => _values[ScreenCategories.ExtraSmall];
            set
            {
                _values[ScreenCategories.ExtraSmall] = value;
                _valuesDefinitionIndicator[ScreenCategories.ExtraSmall] = true;
            }
        }

        public T Small
        {
            get => _values[ScreenCategories.Small];
            set
            {
                _values[ScreenCategories.Small] = value;
                _valuesDefinitionIndicator[ScreenCategories.Small] = true;
            }
        }

        public T Medium
        {
            get => _values[ScreenCategories.Medium];
            set
            {
                _values[ScreenCategories.Medium] = value;
                _valuesDefinitionIndicator[ScreenCategories.Medium] = true;
            }
        }

        public T Large
        {
            get => _values[ScreenCategories.Large];
            set
            {
                _values[ScreenCategories.Large] = value;
                _valuesDefinitionIndicator[ScreenCategories.Large] = true;
            }
        }

        public T ExtraLarge
        {
            get => _values[ScreenCategories.ExtraLarge];
            set
            {
                _values[ScreenCategories.ExtraLarge] = value;
                _valuesDefinitionIndicator[ScreenCategories.ExtraLarge] = true;
            }
        }


    }
}