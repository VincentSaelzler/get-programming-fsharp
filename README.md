# Highlights
Important concepts to remember.
```f#
// this could be used to transform dramatically different types of records
// for example, an incoming marketo api response to a CSV row.
// 20.1.3 comprehensions
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for n in 1 .. 5 -> n * n ]
```