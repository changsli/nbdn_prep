#Rules for equality comparisons (.Net)


##Is it a class (reference type)

* Does it implement IEquatable<T> for itself - use it
* Does it override Equals - use it
* Reference based equality

##Is it a struct (value type)

* Does it override Equals - use it
* Reflective - field by field equality check



