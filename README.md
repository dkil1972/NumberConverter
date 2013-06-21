NumberConverter
===============

##Introduction
  The number converter takes any integer from 1 to 999,999,999 and converts it to an english equivalent. It was far more
  involved than I initially anticipated, especially converting thousands (where do the hundreds start?).
  
##Implementation
  For the conversion work I have gone for a composite pattern with a printer being composed of other printers that know 
  how to handle numbers with a lower value. The controller depends on a factory that knows how to create printers based
  on the size of the number to convert. The controller will then call print on the returned printer resulting in a text
  representation.
  
##Testing
  I used Specflow to write acceptance tests based on the examples in the requirements document. I have also used spec salad that
  allows me to avoid using step definitions (which can get very unwieldy quite quickly). I concentrated on the 
  happy path for the acceptance tests, in a real system I would have written examples of behaviour with invalid input.
  
  For the unit level tests I have used MSpec, fairly standard stuff not much to say on the matter.

##What I should have done if I had time
  * Created a view
  * Put autofac in to inject the dependency into the controller
  * implemented a build that builds the solution and runs the tests
  * Implemented equality on Number (value object) and not exposed the underlying value
  * Validated the input - this would be the responsibility of Number to handle
  * Moved the printer creation into factory methods? (maybe)
  
