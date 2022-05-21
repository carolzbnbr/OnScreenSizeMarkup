
[![NuGet Stats](https://img.shields.io/nuget/v/OnScreenSizeMarkup.Forms?style=plastic)](https://www.nuget.org/packages/OnScreenSizeMarkup.Forms) 

This project is based on a [post](https://thenextloop.com/2021/01/03/adaptive-page-layouts-to-different-device-screen-sizes-for-xamarin-apps/) I wrote a long time ago for my [blog](https://www.thenextloop.com).

## OnScreenSizeMarkup: A XAML markup extension

OnScreenSizeMarkup is XAML markup extension for controlliing UI elements depending on the device screen size category.

### Where can I use it?

OnScreenSizeMarkup is currently compatible with:

* Xamarin.Forms
* MAUI (comming soon)

### What does that mean? 

It works exactly as other markup extensions such as *OnPlatform* or *OnIdiom*, allowing you to control UI views accordding to the screen sizes category a device fits in.

## Screen Categories

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
         <Grid RowDefinitions="{markups:OnScreenSize Large='200, *, 200', 
                                                     ExtraLarge='300, *, 300',
                                                     DefaultSize='100, *, 100'}">
            ....
         </Grid>
    </ContentPage.Content>
</ContentPage>  
```

In the above example we are defining a Grid with 3 rows. If the device that is running the markup is categorized as `Medium`, a RowDefinitions's value will be defined to `200, *, 200`. At the same time, if the device size is `ExtraLarge` a RowDefinitions's value will be defined as `300, *, 300'`. For the other devices sizes it will be used the `DefaultValue` which is `100, *, 100`.


## The magic

Most of the time you don't need do implement anything in order to categorize the screen sizes, as the markup is backed by a `Default Category fallback handler` instance class, but there may be times that you may need to override/customize the screen size categorization with your own rules, thats when the **Category Fallback Handlers** comes to the rescue.
  
### Category fallback handlers

A category fallback handler is a class that implements `ICategoryFallbackHandler` composed of two methods which returns a `ScreenCategories` enum (`ExtraSmall`, `Small`, `Medium`, `Large`, `ExtraLarge`) based on device's model, or device's physical screen size (Width/Height):

* `TryGetCategoryByDeviceModel` - Returns a screen category by the device-model.
* `TryGetCategoryByPhysicalSize` - Returns a screen category by screen measures (width/height).

Due to some incorrect screen size info returned by some iOS simulator devices during development and tests, it was not possible to depend only on the screen size measures for categorize screens, and in order to fix that, it was intruduced `TryGetCategoryByDeviceModel` method, which based on the device's model we can confidently categorize a screen.

The Markup first attempts to execute `TryGetCategoryByDeviceModel` by passing the device's model, and in case it returns false, it tries to execute `TryGetCategoryByPhysicalSize` by passing a device screen size (Width/Height).

 For getting either the device model or the device size I use [Xamarin.Essentials](https://docs.microsoft.com/en-us/xamarin/essentials/device-information?tabs=ios).


If you need to implement your own handler you **MUST** set its instance during the app app initialization as follow:

```cs
    OnScreenSizeMarkup.Core.Manager.Current.Handler = new MyNewFallBackHandlerClass();
```

 
### Default Category fallback handler

The markup comes with a `DefaultFallBackHandler` class which maps most iOS devices models and screens sizes (for android devices).

Here is a dictionary of the device models and it's categories mapping we currently have:

```cs
            { "iPhone1_1", ScreenCategories.Small },
            { "iPhone1,2",  ScreenCategories.Small },
            { "iPhone2,1", ScreenCategories.Small },
            { "iPhone3,1", ScreenCategories.Small  },
            { "iPhone3,2", ScreenCategories.Small },
            { "iPhone3,3", ScreenCategories.Small },
            { "iPhone4,1",  ScreenCategories.Small },
            { "iPhone5,1",  ScreenCategories.Small },
            { "iPhone5,2", ScreenCategories.Small },
            { "iPhone5,3",  ScreenCategories.Small  },
            { "iPhone5,4", ScreenCategories.Small  },
            { "iPhone6,1",  ScreenCategories.Small},
            { "iPhone6,2",  ScreenCategories.Small  },
            { "iPhone7,1", ScreenCategories.Large },
            { "iPhone7,2", ScreenCategories.Medium },
            { "iPhone8,1",  ScreenCategories.Medium  },
            { "iPhone8,2", ScreenCategories.Large  },
            { "iPhone8,4", ScreenCategories.Medium  },
            { "iPhone9,1", ScreenCategories.Medium },
            { "iPhone9,2",  ScreenCategories.Large },
            { "iPhone9,3",  ScreenCategories.Medium },
            { "iPhone9,4", ScreenCategories.Large },
            { "iPhone10,1", ScreenCategories.Medium },
            { "iPhone10,2", ScreenCategories.Large },
            { "iPhone10,3", ScreenCategories.Medium },
            { "iPhone10,4", ScreenCategories.Medium },
            { "iPhone10,5", ScreenCategories.Large },
            { "iPhone10,6", ScreenCategories.Medium },
            { "iPhone11,2", ScreenCategories.Medium },
            { "iPhone11,4", ScreenCategories.Large },
            { "iPhone11,6", ScreenCategories.Large },
            { "iPhone11,8", ScreenCategories.Medium },
            { "iPhone12,1", ScreenCategories.Medium },
            { "iPhone12,3",  ScreenCategories.Medium },
            { "iPhone12,5", ScreenCategories.Large },
            { "iPhone12,8", ScreenCategories.Medium },
            { "iPhone13,1", ScreenCategories.Medium },
            { "iPhone13,2", ScreenCategories.Medium },
            { "iPhone13,3", ScreenCategories.Medium }, 
            { "iPhone13,4", ScreenCategories.Large },
            { "iPhone14,2", ScreenCategories.Medium },
            { "iPhone14,3", ScreenCategories.Large },
            { "iPhone14,4", ScreenCategories.Medium },
            { "iPhone14,5", ScreenCategories.Medium },
            { "Pad12,2",    ScreenCategories.ExtraLarge },
            { "iPad_9th_Gen", ScreenCategories.ExtraLarge },
            { "iPad1,2",  ScreenCategories.ExtraLarge },
            { "iPad2,1", ScreenCategories.ExtraLarge },
            { "iPad2,2", ScreenCategories.ExtraLarge },
            { "iPad2,3",  ScreenCategories.ExtraLarge },
            { "iPad2,4", ScreenCategories.ExtraLarge },
            { "iPad2,5", ScreenCategories.ExtraLarge },
            { "iPad2,6", ScreenCategories.ExtraLarge },
            { "iPad2,7", ScreenCategories.ExtraLarge },
            { "iPad3,1", ScreenCategories.ExtraLarge },
            { "iPad3,2", ScreenCategories.ExtraLarge },
            { "iPad3,3", ScreenCategories.ExtraLarge },
            { "iPad3,4", ScreenCategories.ExtraLarge },
            { "iPad3,5", ScreenCategories.ExtraLarge },
            { "iPad3,6", ScreenCategories.ExtraLarge },
            { "iPad4,1", ScreenCategories.ExtraLarge },
            { "iPad4,2", ScreenCategories.ExtraLarge },
            { "iPad4,3", ScreenCategories.ExtraLarge },
            { "iPad4,4", ScreenCategories.ExtraLarge },
            { "iPad4,5", ScreenCategories.ExtraLarge },
            { "iPad4,6", ScreenCategories.ExtraLarge },
            { "iPad4,7", ScreenCategories.ExtraLarge },
            { "iPad4,8", ScreenCategories.ExtraLarge },
            { "iPad4,9", ScreenCategories.ExtraLarge },
            { "iPad5,1", ScreenCategories.ExtraLarge },
            { "iPad5,2", ScreenCategories.ExtraLarge },
            { "iPad5,3", ScreenCategories.ExtraLarge },
            { "iPad5,4", ScreenCategories.ExtraLarge },
            { "iPad6,4", ScreenCategories.ExtraLarge },
            { "iPad6,7",ScreenCategories.ExtraLarge },
            { "iPad6,8", ScreenCategories.ExtraLarge },
            { "iPad6,11", ScreenCategories.ExtraLarge }, 
            { "iPad6,12", ScreenCategories.ExtraLarge },
            { "iPad7,1", ScreenCategories.ExtraLarge },
            { "iPad7,2", ScreenCategories.ExtraLarge },
            { "iPad7,3", ScreenCategories.ExtraLarge },   
            { "iPad7,4", ScreenCategories.ExtraLarge },   
            { "iPad7,5", ScreenCategories.ExtraLarge },   
            { "iPad7,6", ScreenCategories.ExtraLarge },   
            { "iPad7,11", ScreenCategories.ExtraLarge },   
            { "iPad7,12", ScreenCategories.ExtraLarge },
            { "iPad8,1", ScreenCategories.ExtraLarge },   
            { "iPad8,2", ScreenCategories.ExtraLarge },   
            { "iPad8,3", ScreenCategories.ExtraLarge },   
            { "iPad8,4", ScreenCategories.ExtraLarge},   
            { "iPad8,5", ScreenCategories.ExtraLarge },   
            { "iPad8,6", ScreenCategories.ExtraLarge },   
            { "iPad8,7", ScreenCategories.ExtraLarge },   
            { "iPad8,8", ScreenCategories.ExtraLarge },   
            { "iPad8,9", ScreenCategories.ExtraLarge },   
            { "iPad8,10", ScreenCategories.ExtraLarge },   
            { "iPad8,11", ScreenCategories.ExtraLarge },   
            { "iPad8,12", ScreenCategories.ExtraLarge },   
            { "iPad11,1", ScreenCategories.ExtraLarge },   
            { "iPad11,2", ScreenCategories.ExtraLarge },   
            { "iPad11,3", ScreenCategories.ExtraLarge },   
            { "iPad11,4", ScreenCategories.ExtraLarge },   
            { "iPad11,6", ScreenCategories.ExtraLarge },   
            { "iPad11,7", ScreenCategories.ExtraLarge },   
            { "iPad12,1", ScreenCategories.ExtraLarge },   
            { "iPad12,2", ScreenCategories.ExtraLarge },   
            { "iPad13,1", ScreenCategories.ExtraLarge },   
            { "iPad13,2", ScreenCategories.ExtraLarge },   
            { "iPad13,4", ScreenCategories.ExtraLarge },   
            { "iPad13,5", ScreenCategories.ExtraLarge },   
            { "iPad13,6", ScreenCategories.ExtraLarge },   
            { "iPad13,7", ScreenCategories.ExtraLarge },   
            { "iPad13,8", ScreenCategories.ExtraLarge },   
            { "iPad13,9", ScreenCategories.ExtraLarge },   
            { "iPad13,10", ScreenCategories.ExtraLarge },   
            { "iPad13,11", ScreenCategories.ExtraLarge },
            { "iPad14,1", ScreenCategories.ExtraLarge },   
            { "iPad14,2", ScreenCategories.ExtraLarge },
```


Also, for other devices like Android devices, here is the mapping based on the screen size:

```cs
  private static ScreenSizeInfo[] screenSizeCategories = new ScreenSizeInfo[]
    {
        new ScreenSizeInfo(480,800, ScreenCategories.ExtraSmall), 
        new ScreenSizeInfo(720,1280, ScreenCategories.Small), 
        new ScreenSizeInfo(750,1334, ScreenCategories.Medium), 
        new ScreenSizeInfo(1125,2436, ScreenCategories.Medium),
        new ScreenSizeInfo(828,1792, ScreenCategories.Medium),
        new ScreenSizeInfo(1080,1920, ScreenCategories.Large),
        new ScreenSizeInfo(1242,2688, ScreenCategories.Large),
        new ScreenSizeInfo(1284,2778, ScreenCategories.Large),
        new ScreenSizeInfo(1440,3200, ScreenCategories.ExtraLarge),
        new ScreenSizeInfo(2732,2048, ScreenCategories.ExtraLarge),
    };
```


### Points of attention

There are some custom Xamarin.Forms types such as `Xamarin.Forms.Color` in which it's value conversion are not currently supported which leads the markup to handle incorrectly these types.

I intent to implement these value conversions along the time.
