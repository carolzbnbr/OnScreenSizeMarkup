using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using OnScreenSizeMarkup.Maui.Extensions;

namespace OnScreenSizeMarkup.Maui;

public class OnScreenSize : IMarkupExtension<object>
{

	static readonly object defaultNull = new ();

#pragma warning disable IDE0040
	private Dictionary<ScreenCategories, object> categoryPropertyValues = new () {
#pragma warning restore IDE0040
		{ ScreenCategories.ExtraSmall, defaultNull},
		{ ScreenCategories.Small, defaultNull},
		{ ScreenCategories.Medium,  defaultNull},
		{ ScreenCategories.Large,  defaultNull},
		{ ScreenCategories.ExtraLarge,  defaultNull},
	};


	public OnScreenSize()
	{
		DefaultSize = defaultNull;
	}

	/// <summary>
	/// Default value assumed when the other property values were not provided for the current device. 
	/// </summary>
	public object DefaultSize { get; set; }


	public object ExtraSmall
	{
		get => categoryPropertyValues[ScreenCategories.ExtraSmall]!;
		set => categoryPropertyValues[ScreenCategories.ExtraSmall] = value;
	}

	public object Small
	{
		get => categoryPropertyValues[ScreenCategories.Small]!;
		set => categoryPropertyValues[ScreenCategories.Small] = value;
	}
	public object Medium
	{
		get => categoryPropertyValues[ScreenCategories.Medium]!;
		set => categoryPropertyValues[ScreenCategories.Medium] = value;
	}

	public object Large
	{
		get => categoryPropertyValues[ScreenCategories.Large]!;
		set => categoryPropertyValues[ScreenCategories.Large] = value;
	}

	public object ExtraLarge
	{
		get => categoryPropertyValues[ScreenCategories.ExtraLarge]!;
		set => categoryPropertyValues[ScreenCategories.ExtraLarge] = value;
	}


	
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		"ProvideValue - Step 1...".WriteToLog();
		
		var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException($"Service provided for OnScreenSize is null");

		BindableProperty bp;
		PropertyInfo pi = null!;

		"ProvideValue - Step 2...".WriteToLog();
		
		if (valueProvider.TargetObject is Setter setter)
		{
			bp = setter.Property;
		}
		else
		{
			bp = (valueProvider.TargetProperty as BindableProperty)!;
			pi = (valueProvider.TargetProperty as PropertyInfo)!;
		}

		if (Manager.Current.IsDebugMode)
		{
			var log1 =$"Providing Value using propertyType:\"{(bp?.ReturnType ?? pi?.PropertyType ?? null)}\" and BindableProperty:{(bp ?? null)}";
			log1.WriteToLog();
		}
		
		var propertyType = bp?.ReturnType ?? pi?.PropertyType ?? throw new InvalidOperationException("Não foi posivel determinar a propriedade para fornecer o valor.");

		var value = GetScreenCategoryPropertyValue(serviceProvider);


		return value!.ConvertTo(propertyType, bp!);
	}

	/// <summary>
	/// Gets a value from one of the properties that best suites a <see cref="ScreenCategories"/> a device fits in.
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <returns></returns>
	/// <exception cref="XamlParseException"></exception>
#pragma warning disable IDE0040
	private object GetScreenCategoryPropertyValue(IServiceProvider serviceProvider)
#pragma warning restore IDE0040
	{
		var screenCategory = ScreenCategoryExtension.GetCategory();
		if (screenCategory != ScreenCategories.NotSet)
		{
			if (categoryPropertyValues[screenCategory] != defaultNull)
			{
				return categoryPropertyValues[screenCategory]!;
			}
		}

		if (DefaultSize == defaultNull)
		{
			throw new XamlParseException($"{nameof(OnScreenSize)} markup requires a {nameof(DefaultSize)} set.");
		}
		else
		{
			return DefaultSize;
		}
	}


}