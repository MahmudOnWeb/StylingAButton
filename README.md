# Styling a button
### 11 July 2020

#### Table of contents
- [ Motivation](#Motivation)
- [ What you will be able to make if you follow entire article](#What-you-will-be-able-to-make-if-you-follow-entire-article)
- [ Prerequisites to follow the article](#Prerequisites-to-follow-the-article)
- [ Part One foundation localization and custom fonts](#Part-One-foundation-localization-and-custom-fonts)
   - [ Making simple solution ContentControl INotifyPropertyChanged and ICommand implementations](#Making-simple-solution-ContentControl-INotifyPropertyChanged-and-ICommand-implementations)
   - [ Adding localized content](#Adding-localized-content)
   - [ Typefaces Fonts Cultures  Languages](#Typefaces-Fonts-Cultures-Languages.)
   - [ Views](#Views)
   - [ Main View Model](#Main-View-Model)
   - [ Live preview end of part one](#Live-preview-end-of-part-one)
- [ Part Two Styling using a color palette Visual States instead of triggers](#Part-Two-Styling-using-a-color-palette-Visual-States-instead-of-triggers)
   - [ Basics](#Basics)
   - [ Choosing a color palette](#Choosing-a-color-palette)
   - [ Making simple layout for easier styling](#Making-simple-layout-for-easier-styling)
   - [ Making a control template](#Making-a-control-template)
   - [ Live preview end of part two](#Live-preview-end-of-part-two)
- [ Part Three Meet Inkscape Otherwise similar to part two but we change Foreground and style Focuses state](#Part-Three-Meet-Inkscape-Otherwise-similar-to-part-two-but-we-change-Foreground-and-style-Focuses-state)
   - [ Inkscape](#Inkscape)
   - [ Making the grid in Inkscape](#Making-the-grid-in-Inkscape)
   - [ Back to Blend Designing buttons suitable for blueprint](#Back-to-Blend-Designing-buttons-suitable-for-blueprint)
   - [ Making the Blueprint view](#Making-the-Blueprint-view)
   - [ Focused state](#Focused-state)
   - [ Making of control template](#Making-of-control-template)
   - [ Live preview end of part three](#Live-preview-end-of-part-three)
- [ Part Four Buttons and Windows colors Hello Animation](#Part-Four-Buttons-and-Windows-colors-Hello-Animation)
   - [ Getting Accent color and Accent color palette](#Getting-Accent-color-and-Accent-color-palette)
   - [ Animation More to come in following parts](#Animation-More-to-come-in-following-parts)
   - [ Live preview end of part four](#Live-preview-end-of-part-four)
- [ Part Five More paths more Inkscape](#Part-Five-More-paths-more-Inkscape)
   - [ Making paths in Inkscape](#Making-paths-in-Inkscape)
   - [ Adding some complications to our drawings](#Adding-some-complications-to-our-drawings)
   - [ How should our shape change when button is focused Or users hover over it](#How-should-our-shape-change-when-button-is-focused-Or-users-hover-over-it)
   - [ Making our drawing a single path so that it is easily used in Blend](#Making-our-drawing-a-single-path-so-that-it-is-easily-used-in-Blend)
   - [ Using created paths in buttons](#Using-created-paths-n-buttons)
   - [ Making the control template](#Making-the-control-template)
   - [ Making the demo view](#Making-the-demo-view)
   - [ Live preview end of part five](#Live-preview-end-of-part-five)
- [ Part Six and final Making Infographics like buttons](#Part-Six-and-final-Making-Infographics-like-buttons)
   - [ Design for usability](#Design-for-usability)
   - [ Summary of steps](#Summary-of-steps)
   - [ Step by step instructions](#Step-by-step-instructions)
   - [ What about Focused Mouse Over Pressed](#What-about-Focused-Mouse-Over-Pressed)
   - [ Live preview end of part six](#Live-preview-end-of-part-six)

## Motivation

Windows® is the most used desktop/laptop operating system. According Net Marketshare website Windows family of operation systems has about 87.82% market share, followed by MacOS with 9.42% and Linux family with about 2,18%, data for last month, history data before follow similar patterns, Windows OS share at times being even larger. Percentage till 100% is filed with Chrome OS, BSD and somehow mystic "Unknown".

There has to be a reason Windows have the biggest market share. And the reason is not one, but many. So making a native application for Windows even in our days, when most used devices are phones, 55.06%, and desktop/laptop, 40.16%, coming second, is still a valid choice. This article demonstrates how to customize the visual appearance of WPF buttons, for .NET core. This customization is achieved by creating custom control templates and on later stages in article, by using vector drawings.

Controls coming from WPF/Winforms are not styled, they are kind of base, on which you can build on. In order to have a visually appealing application, your team (-> you) either has to use some commerciallly available framework, which extends the base controls, or it has to use some open source UI framework, or to do it yourself. Commercial frameworks style ~~almost~~ everything - buttons, grids, combos, etc. They go even further - they extend controls, replace controls, add more functionality, strip some functionality, and even provide own custom controls. And they go even further, they provide some components, they force you to access databases in certain way, and after a while you might find that not only the GUI, but entire application is depending mainly on those controls libraries. Those libraries are however kind of standard, they are not build around one of the library manifacturer customer, but around many, and at the end those commercial libraries provide standard, common and ubiquitous user and developer experience. But if your application UI is so standard, why don't you migrate it to web? Almost every library provider has a web framework solution as well, so in most cases migration is seamless. The trend is clear here.

Open source UI frameworks are like commercial ones, but probably not so much tested and with less controls. About the qualities and recent development of such frameworks - I am thinking - can a team, consisted of newbies forced to work on very cool, but maybe legacy project can beat one or two weirdos, passionly making their own UI framework? I am not the person to decide. To wrap this paragraph up, let's say open source UI frameworks are kind of compromise between not paying for a commercial one and saving time and efforts not styling the controls yourself, and of course, using all knowledge and skills that has been put in UI framework.

There are few possible cases, where .NET core WPF/Winforms used with no additiional UI framework can be used. One of those cases is when your team is small and it can use community editions of Visual Studio and Microsoft Blend, and it is working on creation of custom and visually appealing product. Together with few additional applications for vector drawing your team can style controls itself and achieve quite good results. This series of articles aims to show actually how this can be done, even if you don't have designers or art persons in your team (having them will help of course). You will need lot of creativity and great desire to make good things. And you have to work a lot. 

## What you will be able to make if you follow entire article

Major goal of this article is to demonstrate how to style buttons for your application. I wanted to make it short and concise, but in same time to explain things properly and with enough details and examples, and finally I have made a long article. It is not the usual several sentences, trendy sale terms article, it is quite the opposite. The early adopters and evangelist of WPF are long done using it, they are now selling other products and play with newest stuffs. So if you feel this article should not be so long, then maybe you feel rigth and probably you can find better occupation instead of reading it.

My understanding of styling is that it should be very simple, but still has to cover the basics and be properly made. When dealing with buttons in an application, working under Windows OS, there are some visual states, in which those buttons can be - normal, (keyboard) focused, mouse over, clicked or using the exact term <b>pressed</b>, to name a few, and unfocused, disabled to name few more and say there are even more states. We want to cover the most used states, so that our buttons look natural. We want that buttons look good when different fonts and different sizes are used for the content, if any. We will try to not use margins, paddings and any hard-coded "sizes" in control template, but however sometimes this would not be possible. Advanced effects like ripple are not demonstrated here.

This article consists of several parts. In first part, we lay out foundation for forther parts, but we actually do not style any buttons. We are going to use different fonts, different writing systems, different flow directions and even only this changes the visual appearance of the application in a massive way. We are going to implement basic functionality for the application, so that in further parts we deal mainly with styling. Layout of buttons and text is specifically tuned to show different button sizes with some spacing around them, or a typical position of several buttons next to each other, and it is not intended to be an appealing user interface. It is a working application intended to make button styling easier. I am saying this in case someone read the article and then complain about breaking some UI principles. In each of the following parts we are going to follow a certain approach and style buttons in certain way.

The article does not show anything new, neither is intented to demonstrate best techniques. Some of proposed styling might be acceptable for some cases, but not for all. It is up to you to decide. This article is not a collection of super knowledge, contained in several short paragraphs, together with trendy terms. This is step by step article, that demonstrates some approaches, so it will require some time and efforts to follow. This gif, made with Screet to Gif, shows finished demo application in action:

![Ready demo application](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part06Final.gif?raw=true)

## Prerequisites to follow the article

This article was made at the start of summer of 2020, so corresponding versions of tools and frameworks at this time were used. Namely:
* Microsoft Blend for Visual Studio Community 2019, available as free download from MSDN. Usually Blend is installed together with Visual Studio
* Visual Studio Community 2019 (optional)
* Inkscape, Open Source Scalable Vector Graphics Editor. Draw freely. Available from inkscape website. Will be used in part three, five and six
* Microsoft.Windows.SDK.Contracts NuGet. It is used only in part four for getting the Windows 10 Accent and Accent Color Palette colors (no, WindowsGlassBrush cannot do that, not for palette colors)

## Part One foundation localization and custom fonts

In this part we will create some basics, so that we have a working application, where we can see in action control templates, applied to buttons, an application, where we can see our styling in action. As entire source code is available, instead of detailed step by step instructions more general explanation will be used.

### Making simple solution ContentControl INotifyPropertyChanged and ICommand implementations

We create a WPF solution, targeting .NET core 3.1. We rename the `MainWindow.xaml` to Shell, set width and height to 1 526 and 864 px. We are not going to deal with scaling in this article, so no measuring of text and dynamic changes of font sizes. In `Shell.xaml` there will be only a content control, and its Content property will be bind to a property in our main view model. We will change the content and this way perform the navigation.

We have to implement a Base view model. It has to implement `INotifyPropertyChanged` interface. In our implementation a property for providing localization via View Model binding is added, as this approach is dynamic and easy to use. We also have to provide an implementation of `ICommmand` interface. Our implementation is called Simple command. We create the following folders - Assets, inside it we create folders Fonts and Licences. We also add a resource dictionary file called `General.xaml` in this folder. Then, we create folder Resources and folder Views.

### Adding localized content

We are going to use different fonts with different writing systems, so that we can see the impact of font and font sizes in practice. Choosing a specific font is already a styling and can have a great impact of the UI. Some general terms - computer font, computing button, writing system and part of their description, taken from Wikipedia are going to be displayed on part of the screen on every button click, so that we acknowledge this user action. Those texts are machine translated on several languages. For every language and specific country code a separate resource file is added. Our main file is called `General.resx` and content there uses United States English, en-US. File is placed in Resources folder. Then, the content is translated to Arabic and a file called `General.ar-Sa.resx` is added to Resource folder. Then, the content is translated to Bulgarian and a file called `General.bg-BG.resx` is added. And so on and so forth for all remaining translations. Finally, we specify a custom namespace for `General.resx` - `StylingAButton`. We confirm it and then run the custom tool to update code-behind for resource.

### Typefaces Fonts Cultures  Languages

For every language we are going to use there will be specific font as well. Below you can see the languages, two letter language code and two letter country code, specified for every language, and the font used for it. We add fonts to Fonts folder. We specify Build Action for each of them to <b>Resource</b>.

Bear in mind that fonts almost everytime have sort of license related to them. All fonts used here have OFL license (Google Fonts) or for some copyright rights have expired. They resemble famous fonts, but they are not exactly like them. Lots of fonts do not have an OFL license, but a quite different one, a commercial one. So in such case you should not use them in your application like that. You have buy them, to follow licensing and redistribution info guidelines, contact the font vendors etc. 

| Language (sorry, but cannot cover all) | Font name |
| -------------------------------------- | --------- |
| English (en-US) | Rokkit |
| Arabic (ar-SA) | Mirza |
| Bulgarian (bg-BG), representative for Cyrillic scripts | Sofia sans |
| Bengali (bn-BD) | Atma |
| German (de-DE) | Din 1451 Mittelschrift (an old version) |
| Spanish (es-ES) | Montserrat |
| Farsi (or Persian, fa-IR) | Nastaliq |
| French (fr-FR) | EB Garamond |
| Hindi (hi-IN) | Amita |
| Japanese (ja-JP) | Sawarabi Mincho |
| Korean (ko-KR) | Hi Melody |
| Portuguese (pt-PT) | Yrsa |
| Thai (th-TH) | Sarabun |
| Urdu (ur-PK) | Nafees Nastaleeq |
| Simplified Chinese (zh-CN) | Zhi Mang Xing |

The resource dictionary `General.xaml`, which we have created earlier, is going to be used now. For every font we have added, we create a Font family key, containing the path to the font resource. Font name should be specified properly. A convenient way to see a font name is by using Windows Font Viewer application, usually a default app for opening a font. If there are spaces in font name, then we specify it with spaces. An example:
``` xaml
<FontFamily x:Key="DinMittelschrift">pack://application:,,,/Assets/fonts/#Alte DIN 1451 Mittelschrift</FontFamily>
```
### Views

We will continuously add Views as User Controls for every part of our article, in Views folder. The main view model will always be the same and practically won't change. All views will work with it, the same view model. For now, we add `StartView.xaml` and `ColorPaletteView`. The first is for this part, part one, when we just want to display the buttons with no styling and display only typeface changes, and later is for the second part. Start view contains several buttons for several font sizes - starting from 96 px with a step till 20 pt and one button with default size. Those buttons will be shown in left part of the window, and in right part of it there will be a header text with big fong size and content with much smaller font size. Those two will display demo texts, we have created earlier. It would be nice to have two separate fonts, one for header and another for content, but this means I have to find fifteen more fonts. I guess we can live with one font for both. On every button click there will be a random culture and font change, so that we constantly see different fonts and not feel bored. One button will always be present and never be styled for every view - this is the Next button, which will navigate to next view.

### Main View Model

We want our application to be very simple. If we make a short summary what it does, it will look like that: On button click every content is changed. On clicking Next a view is changed. Application culture and font for most of the controls is changed as well, on random basis. This happends by invoking `DemoCommand` with different command parameters, depending on what topic we want displayed. Small `enum` called `DemoTopics` is used for command parameter.

Afte every language change we want to display different language, with different font, localized content and flow direction. We don't want to just randomly choose from a set, but to enumerate equally all languages and only after they are displayed at least once, then we want to randomly shuffle them again. A Fisher-Yates shuffle method is employed for that.

Next button works with `ChangeViewCommand`. Available views are enumerated in `ViewsForDisplay` enumeration for easier work with. We can access those views by reflecting the application assembly on runtime, instead of hard coding them, but for such sample application this will be an overengineering. We will simply update navigation for every view we add ruing the article progress.

Our view model contains properties for font sizes, current font family and flow direction, as well as for header and content of demo topics. Platform invoke calls for measuring the actual window size and consequent font scaling, measuring of text lengths and other similar stuffs are not part of the demo application.

Pay attention to the switch statement used and usage of only one view model. Those are good for this demo application. What will happen if you try to add (much) more functionality to those? Probably it will become difficult to work with and tedious to maintain. So what is good for a demo application might not be good for more sophisticated one.

### Live preview end of part one

We are ready with part one. This is how it looks in action. We have made a good foundation for future parts.
![Live preview - part one](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part01.gif?raw=true)

## Part Two Styling using a color palette Visual States instead of triggers

From this point forward we are going to use Microsoft Blend as editor. It is more convenient to work when it comes to styling of controls. We will use the Visual studio solution we created earlier. 

### Basics

We will style the commonly used button states - normal, or the default one, mouse over, clicked/pressed and disabled. We can use two approaches - one is to use Visual State Manager, together with Visual State Groups and Visual States, and the other is to employ triggers for button properties, related to visual states - like `IsMouseOver`, `IsPressed`, `IsEnabled`. Both are valid approaches and I believe it is mostly up to personal preferences of the developer to choose one or another approach. However, there are differences in what those approaches can offer - for example if a `IsPressed` property is triggered and a long button animation starts and the storyboard is not exited when `IsPressed` is no longer valid, animation will play full even when button is already in a different state. This might be a wanted effect.

When working with Visual State Manager, you have to be careful. It has to be first control, immediately after first content control inside control template, otherwise it won't work. It won't complain either, it will just not work, so this is a tricky one. Microsoft Blend editor can help us a lot to properly place Visual State Manager in the control's template markup. We will use two views in this part - `ColorPaletteView.xaml` created in part one and we are going to create a `ColorPaletteViewDemo.xaml`, which will have same layout as Start view, only difference being that all buttons (except Next) will be using the control template, which we are going to make in this part.

### Choosing a color palette

Choosing proper colors for an application depends on many things. In order to simplify all stuffs related to important task of choosing appropriate colors, we are going to use a set of predefined color palettes and simply pick one of them and pretend it is cool and our users like it. I am going to use color scheme generator, available at coolors.co You can simply press space and five new colors, making a simple color scheme will appear. After we have pressed space few times, we stop on color palette with ID 7e6c6c-f87575-ffa9a3-b9e6ff-5c95ff, having the following five colors: Deep Taupe 7E6C6C, Light Coral F87575, Melon FFA9A3, Uranian Blue B9E6FF and Cornflower Blue 5C95FF. I am almost certain that names are autogenerated as well.

### Making simple layout for easier styling

Our color palette view will contain a grid, having two rows and three columns. In almost every one in grid cells we are going to place a button. One will be the Next button, so that users are able to navigate further. We will have one button styled for "Normal" state - this is now the button should usually look when there are no interactions. Then, we will have one button for "Mouse over" state, another for "Pressed", and another for "Disabled". If you are paying attention, you might notice that we do not touch "Focused" state. In further parts of article we are going to style such states as well. Finally, we will have a buton having a control template, where every state is styled accordingly. We are going to set font size to 48 pt.
* For "Normal" button we specify transparent background and transparent border brush. For foreground we specify `Black`. Pay attention that if some specific color scheme is used for Windows OS, system colors can be quite different than one might usually expect. For example, `ActiveCaptionTextBrushKey` might be quite different than Black color. Again, we will play more with system colors in forthcoming parts.
* For "Mouse over" button we specify #FFFFA9A3 as background, for border brush we specify `LightGray`, 1pt thickness for all sides, and foreground stays the same, black.
* For "Pressed" button we specify #FFF87575 as background, for border brush we specify black, 1pt thickness, and foreground stays the same as before.
* For "Disabled" button we specify #FF7E6C6C as background, for border brush we specify `LightGray`, 1pt thickness. Foreground stays the same.

We build and run the application and just look at the styled buttons, all in normal state, but some of them looking like they are in other states. If we like what we see, we continue forward. If not, we tune the colors again and again until happy. As we agreed earlier, we will pretend that generated colors are OK.

![Styled buttons](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part02-ButtonsStyledView.PNG)

### Making a control template

This is probably the most important piece of this part. So we are going to walk on it step by step. First, we specify the same properties for "Ready" button, as we did for the normal one. Then, in Microsoft Blend we select Design instead of XAML view for editor if already not selected. We select Ready button, if not selected, and right click on it. From the context menu we choose <b>Edit Template -> Create empty.</b>

In Create control template resource dialog we specify the name `ButtonTemplateColorPalette` and confirm with OK. We can go to XAML view to see that template has been created. Then back to Design view. The ready button is gone, an empty template is now placed on its place. However, it is still selected. In upper left corner of the designer it says <b>Button -> Grid</b>. Meanwhile, if you have clicked on something else and the selection is the grid inside the generated control template, make sure you select it again. We will trick Blend to generate some visual states for us. We select States window, looking like dock panel. If it is not visible, we can show it by <b>View -> States window</b>.
![States window](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part02-StatesWindowPanel.png?raw=true)
We select Normal state and it automatically turn recording on. Now, let's change some of the properties just to make Blend generating more content for us. I usually change the `OpacityMask` to some color and later delete it, after recording is off. If you have followed the steps exactly, you might see an error message like this:

![Error Message](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part02-ErrorMessage.png?raw=true)
and if you don't follow the steps at least closely, you will not see the error message, and it will still work fine. Anyway, error message or no error message, don't bother with it, confirm with OK, we are going to be fine. Now we stop the recording and we go to XAML view. We see the control template, coourtesy of Microsoft Blend. As we say earlier, we do not touch the position of Visual state manager in XAML markup.

Now we just have to tune the control template and specify the basic styling we have made earlier in article for all states in Common states visual state group. We will remove the dummy opacity change storyboard we generated earlier and we make our own storyboards, so that we properly change the appearance of button in every state. Also, we wil remove the grid and instead use border as container. We will place a content presenter inside the border, sot that we are able to see our text. It remains to handle one more thing. We want to change the `Background` and `Border` color when button is in some state. Both properties requires not a color, but a brush. So, we have to define some brushes, based on colors we have generated, and use them in our control template. We will define those brushes <b>inside</b> control template. So, afte all those changes, our control template is ready. We have to make sure it is a proper control template, so we build and run the application, then we navigate to Color palette view and check that our button behaves like expected.

In paragraphs before, we have created a control template, which is applied to only one button and it is defined inside the markup of the user control, where this button is used. We want to recreate the layout from Start view, but this time having all button styled using the control template we just created. So, we will copy the control template and place it inside `Generic.xaml` file with the key `ColorPaletteTemplate`, so that it is available through entire application. Then we create the view called `ColorPaletteDemoView`. This view will have the exact markup of Start view, with only difference being that all buttons will use the `ColorPaletteTemplate` via their `Template` property and refer to it as a static resource. Finally, we have to update the navigation part in our main view model, so that it accounts for newly added views, and update `ViewsForDisplay` enum as well.</p>

### Live preview end of part two

We are ready with this part and we have styled our first buttons.Good job, although styling have few issues. Let's have a look at our current application
![Live preview - part two](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part02.gif?raw=true)
and then move to part three, where we meet Inkscape. 

## Part Three: Meet Inkscape. Otherwise similar to part two, but we change Foreground and style Focuses state

By design WPF is a vector graphic framework. This means it works great with vector graphics and we have to use a proper vector drawing product in order to make vector drawings. Inkscape is such a product. Its initial release was in 2003 and the version 1.0 was released this year, 2020, 16 years and few months later. As people say, "better late than never".

### Inkscape

As you can imagine, lots of stuffs can be made with Inkscape and unfortunately, I am not able to show you even minor part of them. In this part we are going to create a simple path, export it as xaml and use it in our application. In later parts we will try to make more complicated paths, or shapes, and style our buttons to greater extend. If you never worked with Inkscape, my suggestion is to watch several videos on the web and then to tackle documentation and tutorials.

In this part we will create something popularly called "Blueprint". It is now an obsolete process, but in the past it has been used to rapidly produce large number of copies of technical drawings. It is characterized by white lines on a blue background. So we will try to make something like this - our buttons and text blocks will have transparent background and white foreground and entire background of the view will be blue (or green or some other) gradient color, together with white rectangular's 2D mesh, similar to a Cartesian grid.

### Making the grid in Inkscape

By the way, Inkscape has several extensions, that allow quick generation of predefined paths. So if we start it and go to <b>Extensions -> Render -> Grids </b> and then choose Grid or Cartesian grid, it will generate grid for us. We will follow the hard way however and draw the grid manually. So we get acquanted with Inkscape more and more and see that it is actually not so difficult.

* We start Inkscape and go to <b>File -> Document properties</b>. We select display unit - px and in custom size we again choose px as unit and specify size of our window, 1 536 px width and 864 px height. Do not worry too much for those dimentions, we are making vector paths and it can scale fine to any resolution. We adjust the zoom so that it is convenient to us. Then we click on the rectangular button in one of the toolbars, called <b>Create rectangles and squares</b>. If you don't see it, you have to work a litte bit on your Inkscape toolbar layout.
* We draw a very thin rectangle, something like a vertical bar. Entire height of canvas is used and the width is something about 50 px. Depending on your settings, this rectangle might have a fill and a stroke. We need only stroke in this case, 1px thin. So in the lowest left-bottom part of the editor there should be two rectangles - one for Fill and anothe for Stroke. We can left click and specify the Fill and Ctrl + Left click to specify the stroke. Or from editor menus we can select <b>Object -> Fill and Stroke...</b> So no fill, black stroke and 1px thickness. 
* We will probably not be able to make exactly 50 px wide and 864 px tall bar. So, we now click on <b>Select and transform object</b> button and then click again on the rectangle. Now it is selected. We see slightly different toolbar in the upper part of the editor. There we can see X and Y coordinates, and W(idht) and H(eight) parameters as well. We specify 0 for X and 0 for Y. 50 for W and 864 for W. And we click on padlock icon, <b>When locked, change both width and height by same proportion</b>, between H and W. Cool, we made a very basic stroke only rectangular shape in Inkscape.
* We select rectangle again, then right click and we select Duplicate. An exact copy of it is created. Is is placed exactly where original object is and more, it is now selected by us instead of original object. So we start moving it by holding left mouse button pressed and moving the cursor little bit to the right. We move it, we move it and in some point in time the left side of moving object goes close to the right side of the original one. An information typ saying <b>Corner to Corner</b> appears and in this moment we release teh mouse. We should have two stroke only, empyt if you want, bars next to each other. If not, we fix it via X and Y coordinates, X is 49 and Y is still 0 for the second bar.
* We can duplicate, duplicate and duplicate a single bar and finally fill the entire canvas. But we can do something to ease our job. So, we click on the first bar and then hold Shift and click on the second bar. They are now both selected. We go to <b>Path->Combine</b> and confirm. Now those two bars are one path. We select them again and we duplicate them again. This time duplicated object will consists of two bars. We move it to the right as we did before. Finally, four bars next to each other should be present.
* We can combine those four and make them one path again. And duplicate and move. At some point our one path many bars will become big enough and we should <b>Break it appart</b>, in similar manner as we combine it. We play along and find the best way to fill the canvas and make the vertical bars. We might notice some other information tips, but we ignore them for now. Our grid is fine. Now, in similar manner we do the horizontal bars. An unlock and new lock of sizes might be needed when we make the first horizontalbar. Finally, our grid is ready.
* We will not make labels and other stuffs that a real measured grid paper might have. One final thing however we are going to add are three lines at 30° 45° and 60° angles. So we select <b>Draw Bezier curves and straight lines</b> and we click on point in lower part of the grid, nearby down border. Then we hold control and we move the other end until 30° are shown in status bar, usually situated in lower part of the editor. We do this again for 45° and for 60° lines. And that's it, this will be our final grid.
* We are almost ready. We have to make sure that entire mesh/grid is a single path. We need one path only. So we select all current shapes and combine them, so that we have only one big shape. Then we save the file in default svg format at some convenient place. It is available as Inkscape svg file in drawings folder.

![Inkscape grid](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part03-InkscapeGrid.PNG)
Then, we save the file again as a XAML file, so that Inkscape generate XAML for us. So we select <b>File->Save as</b> and we select Microsoft XAML in Save as type field. We confirm with save. We don't want to be Silverlight compatible. Finally, we open the newly saved XAML with a text editor and look at the content. If we did well in previouis steps, there should be only one path with some path geometry.

### Back to Blend Designing buttons suitable for blueprint

We are going to create two views, in a similar manner as in previous post. One view will be for detailed design of a button and other view will be the demo. First view will be called `BlueprintView` and it will have three rows and three columns, having buttons in most of cells, and the second view will be called `BlueprintDemoView`. Background color of both views will be simple gradient, and the path geometry we generated earlier will be placed insite the user control's grid as well, spreading through every row and column.

### Making the Blueprint view

We specify a linear gradient brush for the grid background and we create a path with 0.5 stroke thickness and white (#FFFFFFFF) fill, streating fill, and occupying all grid cells. Path geometry is taken with no changes from previously generated XAML from Inkscape. All buttons have a transparent background. Because of the specifics of the blueprint design we have chosen, changing the background color won't be a good option - let's say we are allowed to use only white (and some gray too) lines and letters. So how can we distinguish between focused and unfocused states, how we will distinguish between mouse over and pressed state?

We will add one more border, or we will make the control hierarchy a little bit more complicated, so that we are able to notify users for all important states. We will have a content presenter, two borders, one outer and one inner. And in inner border we will place a grid with a rectangle for focused state and our button or content presenter when we talk about control template. Depending on the state, we will show one or both borders, we will show the rectangle etc. Our hierarchy might be little heavy, but states from Focus State group change one object, and states from Common state group change others. So we can be sure that any combination would be fine.

We have to think about Focused visual state, part of Focus state group. By default it is displayed by a dotted black rectangle around the content of the button, but in our case this is not OK, we want white color, to be in sync with all blueprint stuffs. Finally, this is what we set:
* For all buttons we set `Transparent` background.
* For "Normal" button we set transparent border brush 1px thick and foreground is set to #FFFFFFFF.
* For "Pressed" - we surround it with a border 1px thick, having white border brush. More, button itself has white border brush 1px thick, so two borders in total. Foreground is again #FFFFFFFF.
* For "Disabled" we specify `Foreground` #FF7F7F7F and border brush #FF7F7F7F.
* For "Mouse over" - we surround it with a border like "Pressed", but this border is transparent. All other is the same.

### Focused state

For "Focused" we cheat a little bit. The best way to handle focused state is by using Focus Visual Style. Focused style should be same for all kind of controls, if possible, so that users do not confuse what is focused. That's why it is made as a property and it is usually specified in a `Style`, and not in a `ControlTemplate`. In this part of our article we will handle it not by making a specific style for `FocusStateManager`, but via simple and easy way to implement - we will have a grid, which will host a button and a rectangle, which is stretched inside the grid. So our button template will be outer border, inner border, grid, inside rectangle and content presenter. We will specify stroke, stroke dash array for the rectangle and we are good, we have the dashed lines usually connected with focused state. Our control template will be quite easy to work with it as well. If we go in third direction approach, like working with customized visual or drawing brushes, it will be waaaay more complicated (for no reason actually).

### Making of control template

Once we are fine with the look of every state, it is time to make the control template. We select the "Ready" button, then we set the selection to the button, as it is probably at the grid shape path, and we follow similar steps as in previous part (you can click on combo arrow in the upper left corner of the editor view to display the Edit template option when button is selected). Finally we create the `ButtonTemplateBlueprint`. First we should change something in `CommonStates` group, and then in `Focused` group, or this is at least what I have done :) We specify brush for white color in control template. We pay great attention and we use `ObjectAnimationUsingKeyFrames` for changing the `Brush` (object), and `ColorAnimationUsingKeyFrames` for changing the `Color` for the `SolidColorBrush` for the `Foreground` of the `TextBlock` of the `ContentPresenter`. When working with control templates, a small typo can break lots of stuffs and for that reason I type everything manually in text editor and I pay extra attention. If you don't know what or how to set something, play with the recorder of Microsoft Blend to see what is changed, when, and how, so that you gain this knowledge. Then, type it manually, to be sure it is done properly. Behold the final version of control template. It remains to specify the `Template` property for the two "Ready" buttons, one enabled and one disabled, anf for both of them to set `{x:Null}` for `FocusStateManager` property, because we have created our own focused state.

We have come to the end of this part as well. Now it is time to add the control template we just created to the `General.xaml`, where all resources are stored. We will save it under the name `BlueprintTemplate`. Then, we take the Start view markup and place it in Blueprint demo view, we specify the template for every button to be the blueprint template. Remember to specify `{x:Null}` for focus visual style every time you use it (or better, make an entire button style). Then we specify the background for the user control (view) and we place the grid path just as we do for the previous view. We stretch if for all rows and columns. And finally we specify foreground of white for both text block.

### Live preview: end of part three

![Live preview - part three](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part03.gif?raw=true)
And we are ready with this part. Good job! Buckle up, we are not ready with this article yet. Prepare to meet part four, where we finally do some animations!

## Part Four Buttons and Windows colors Hello Animation

Amongst Windows operating systems two versions has the biggest market share, again according to Net Marketshare website. Those are Windows 10 and Windows 7. As support for Windows 7 ended on January 14, 2020, it is clear what is the main Windows OS now. This article was written under Windows 10 via Libre Office products.

It might not be entirely true, but we can say that for the few latest major Windows released, there is a new .NET UI framework provided by Microsoft for making (easier) native windows applications. Of course, there are many ways to do such applications, you can develop such software using C and Windows SDKs, most popular applications like (former) Microsoft Office, Adobe Creative Suite, Google Chrome were all build this way, using the same Win32 API. However, this is very, very difficult. So here come the .NET framework and WinForms, WPF and now UWP. We can pair WinForms with Windows XP, WPF with Windows 7 and UWP with Windows 10. We have a `SystemColors` class from `System.Drawings` namespace, we have `SystemColors` class from `System.Windows` namespace, and for UWP and Windows 10 we have Accent color palette, together with light and dark theme.

When WPF was created, there were no notion of Accent color. Windows 7 was about themes - Aero etc. Some of 2010's WPF applications were cheap looking dark themed controls with lots of gradients and lighting effects, some others were mimicking the existing WinForms applications. Today's applications are different, maybe not quite numerous, but they reflect today's realities. Making a WPF or WinForms application to look like native Windows 10 application is not a trivial task. Reveal Highlight can be quite difficult to implement, Parallax, Connected animations to name few more. Still, a simple and appealing interface can be achieved and styling of most used simple controls can be done. Few years ago one possible solution to represent Accent color was to use a specific WPF brush, so called `WindowsGlassBrush` from `SystemParameters`, but it has some minor drawbacks. More, what about Accent color palette, with lighter and darker shades of the accent color - developers have to implement their own way of calculating those? Would it be much better if we just ask the operation system to tell us those colors? 

So luckily enough, since nine-ten months there is a NuGet package called `Microsoft.Windows.SDK.Contracts`, which allows to add Windows Runtime APIs support to .NET Framework 4.5+ and .NET Core 3.1+(actually 3.0+) libraries and applications. Latest version of it is used in our article. Grace to it we get all the system colors we need, so that we can style our buttons in this part as proper Windows 10 buttons. We will add some animations to touch the topic a little bit and prepare for next part, where we will deal more with it.

### Getting Accent color and Accent color palette

What's the plan for this part? We have to:
* Install the Nuget for `Microsoft.Windows.SDK.Contracts`
* Create two views, `AccentView.xaml` and `AccentDemoView.xaml`, similar to what we are doing in previous parts.
* Use a class called `UISettings` and grace to it get the current values of Accent color, one lighter and one darker shade of it.
* Those colors are of type `Windows.UI.Color`. So we create struct of type `System.Windows.Media.Color`, based on alpha, red, blue and green components, ARGB values of Windows 10 colors.
* Add those colors to user control resources and give them resource keys.
* Create solid color brushes in control template for the buttons, based on colors specified as resources. This means colors should be present during control template initialization, so we have to do all those before we call `InitializeComponent`.
* We do all in code-behind, in a proper application you have to figure a more structured way of doing it, in a bootstrapper or initialization of application itself.

![Live preview - part three](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part04-AccentColors.PNG)

### Animation. More to come in following parts

Animation in WPF is a big topic and I am not able to touch even a small part of it. We will deal with greater details in following parts. There are four major transforms that can be applied to an object - Scale, Skew, Rotate and Translate. If you know some linear algebra, you are aware that via rotation and translation any change can be achieved, scale and skew are added for ease of developers. On those major transforms rely most of animation support in WPF, but not all - there are also pure bitmap animations.

There are however some customized animation classes that can be applied to specific properties of objects, one such being the `ThicknessAnimationUsingKeyFrames`. It is quite simple to use and that's why we start with it. We will animate the margin of a framework element, the border of our button, and this way we will make it look more interactive. You have to be very careful, when you animate size changes and I would advise you to generally not use animations that change sizes for Mouse over state or when using Mouse over triggers. It might happen that users point the cursor to the end of the button and leave it there with no further move. The animation is triggered, then stopped, then again triggered and some kind of infinite animation loop might happen. 

So our margin animation will be very short and barely noticeable and it will occur only on Pressed. Even if users trigger it constantly, it should be fine, as it is slower for users to click or press key. Even if they hold a key pressed, there are some milliseconds between the separate events for key press.

In order to se the Pressed animation better, we will animate the "Pressed" button constantly, via a trigger that loads a storyboard animation once the user control is loaded. This approach will be quite useful in following parts as well. If you followed so far, you might notice that the design view of Microsoft Blend in our case shows a white x inside red circle in top right corner of all buttons, relying on Accent colors, colors we create in code-behind.

![Design view peculiarity](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part04-DesignViewPeculiarity.png?raw=true)
If you are looking at the markup, you might see that some underlying for some parts of XAML is made, saying that "The resource ... cannot be located". We have to live with this, we will look at the running application and we will see whether everything is as we want or not, animation will work as well only for the running application. So the design view is not very useful in our case, as the Properties panel is not very useful as well.
For Accent demo view we are not going to place `AccentButtonTemplate` in our `General.xaml`. We will proceed in the same way as we did for Accent view - load accent colors before initializing the components in code-behind. Finally, here is the live preview for this part, made with Accent color of Default Blue selected. Time for part five, where we meet Inkscape again. 

### Live preview: end of part four

![Live preview - part four](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part04.gif?raw=true)

## Part Five More paths more Inkscape

We have already meet Inkscape, a tool for making vector graphics, and we have have made simple drawing with it. Now it is time to make few more paths and try to style a button using those paths. Here your creativity can shine and you can achieve great things. We will try to make something simple, but still something that cannot be so easily achieved using Microsoft Blend. Something simple enough is making several nested circumferences or rounded rectangles - they will be more convenient as we have to display text for buttons. Then we can remove some parts of those and achieve a different look, they will look like different elements.

### Making paths in Inkscape

* We start Inkscape and go to <b>File -> Document Properties</b>, where we set <b>Display units</b> to px. Then we go to <b>Custom Size</b> and we set Units to px, we specify scale x to 1 and scale y to 1 and then we set Width to 1 280 and Height to 320. We close the properites dialog and if needed, we zoom to what is convenient for us.
* We go to coolors.co and generate another color scheme. This time we have generated c1cfda-20a4f3-59f8e8-941c2f-03191e and we are going to use only three out of five generated colors: Carolina Blue 20A4F3, Crimson UA 941C2F and Rich Black Fogra 29 01191E. Again, pretty sure those names are autogenerated as well. We select <b>Create rectangles and squared</b> and we make a rectangle, big almost as the entire canvas, maybe 20-30 px margins from each side. We draw the rectangle and then select it. We set X = 20, Y = 20, W = 1 240 and H = 280. We right click on selected rectangle and choose <b>Fill and stroke</b>. Then we set the Stroke paint to be 941C2FFF and we set width for stroke to be 10. Fill should be null from part three, if it is not null, we make it. We want only stroke, no fill.
* Then we click on rectangle with <b>Select and Transform Object</b> and we click not once, not twice, not three times, but a quick double click on it. We should see boxes for Rx and Ry in upper part of the editor. We set some corner radius, something we consider appropriate, like 25 for both.
* Next, using same approach, we create a smaller, nested in the first one, rectangle with a different color, Rich Black Fogra 29. We have X = 40, Y = 40, W = 1 200 and H = 240. If we have specify corner radius in previous step, their values should stay, so it is not necessary to specify them again.
* Next, using same approach, we create even smaller rectangle, nested in previous one. X = 80, Y = 60, W = 1 120 and H = 200, color is Carolina Blue. We save the drawing under some convenient name in default Inkscape svg.

### Adding some complications to our drawings

Our drawing is quite fine, but it can be easily done even in Blend. So we are going to remove part of lines and make the shapes little bit more complicated. This can be done in many ways, but we are going to use the following - we are going to draw a rectangle (or other shape) over part of the lines of an existing rectangle. Then we are going to combine both shapes and remove the second shape from the first one. This sounds more difficult than actually is, you can consult numerous youtube videos and see exactly how this is done. 

So we draw a new, smaller rectangle, like a segment, over part of existing one. For the new rectangle we specify a fill, remove corner radius and set stroke width to 1. Then, we click on the first rectangle, then Shift click on the second one and we go to <b>Path -> Cut path</b>. The second rectangle disappears, but we can now select a part of initial rectangel as a separate path. And we can delete it. Delete. Cool!

Following this approach, we remove parts of all nested rectangles and finally we make a new design. If we can add few imperfections, something that can be done only by humans, even better. This is what we have done so far. We save it under different name, we will need it later. We will refer to it as Normal.

![Normal segments](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part05-Normal.png?raw=true)

### How should our shape change when button is focused Or users hover over it

We have to figure out and then implement small changes in shapes of our figures, so that they look interactive. What if we do this, but not that? Here your creativity can shine. We will however try to do something simple. We will just move all parts closer to the center, on X and Y axis, and position all parts closer together. Parts, or segments of former rectangles, located in top left corner will move down and to the right, parts located in bottom right corner will move up and to the left. Nearest to the center will move less, and those far apart will move more. Once we are ready with our changes, we finally save the file again under different name. We will refer to it as Focused.
![Focused segments](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part05-Focused.png?raw=true)

### Making our drawing a single path so that it is easily used in Blend

We close all open instances of Inkscape (wow) if any, and we then open the file we saved earlier and referred as Normal. We Shift click all four parts with same color and we go to <b>Path -> Combine</b>. Then, with current selection active we go to <b>Object -> Object Properties</b>. We specify some ID for this path, for example outer. We do the same for remaining two groups, and we call them middle and inner. Now we can optionally save in Inkscape defalt svg, but then we need to save is as XAML as well. We look at the created markup and we confirm that there are three paths named outer, middle and inner.

We close Inkscape and open the file we refer as Focused. We do similar actions and finally we end up with a markup, having slightly different geometries. We can name them in a way that it is easier for us to differentiate and not get confused with initial three ones. Our job with Inkscape for this part is done. Time to go back to Blend.

### Using created paths in buttons

We create the usual two views, one for easier design and other for demo view, `NestedPathsView` and `NestedPathsViewDemo`. For first one we create a grid having three rows and three columns. This time however we will add only three buttons - two "Ready" buttons, one enabled and one disabled, and button for Next. For "Normal", "Mouse over", "Pressed", "Disabled" and "Focused" we are not going to use buttons, but the paths we have created. We will place every path in a separate grid, together with a text block for the content. Then we wrap all in a ViewBox, so that they can scale automatically, although we can manage without it as well. We will create path `Geometry` resources, six in total - outer, middle and inner, and outer focused, middle focused and inner focused. We have to modify path names for all instances, where they are used, so that we don't have naming conflicts and be able to refer to those parts from storyboards. Those storyboards will run on loaded event for user control and will show on some fixed period of time, like one second, what the changes for Mouse Over, Pressed and Focused will be. Similar to what we did in part four. For Pressed state, where we are going to apply scale animation as well, we have to add for every one of the three paths there a `RenderTransformOrigin` and a `RenderTransform` transform group markup, together with all four transforms - Scale, Skew, Rotate and Translate.

### Making the control template

We create the `ButtonTemplateNestedPaths` following the same approach, which we have used so far in this article. Because we do not change our geometry resources, it is not necessary to create copies of them in control template. It would not hurt us either, if we do so.
* On mouse over stroke will become thicker, from 10 to 20. Mouse over is usually triggered only when users hover over some of the paths or content presenter itself. They can however point to empty space in the button and this way state would not change to mouse over. To avoid this effect, we add a rectangle, stretching through entire grid with transparent background. When mouse cursor is ove this rectangle, the state will always change to mouse over.
* On pressed there will be short scale animation on X and Y, scaling from 1.2 till 0.7 and back to 1, for about 250 ms. In same time there will be change in the path, for about 100 ms.
* For disabled we make all path colors gray, together with Foreground change of content presenter.
* For focused we change the paths from normal to focused shape, as we create them in Inkscape. Our button is so heavily changed, so the usual dashed border around it would not be appropriate.

### Making the demo view

One drawback of our control template, using custom paths, is that it uses `Viewbox`. This means that everything inside the view box is scaled, so that it always fits the available space. In other words, in current layout of our demo view all buttons will be quite big, probably as they are for the first one, those with biggest font (because of text block in same row), and probably one, two or three of them will be visible at most. And maybe more important, all buttons, from those with font size specified as 96 pt till smaller ones, those with 20 pt, will have the same size and will look the same way, because we specify a font size inside the content presenter's text block, which overrides the value we set later.

So how do we scale the buttons then? We can use `FormattedText` and `Typography` classes to measure the real text sizes and dynamically change all buttons widths and heights. However, once we use Viewbox, the font size does not matter, beceause it is already specifed in control template. It will be scaled according paths sizes and grids in control template and then view box will scale the content, based on container on which is placed. So we solve this the easiest way - we specify different row heights and this way we size the button, placed in them. Not the best approach however.

### Live preview: end of part five

![Live preview - part five](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part05.gif?raw=true)

I will emphasis again - in final view for this part all buttons look almost the same way, no matte the font family being used, and have quite similar sizes. We clearly saw in previous parts that for every font family we used, the button size changed significantly, because it has to fill the text and every font has different properties. One displays larger glyphs, other smaller, etc., those are specific font properties. Now, because of the `Viewbox` we have used in our control template, this is no longer valid. Everything is scaled in the view box and we lose the specifics of font families, as far as size is concerned, shapes of glyphs of course remain conserved.

Let's look from a different perspective. Our buttons are now very customized and do not quite resembley traditional buttons. Only thing that still holds is that they are much wider than tall, still something for traditional buttons is preserved. And there is clear separation between every button. But is this a rule? Should always be like that? Answer of that is in our final part, part six. Let's move and find out.

## Part Six and final: Making Infographics like buttons

Some application require no buttons or only one button. For example, when you search using a popular search engine, you need only one button - search, and you might search without a button, by confirming via keyboard. For many other applications the first button you click is Sign up, then you only/just press Post, or Like or Buy. Some other applications however require interaction with more buttons. It is quite common to have Cut together with Copy and Paste, to have Undo and Redo, or to have Bold, Italic and Underline closely together, or New, Open and Save, just to give some examples. Those are not rules however. So it is quite common to expect that for a customized application, based on user requirements, that some buttons always appear in group and will be always together. For our modest demo application this holds as well - even that we can show only one of our custom buttons, they are always grouped together by three - every one of this triad displaying different topic. So why they should always be wide rectangle like controls next to each other or one above other?

### Design for usability

Again, if users want to Buy something and you give them three buttons, they will confuse. In such cases one button is enough, Buy. If a more complicated interaction is required however, if users can do A, B or C, it makes sense to have A, B and C buttons. What if we combine those buttons in one visual object and allow users to interact with its parts? This idea is not new. For example, you might look at stylized city map, where every district is made as UI element and it allows interactions. You can just press few districts and execute functionality, related to those districts. We will not make a city map, but something simpler - we will have a three ring segment with customized shapes, all representing a ring of flange. Users can click on those parts and interact with them. So instead of three wide rectangular shapes we will have only one circular shape. Again, in such situations you imaginations can shine, you can amaze users and make the interaction with your application pleasant and appealing.

### Summary of steps

Here is a summary of what we are going to do with Inkscape in this part:
* We will create a circle with fill and stroke occupying most of our document, centered in the middle of it.
* We will create second circle, having fill and stroke, but with smaller radius, and we will extract second from the first. Result will be something like fringe or ring with thick line.
* Then, we will remove three segments from our figure. We will do this in the following manner - we will create rectangle, having small width but height equal to half of our document size. We will duplicate this rectangle two times and we will rotate it around the center of the document, nor around the center of rectangle. Then, we will remove those rectangles from our main shape.
* Next, we will select edges of obtained segments, we will add more nodes to them and change their shape.
* Finally, we create several copies of this multi segment shape and modify every one of them, so that it fits for our needs - one will be made proper for Focused state - no fill for shapes and dash array for stroke, other for Mouse over, third for Pressed state.

### Step by step instructions

* We start Inkscape and to go <b>File -> Document Properties</b>, where we set display units to px, then we specify units for custom size again to pixels, then we set scale x and scale y to 1, and width and height to 640. 
* We select <b>Create circles, ellipses and arcs</b> button and we create a circle. We specify a color and stroke color that we like, and we set stroke width of 10. We specify X and Y equal to 20, and we set W and H equal to 600.
* We create another circle. X and Y for it are 170, and W and H are 300. We then click on the first circle, then Shift click on second and we go to <b>Path -> Difference</b>. A thick ring or maybe flange is what appears now on screen.
* We create a rectangle without a stroke. We set for it X = 240, Y = 0, W = 160 and H = 320. We then click not once, but twice on the rectangle. The arrows around its edges look twisted on 90° and inside it a cross-hair appears. This cross is the point, around which the rectangle can be rotated. We move it to the center of the document, (X = 320 Y = 320). Then we right click the rectangle and select duplicate.
* We again click twice (do not confuse it with double click) on duplicated rectangle to see the twisted arrows around its edges. We select one of those arrows and via it we rotate the rectangle.
* We do the same as previous point. We now have three rectangles rotated around the flange. We distribute them evently or in a way that we like.
* Now it is time to remove those rectangles from the main shape. We click on main shape, then Shift click on one of those rectangles and go to <b>Path -> Difference</b>. We do the same for remaining two rectangles. Here is the final result:
![Flange start](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part06-FlangeSegmentsRemoved.png?raw=true)
* We select our shape and go to <b>Path -> Break apart</b>. We how have three separate shapes. Let's give them some IDs, I go for left, right and down.
* Now, this is important, we are going to add more nodes, so that we can change shapes further. We go and select the <b>Edit path by nodes</b> tool and click on one of the parts, left for example. We see six white rhombus (or four edged diamonds) like figures appearing inside selected part. Without selecting other tool, with the mouse we make a rectangle around the bottom two rhombuses. 
* Those two turn to squares and change their color. They are now kind of active. Meanwhile, when we selected the tool, the toolbar for nodes appeared, usually in upper part of editor (unless some default settings have been changed). While two nodes we selected are still active, we go and click on <b>Insert new nodes into selected segments</b>. A new node should appear between selected two.
* We click on newly inserted node and we press the up arrow once. Node moves. We press it again. Node moves further. So either with mouse or with arrow keys, we can move the node and change the shape of our flange segment. Let's press it eight more times up and five times left.
* Following similar approach, we change the other end of this segment, and we change all remaining segments as well. It remains only to change colors for every segment, so that they look nice. We will pick again autogenerated colors from coolors.co and this time we stop the generation at efc69b-af1b3f-473144-ccb69b-df9b6d. Colors here are Gold Crayola EFC69B, Vivid Burgundy AF1B3F, Dark Byzantium 473144, Khaki Web CCB69B and Tan Crayola DF9B6D. Yes, those names should be autogenerated as well. Here is the final result:
![Segments changed](https://github.com/MahmudOnWeb/StylingAButton/blob/master/Part06-ChangedSegments.png?raw=true)

### What about Focused, Mouse Over, Pressed?

Now we have to think for following: How those buttons would look like when they are focused? How would they look when hovered? And when pressed? And a very important question - where we should display the content for every button? If it is inside the shapes, will their width be enough to display it horizontally? Shall we display it vertically and account for the curvature of shape itself? If we display the content dynamically - for example on mouse over in the transparent place in the middle of entire figure, what will happen when keyboard focus is on one button, and users hover on another?

About focused state - as we see in most of previous article part, usual approach for displaying focused state is to display dashed border around the button. In our case, if we try to do this in Blend, we have to work with `StrokeDashArray`, which is of type `DoubleCollection`. For it there is no default animation, so we have to deal with so many other stuffs. Far better solution is to just use two paths - one for normal stroke and one for focused, with Dash array different than those for normal, and on focused state we switch those two paths. We can make even more complex stroke in Inkscape - like adding some small complex shape on regular interval. It is up to you at the end, how creative you can be. If you design the dash array in Inkscape, like me, bear in mind that when it is exported (i.e. saved as XAML), it might require some manual tuning in order to work. For example, from Inkscape we can receive "80,20,10,20" and in Blend/Visual Studio this should be "8 2 1 2".

For mouse over we can decreate alpha component of fill colors a little bit and maybe use different stroke color.

And for pressed state some simple animation could be interesting and maybe displayinig something for few hundreds milliseconds in center of the figure, depending on the button being clicked.

As we mentioned above, text display is more tricky, but you have many options - you can make path which look like Text (and it was originaly a text), quite good solution, and few others not so good options as well. At the end, text itself depends on typography being used, which in turn is set of glyphs, which in turn are geometrical figures or paths. Using special path for every culture change is good option for localization, but even I am too lazy to implement it for all languages in this article. At the end of article however there is small gif, showing this idea, languages are only two. The code for it is not included in solution. You should however be able to do it yourself if you followed up to now. 

We create modified files of main figure for every state we have mentioned - focused, mouse over and pressed, and we save them for later use, and then we save them as XAML files. We will use part of those, when we make final control template for buttons. Time to go back to Blend and create last two views for the article. 

We make final two views - Infographics view and Infographics demo view. For the first one we will display every path in a separate viewbox, to show how the separate parts or segments look like. Notice that for second and third parts, because all of their points have coordinates with X and Y offsets, the actual path size is larger than the first one and viewbox zoom in much more in order to display shapes. When they are however placed together in one view box, they look just fine, exactly the way we designed them in Inkscape. 

Every button will have separate control template, so we have three control templates in total, using different paths. Notice the change in orientation, when change in flow direction for content presenter is made. This affects not only the content presenter itself, but entire figure orientation.

### Live preview: end of part six

Final demo of the article is what you have saw in the beginning. Gif progress through every part and for final changes it needs to be watched from start to end. In it the text is replaced by several lines, to emphasis the idea that we want paths instead of text (or glyphs). However, a properly styled and localized buttons should look like this:

![Live preview - bonus](https://github.com/MahmudOnWeb/StylingAButton/blob/master/TextAsPath.gif?raw=true)

The markup for this demo is now present in this solution, but it is quite similar. Buttons are styled, they do not use control template as before, but a style. In style itself there is data trigger, which changes the control template based on property of the view model. This way we control the current control template via binding. Preparation of control template itself, together with transformation of text to path takes more time and can be tedious to implement.

## I hope you like the article

I have tried to create a good educational article, which emphasis on few important points. If you completed the article, you might say you can style some XAML buttons. I have tried to fix all typos, code, functional or syntax, and I hopethere are none which are considerable. As I stated, most of translations for this article demo are made via machine translator, so I apologize for any improper translations. Any feedback on it, as well as on entire article, is welcomed. I hope someone find this article interesting.