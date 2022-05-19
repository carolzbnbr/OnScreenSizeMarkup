
[![NuGet Stats](https://img.shields.io/nuget/v/OnScreenSizeMarkup.Forms?style=plastic)](https://www.nuget.org/packages/OnScreenSizeMarkup.Forms) 



## OnScreenSizeMarkup: A XAML markup extension

OnScreenSizeMarkup is XAML a markup extension for controlliing UI elements depending on the device screen size.

### Where can I use it?

OnScreenSizeMarkup is currently compatible with:

* Xamarin.Forms
* MAUI (comming soon)

### What does that mean? 

It works exactly as other markup extensions such as *OnPlatform* or *OnIdiom* , but it allow us to  control UI views accordding to the screen sizes of the devices, but without need to specify a width/height for every possible screen dimentions.

## Screen Sizes classifications

The screen sizes are classifies in six groups:

* `ExtraSmall` - Tiny devices as an Apple Watch.
* `Small` - Small devices, such as a Google Pixel 5.
* `Medium` - Medium devices such as IPhone 12.
* `Large` - Large devices such as an IPhone 13 Pro Max.
* `ExtraLarge` - Extra large devices such as tablets.
  
There is also a `DefaultSize` group that will be used in cases when some of the above options are used, in this case a default value will be applied for the missing options.

## Getting Started

Using OnScreenSizeMarkup is very straight foward, you can apply it to most UI View elements, such as Labels, Grids, Buttons, ImageButtons, and etc.

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

In the above example we are defining a Grid with 3 rows, but if the device size is medium, one value will be applied, otherwise a defaultSize valued will be used.


### Edge cases

I've tried to cover most use cases for screen sizes to be classified correctly, for most cases you don't need to know about the internal working of the markup,but there may be times that markup may incorrectly classify a specific physical device screen size, in cases like this you have three options:
  - File an issue here on github (slow option);

 - Get in touch with me on my [blog - TheNextLoop.com](https://thenextloop.com)  (slow option);
  
 - Implement your own version of the handler (Fastest)
  

### Implementing a handler

A handler is a class in which it's methods returns a  `ScreenSizeGroups` enum item after identifing a physical device screen size to its corresponding Markup `ScreenSizeGroups` enum.

Your handler may inherits from  `ScreenSizeHandler` class or implements `IScreenSizeHandler` interface on your own. Both the interface or the class contains the following methods which can be implemented or overrided:

* `TryGetSizeByDeviceModel` - Attempts to determine the screen size by a provided device-model. 
* `TryGetSizeByPhysicalSize` - Attempts to determine the screen-size by device's physical size (width/height)

After implementing your handler you must set its instance as follows:

```cs
    OnScreenSizeMarkup.Core.Manager.Current.Handler = new MyNewHandlerClass();
```

The above **MUST** be done on your app initialization, prior using the markup.

### Points of attention

There are some custom Xamarin.Forms types such as `Xamarin.Forms.Color` in which it's value conversion are not currently supported which leads the markup to handle incorrectly these types.

I intent to implement these value conversions along the time.