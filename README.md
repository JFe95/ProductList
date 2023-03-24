# ProductList
Create an ASP.Net MVC page that will display a list of products and show how many times each
product has been clicked.

Technical Requirements

The project should be built in ASP.Net using an n-tier architecture connecting to a SQL
database. Use any libraries or frameworks you feel are appropriate. You may use front end
JavaScript if you feel it’s suited to a task.

Expected Output

Your solution should be added to a public source code repo (Github or similar) with all files
required to run the solution. Please commit after each task (or more frequently) as it’s just as
important to see your approach during the tasks as the final outcome.

Tasks

Task 1: build a product database and a page to display a list of products. Products should
contain the following information:
● Name
● Description
● Price
● Priority
Products should be displayed in alphabetical order by name. Products which are marked as
priority should be displayed first.

Task 2: products are displayed on an external site so need a URL. However, we want to track
the number of clicks on each product. Modify the product table to include the following:
● URL
● ViewCount
For the purposes of this test use example.com as the URL for all products.
When a user clicks on a product the ViewCount should be incremented and the user should be
taken to the external site. The ViewCount should be displayed next to the product.

Task 3: products need to be sortable by the following criteria:
● Default (the existing sort order from task 1)
● ViewCount
● Price
Modify the page to allow the user to sort by these methods and display the newly sorted
products as appropriate.
