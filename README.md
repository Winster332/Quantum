# Quantum

Quantum - designed to work with HTML and CSS, and web components, without using a server. You can build the design of your application on HTML and CSS, and run it as a normal application.
Features:
Quantum allows computations in C# and the native JavaScript.
Drawing graphics occurs by Skiasharp/OpenL. This allows you to increase the speed of drawing elements.
This is not Electron, and not a new browser. This technology allows you to use HTML/CSS rate for your needs.
WebAPI repeats API browsers, and you should not feel a significant difference in C# and JS using Quantum.

![N|Solid](https://github.com/Winster332/Quantum/blob/master/Images/logo.png)

### Why precisely Quantum?
Because the technologies of VPF, VF, Android, they do not simultaneously provide flexibility and cross-platform. For a quantum you do not have to learn something new. If you know the basics of CTML, that will be enough.

## Supports elements

| Group         | Element            | Support |
| ------------- |:------------------:| -------:|
|  HTML DOM     | [HTMLElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement)    | Yes   |
|  HTML         | [html](https://developer.mozilla.org/en-US/docs/Web/API/HTMLHtmlElement)     | Yes   |
|  HTML         | [body](https://developer.mozilla.org/en-US/docs/Web/API/HTMLBodyElement)     | Yes   |

## How it works

### Quantum html/css

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
       +-----------------------------+   +---------+    +-------------+    +----------+    +----------+
       |                                 | Binder  |---►| Frame tree  |---►| Painting |---►| Display  |
       |                                 +---------+    +-------------+    +----------+    +----------+
       ▼                                      ▲
  +----+----+    +---------+    +---------+   |
  |  CSS    |---►| Parser  |---►|  Rules  |---+
  +---------+    +---------+    +---------+ 
 ```
 
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
