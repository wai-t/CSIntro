## 21 May 2025
### Project Review
- https://github.com/wai-t/vector/tree/feedback_wai
  
  We reviewed the maths used to calculate the area of a general polygon to make sure we understood it would serve our purpose. The polygon is modelled as an **ordered list** of at least 3 points. The **ordered list** property is important, and furthermore it is important that we use this as a closed circular list and so we used the indexing expression [index % numPoints]. For each point, we imagine the vector that points from (0,0) to the point. Then we use each consecutive pair of vectors A = V[index % numPoints], B = V[ (index+1) % numPoints] to form two sides of a triangle and calculate the area of the triangle as the cross-product AxB / 2. Then, by observing the area can be positive or negative depending on which way round the sides are ordered, we see that by adding them together we end up with the area of the polygon, and this works whether (0,0) is inside or outside of the polygon.
  $$ 
   \text{Area} = \frac{1}{2} \sum_{i=0}^{N} V[i] \times V[(i+1) \% N]
  $$
   Having observed that, we need to ensure that we create unit tests for these cases to make sure we understood the maths right, and have written the code right.

  We refactored the model classes so that they are in a new Class Library. We refined our understanding of the Model in MVC ([see](MVC.pptx)). In MVC the model contains the data and state that is needed to enable the View to display what the App needs to display. So this means that we should only put stuff in the the MVC model that is needed for the purposes of the App's behaviour. Different Apps might need different state and behaviour, but usually it would include things that support the drawing of visual attributes like lines and points. We moved the original classes in Model to the new Class Library because eventually we plan to enrich the model with more features such as frames of reference, coordinate systems, choice of number type, and many more possible aspects from the world of geometry which might not be relevant to an App. The Class Library is intended to support more than just UI clients, but can also support general applications which we can't even imagine right now. So the design philoshophy is to avoid making design decisions we don't have to. These include:
  - Using a generic IFloatingPoint<T> type instead of choosing float, double or Decimal to represent coordinates
  - Support polar coordinates ($r$,$\theta$) as well as cartesian ($x$, $y$)
  
  An enhancement could be to support arbitrary frames of reference (different locations of (0,0)). We need to think about how to design this. How would the user want to use this feature and what would make it natural to use.

  We added a class so that we can use the **facade** design pattern to make our library easier to use, while the complexity of the class system increases.
  
