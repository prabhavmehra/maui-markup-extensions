# Responsive UI Prototype

The prototype is meant to show some responsive ui samples along with a few markup extensions which you can incorporate to have similar functionality in your app.


# Markup Extension

## OnScreenSize

### Overview
The `OnScreenSize` markup extension in the `MauiMarkupExtension` namespaces simplifies creatinig responsive layouts based on pre-defined `breakpoints` for each screen size.

### Getting Started

1. **Include the Extension in Your Project:**
   - Copy the `OnScreenSizeExtension.cs` and `OnScreenSizeSource.cs` file into your MAUI project.
    -  `Breakpoints` (required) **These are app window dimensions, not the device dimensons.**
        - ExtraLarge : Monitors
        - Large: Full-size Desktop, Bigger Tablets
        - Medium: Resized Desktop screen (medium), Medium sized tablets
        - Small: Phone
        - ExtraSmall: Smart watch.

    -  `PageWidth` (required)
        - Send resize (Width) updates of Page and View to markup extension to calculate required value of control.
            1. declare a name on the Page or View  `x:Name="Name"` and use accordingly
               ```xml
                    PageWidth={Binding Width,
                        Source={x:Reference MonkeyPage}}
               ```
            2. Add a reference to the Page/View directly 
             ```xml 
                    PageWidth={Binding Width, Source={RelativeSource AncestorType={x:Type ContentPage}}} 
             ```

    -  `TypeConverter` (optional)
        - Convert string value to required type, if needed. 


2. **Usage in XAML:**
   - In your XAML file, add the namespace where you've placed the extension:
     ```xml
     xmlns:extension="clr-namespace:namespace.Extensions"
     x:Name="MonkeyPage"
     ```
   - Utilize the extension in your `Grid` definitions:
     ```xml
     <Grid  ColumnDefinitions="{extension:OnScreenSize Default='*',
                                                       ExtraLarge='400',
                                                       Large='400',
                                                       Medium='250',
                                                       Small='*',
                                                       ExtraSmall='*',
                                                       PageWidth={Binding Width,
                                                                          Source={x:Reference MonkeyPage}},
                                                       TypeConverter={x:Type ColumnDefinitionCollectionTypeConverter}}"
           
           RowSpacing="16">
         <!-- Your layout content goes here -->
     </Grid>
     ```
     
     You don't have to specify values for all breakpoints, there is a fallback login which works as following:
        1. If no value specified, `Default` value will be assigned for all screen sizes.
        2. Specify a value for a `breakpoint`, the bigger screen size will fallback to that value, unless specified.
           example:
           ```xml
            IsVisible="{extension:OnScreenSize 'False',
                                               Medium='True',
                                               ExtraSmall='False'
                                               PageWidth={Binding Width,
                                                                  Source={x:Reference MonkeyPage}}}"
           ```
           With the above, the `Large` and `ExtraLarge` breakpoint will take the value for `Medium`. Similarly, `Small` will fallback to `ExtraSmall` value.
   

   - Customize a `Control` for each screen size as needed.
   - Specify a `TypeConverter` if needed to convert a string to required type, as done above.
   - Your can use it for all UI controls.
    
