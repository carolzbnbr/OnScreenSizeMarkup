
[![NuGet Stats](https://img.shields.io/nuget/v/OnScreenSizeMarkup.Forms?style=plastic)](https://www.nuget.org/packages/OnScreenSizeMarkup.Forms) 



## OnScreenSizeMarkup: A XAML markup extension

OnScreenSizeMarkup is XAML markup extension for controlliing UI elements depending on the device screen size category.

### Where can I use it?

OnScreenSizeMarkup is currently compatible with:

* Xamarin.Forms
* MAUI (comming soon)

### What does that mean? 

It works exactly as other markup extensions such as *OnPlatform* or *OnIdiom*, allowing you to control UI views accordding to the screen sizes category a device fits in.

## Screen Sizes Categories

The screen sizes are grouped into six categories:

* `ExtraSmall` - Tiny devices as an Apple Watch.
* `Small` - Small devices, such as a Google Pixel 5.
* `Medium` - Medium devices such as IPhone 12.
* `Large` - Large devices such as an IPhone 13 Pro Max.
* `ExtraLarge` - Extra large devices such as tablets.

For each category we define specific value when using the markup on XAML.

There is also a `DefaultSize` category that should be used when only few category options are used in the markup properties, in this case a value defined in the `DefaultSize` property will be applied for the missing options.

## Getting Started

Using the markup is very straight foward, you can apply it to most UI View elements, such as Labels, Grids, Buttons, ImageButtons, and etc.

Take a look on the sample code below:

```cs

<ContentPage  
            xmlns:markups="clr-namespace:OnScreenSizeMarkup.Forms;assembly=OnScreenSizeMarkup.Forms">
    <ContentPage.Content>
         <Grid RowDefinitions="{markups:OnScreenSize Medium='200, *, 200', DefaultSize='*, 0.5*, *'}">
            ....
         </Grid>
    </ContentPage.Content>
</ContentPage>  
```

In the above example we are defining a Grid with 3 rows, and if the device that is running the code fallsback into category `Medium`, a RowDefinitions's value will be defined to `200, *, 200`,  while the other devices will falback to the `DefaultValue` which is `*, 0.5*, *`.


### Edge cases

I've tried to cover most use cases for screen sizes to categorize them correctly, for most cases you don't need to know about the internal working of the markup,but there may be times that markup may incorrectly classify a specific physical device screen size, in cases like this you have three options:

 - Get in touch with me on my [blog - TheNextLoop.com](https://thenextloop.com)  (slower option);
  
  - File an issue here on github and provide me your device width/height or your device [device model](https://docs.microsoft.com/en-us/xamarin/essentials/device-information?tabs=ios) (slower option);

 - Implement your own version of the handler (Fastest option)
  

### Implementing a handler

A handler is a class in which it's methods returns a  `ScreenCategories` enum item after identifing a physical device screen size to its corresponding Markup `ScreenCategories` enum.

Your handler may inherits from `ScreenSizeHandler` class or implements `IScreenSizeHandler` interface. Either the interface or the class contains methods that can be implemented or overrided:

* `TryGetSizeByDeviceModel` - Attempts to determine the screen size by a provided device-model (Currently I'm using [Xamarin.Essentials](https://docs.microsoft.com/en-us/xamarin/essentials/device-information?tabs=ios) for retrieving the device-model). 
* `TryGetSizeByPhysicalSize` - Attempts to determine the screen-size by device's physical size (width/height)

After implementing your handler you must set its instance as follows:

```cs
    OnScreenSizeMarkup.Core.Manager.Current.Handler = new MyNewHandlerClass();
```

The above **MUST** be done on your app initialization, prior using the markup.

### Points of attention

There are some custom Xamarin.Forms types such as `Xamarin.Forms.Color` in which it's value conversion are not currently supported which leads the markup to handle incorrectly these types.

I intent to implement these value conversions along the time.
