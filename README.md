# Quantum

| Group         | Element            | Support |
| ------------- |:------------------:| -------:|
|  HTML DOM     | [HTMLElement](https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement)    | Yes   |
|  HTML         | [html](https://developer.mozilla.org/en-US/docs/Web/API/HTMLHtmlElement)     | Yes   |
|  HTML         | [body](https://developer.mozilla.org/en-US/docs/Web/API/HTMLBodyElement)     | Yes   |

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
