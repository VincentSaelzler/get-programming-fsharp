# Credits
Isaac Abraham wrote the book [Get Programming with F#](https://www.manning.com/books/get-programming-with-f-sharp).

I'm just working through the examples in the book.

# Highlights
Important concepts to remember.
```f#
// this could be used to transform dramatically different types of records
// for example, an incoming marketo api response to a CSV row.
// 20.1.3 comprehensions
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for n in 1 .. 5 -> n * n ]
```

```f#
///tons of code can all be written in the describe
// function without regard to dealing with null values. then wrap it in an option.map
// the option.map will return none if the input is none, ortherwise do the code
// this is called lifting a function
let optionalDescribe = Option.map describe
```

# Further Reading
22.3 Scott Wlaschin's many excellent articles on monads.
22.4 - "Railway-Oriented Programming" on the F# for Fun and Profit website.
