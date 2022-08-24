# ASP.Net_E-commerce_OmegaParts
A basic E-commerce website with 2 product pages and a cart made using ASP.NET.
## About The Project
The project was created for a university course the idea behind it was to have two simple product pages that got their products from a database and a functional cart that would save the orders to the database. On the product pages the user has the ability to add products to the cart and on the cart page the user has three information field to fill (Name, Phone number and address) and the option to remove items from the cart. There is validation to check if the 3 fields and the cart are not empty.
### Build With
The project is made with ASP.NET Razor Pages and the Entity Framework and uses a LocalDB database. Bootstrap is used for the front end of the project.
## Usage
### The product pages
The product pages show all products from the given category that are in the database and provide the user with the ability to add them to the cart by pressing the "Add to Cart" button.
![a1](https://user-images.githubusercontent.com/95367525/186520126-f6513a76-44ac-463e-a136-74b0271bf721.PNG)
### The Cart
The cart page provides the user with 3 input fields for the name, the address and the phone number of the user. There is a "Remove" button next to every item that gives the user the option to remove that item from the cart. When the "Submit" button is pressed it saves the order to the database if the validation passes. The validation checks if all 3 input fields and the cart are empty and it ensures that the "Name" field contains only text and that the "Phone number" field contains only numbers.
![a2](https://user-images.githubusercontent.com/95367525/186522739-7c2013ab-6130-4367-9a3d-5c03579c10ee.PNG)
### The Database
LocalDB is used for the database it has 3 simple table one for each product type and one table for the orders.
![a3](https://user-images.githubusercontent.com/95367525/186523619-f2064c28-197b-4165-a39d-73853999d6dc.PNG)
![a4](https://user-images.githubusercontent.com/95367525/186523636-841837f6-768b-4801-9649-9b7511d0ae1a.PNG)
![a6](https://user-images.githubusercontent.com/95367525/186523782-e122c6f8-bfb9-4e78-aa98-c856e00f914e.PNG)
