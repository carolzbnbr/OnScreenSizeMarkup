using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics.Text;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;

namespace OnScreenSizeMarkup.Maui;


/// <summary>
/// Markup extension that allows specify values to be applied to a physical screen size according to the category
/// the screen it fits in, such as ExtraSmall, Small, Medium, Large, ExtraLarge, or Default.
/// </summary>
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
[SuppressMessage("ReSharper", "UseStringInterpolation")]
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
		Default = defaultNull;
		this.FallbackType = null!;
	}

	public Type? FallbackType { get; set; }


	//public static OnScreenSizeExtension Create(Type type, object defaultSize, object extraSmall, object small, object medium, object large, object extraLarge = new())
	//{
	//	var instance = new OnScreenSizeExtension(type);
	//	instance.categoryPropertyValues = categoryPropertyValues;
	//	return instance;
	//}


	/// <summary>
	/// Default value assumed when the other property values were not provided for the current device. 
	/// </summary>
	public object Default { get; set; }


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


	/// <summary>
	/// Xaml internal usage
	/// </summary>
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		if (serviceProvider == null)
		{
			throw new ArgumentException($"Service provided for OnScreenSize is null");
		}

		var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException($"Service provided for OnScreenSize is null");

		BindableProperty bp;
		PropertyInfo pi = null!;

		if (valueProvider.TargetObject is Setter setter)
		{
			bp = setter.Property;
		}
		else
		{
			bp = (valueProvider.TargetProperty as BindableProperty)!;
			pi = (valueProvider.TargetProperty as PropertyInfo)!;
		}
		
		LogHelpers.WriteLine($"Providing Value using propertyType:\"{(bp?.ReturnType ?? pi?.PropertyType ?? null)}\" and BindableProperty:{(bp ?? null)}", LogLevels.Verbose);

		// Resolve StaticResource if needed
		var value = ResolveStaticResource(serviceProvider, ExtractValueBasedOnScreenCategory(ScreenCategoryHelper.GetCategory()));
		
		var propertyType = DeterminePropertyType(bp, pi);
		 
		return value!.ConvertTo(propertyType, bp!);
	}

	private Type DeterminePropertyType(BindableProperty? bp, PropertyInfo? pi)
	{
		return bp?.ReturnType ?? pi?.PropertyType ?? FallbackType ?? throw new InvalidOperationException($"Could not infer the return type for the property that you are applying the markup to. Please ensure that the property has a valid return type and that it is accessible. In some cases, you may need to set the \"{nameof(FallbackType)}\" property explicitly to specify the return type of the property. If you continue to experience this issue, please review your code and try again.");
	}
	
	/// <summary>
	/// Extracts a value based on the current screen category, taking into account the different size categories.
	/// </summary>
	/// <param name="category">The screen category used to determine the appropriate value.</param>
	/// <returns>The value corresponding to the specified screen category.</returns>
	/// <exception cref="ArgumentException">Thrown when the specified category does not have an associated value.</exception>
	/// <exception cref="XamlParseException">Thrown when the specified category does not have an associated value.</exception>
#pragma warning disable IDE0040
	private object ExtractValueBasedOnScreenCategory(ScreenCategories category)
#pragma warning restore IDE0040
	{
		if (category != ScreenCategories.NotSet)
		{
			if (categoryPropertyValues[category] != defaultNull)
			{
				return categoryPropertyValues[category]!;
			}
		}

		if (Default == defaultNull)
		{
			throw new XamlParseException(string.Format("{0} requires property {0}.{1} defined to use as fallback as property {0}.{2} was not set.", nameof(OnScreenSizeExtension), nameof(Default), category.ToString()));
		}
		return Default;
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
}