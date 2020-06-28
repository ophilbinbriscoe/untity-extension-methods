# Unity Extensions
Various utility functionality, implemented as C# extension methods.

## List Extensions
Some RNG-based extensions for common gameplay code (getting a random element from a list, shuffling a list, etc.). Also includes a flexible extension for formatting lists as human-readable strings, similar to python's `String.join()`.

## String Extensions
These are mostly for transforming strings using Unity's HTML tags (such as `<color>`, `<b>`, `<i>`).

## Vector Extensions
A couple of extensions that will return a Vector2/3 with one of its components modified, as well as some shorthand for swizzling a Vector2 into a Vector3 and flatting a Vector3 into a Vector2.

## GameObject/Component Extensions
Simple queries such as `HasComponent<T>` if you're tired of null checking.
  
## Rect/Event Extensions
Multitude of methods for transforming Unity's Rect structs. Useful for building custom Editor GUIs using the legacy immediate-mode GUI.

## MoreGizmos
Extends gizmo drawing by exposing primitive drawing functions (disc, label), only found in the Handles class to non-editor code.
