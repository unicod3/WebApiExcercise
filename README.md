# WebApiExcercise

Project Structure
-----------------
There are five models in the project 
- Suppliers
- Users 
- Products
- Purchase Orders
- Sales Orders

All of them has it's own page with AngularJS CRUD implementation on the front-end

How to keep track of stock
--------------------------
Stock depends on Purchase orders and Sales orders so formula is:
- Purchase Order Quantity - Sales Order Quantity

If I create a purchase order then Product's quantity will rise 
If a create a sales order then Product's quantity will decrease

Database
--------
This project is a test project therefore I did not use any database but I have a helper class with some test data in it.





