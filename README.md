# Quantum

Quantum - designed to work with HTML and CSS, and web components, without using a server. You can build the design of your application on HTML and CSS, and run it as a normal application.
Features:
Quantum allows computations in C# and the native JavaScript.
Drawing graphics occurs by Skiasharp/OpenL. This allows you to increase the speed of drawing elements.
This is not Electron, and not a new browser. This technology allows you to use HTML/CSS rate for your needs.
WebAPI repeats API browsers, and you should not feel a significant difference in C# and JS using Quantum.

Quantum provides cross-platform bindings for:

 - .NET Standard 1.3
 - .NET Core
 - Tizen
 - Xamarin.Android
 - Xamarin.iOS
 - Xamarin.tvOS
 - Xamarin.watchOS
 - Xamarin.Mac
 - Windows Classic Desktop (Windows.Forms / WPF)
 - Windows UWP (Desktop / Mobile / Xbox / HoloLens)

The [API Documentation](https://doc/) is
available on the web to browse.

<br/>

![N|Solid](https://github.com/Winster332/Quantum/blob/master/Images/logo.png)

### Why precisely Quantum?
Because the technologies of VPF, VF, Android, they do not simultaneously provide flexibility and cross-platform. For a quantum you do not have to learn something new. If you know the basics of CTML, that will be enough.

## Supports elements

| Group         | Element            | Support |
| ------------- |:------------------:| -------:|
|  HTML DOM     | [HTMLElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement)    | Yes   |
|  HTML         | [html](https://developer.mozilla.org/en-US/docs/Web/API/HTMLHtmlElement)     | Yes   |
|  HTML         | [body](https://developer.mozilla.org/en-US/docs/Web/API/HTMLBodyElement)     | Yes   |
|  HTML         | [HTMLFormElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLFormElement)     | Yes   |
|  HTML         | [HTMLCanvasElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLCanvasElement)     | Yes   |
|  HTML         | [HTMLAnchorElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLAnchorElement)     | Yes   |
|  HTML         | [HTMLAudioElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLAudioElement)     | No   |
|  HTML         | [HTMLBRElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLBRElement)     | No   |
|  HTML         | [HTMLButtonElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLButtonElement)     | Yes   |
|  HTML         | [HTMLDivElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLDivElement)     | Yes   |
|  HTML         | [HTMLImageElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLImageElement)     | No   |
|  HTML         | [HTMLInputElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLInputElement)     | Yes   |
|  HTML         | [HTMLHeadElement](https://developer.mozilla.org/ru/docs/Web/API/HTMLHeadElement)     | Yes   |

## How it works

### Stage 1. Loading

At stage 1, the document loading html. Loading styles and scripts is based on the html file, or separately, by means of a bindig. DOM is built tree.

  ```ditaa {cmd=true args=["-E"]}
                                +---------+
                                |   DOM   |
                                +---------+
                                     ▲                    +---------+
                                     |                    | Reflow  |
  +---------+    +---------+    +---------+               +---------+   
  |  HTML   |---►| Parser  |---►| Content |---+                ▲
  +---------+    +---------+    +---------+   |                |
                                     |        ▼                ▼        
       +-----------------------------+   +---------+    +-------------+    +----------+
       |                                 | Binder  |---►| Frame tree  |---►| Painting |
       |                                 +---------+    +-------------+    +----------+
       ▼                                      ▲
  +----+----+    +---------+    +---------+   |
  |  CSS    |---►| Parser  |---►|  Rules  |---+
  +---------+    +---------+    +---------+ 
 ```

 ### Stage 2. Painting
For rendering, [OpenGL](https://github.com/opentk/opentk) and [SkiaSharp](https://github.com/mono/SkiaSharp) are used. They allow you to draw elements through GPU if possible. The collected data from stage 1 is accumulated and transferred to stage 2.
Built render tree. Transforms styles for [SkiaSharp](https://github.com/mono/SkiaSharp). Build lineup. The tree with the elements of the arrangement is transmitted to [OpenGL](https://github.com/opentk/opentk) where the final output to the screen takes place.
 
  ```ditaa {cmd=true args=["-E"]}
              +--------------+
              |  Skia paint  |---+
              +--------------+   |
                     ▲           ▼
  +--------------+   |     +------------+    +----------+
  |   Painting   |---+     | Transform  |---►| Display  |
  +--------------+   |     +------------+    +----------+
                     ▼           ▲
              +--------------+   |
              | Сomposition  |---+
              +--------------+
  ```

 ### Audio cross-platform
 
For cross-platform audio playback, a special module is used that uses [AFPlay/AFInfo](https://github.com/Winster332/AFPlay) for MacOS, [NAudio](https://github.com/naudio/NAudio) for Windows, and must be implemented for Android and Linux.

### Language

You can choose the language you want to use. 

 ### Other

  ```ditaa {cmd=true args=["-E"]}
  +--------+   +--------+    +--------+           +--------+   +--------+   +--------+
  |  HTML  |   |  CSS   |    |  DOM   |           | Window |   | Window |   | Window | 
  +--------+   +--------+    +--------+---+       +--------+   +--------+   +--------+<--+
  |Document|   | Sheet  |    | Window |   |       | OpenGL |   |  Skia  |   | Events |   |
  | Parser |   | Parser |    |  Init  |   |       |  Init  |   |  Init  |   |  Init  |   |
  +---+----+   +---+----+    +--------+   |       +----+---+   +----+---+   +---+----+   |
      :            :             ^        |            :            :           :        |
      |            |             |        |            |            |           |        |
      +------------+-------------+        |<-----------+------------+-----------+        |
                                          |            |            |           |        |
                                          |            :            :           :        |
  +--------+  +---------+    +--------+   |       +----+---+   +----+---+   +---+----+   |
  |        |  |         |    |        |   |       | Script |   | Window |   |  HTML  |   |
  | Render |<-| Compose |<---| Styles |<--+       +--------+   +--------+   +--------+<--+
  |        |  |         |    |        |           |  HTML  |   | Inputs |   | Events |
  +--------+  +---------+    +--------+           +--------+   +--------+   +--------+
 ```
### Links

[MDN](https://developer.mozilla.org/en-US/)
<br/>
[OpenTK](https://github.com/opentk/opentk)
<br/>
[SkiaSharp](https://github.com/mono/SkiaSharp)
<br/>
[NAudio](https://github.com/naudio/NAudio)
