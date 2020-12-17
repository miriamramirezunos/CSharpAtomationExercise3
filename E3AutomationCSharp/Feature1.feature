Feature: Feature1
	Specflow Extension Visual Studio - Search products and add them to the cart 

@mytag
Scenario: Amazon Interaction
	Given Go to Amazon.com.mx
	When Login with valid credentials
	And Search for product: 'Samsung Galaxy S9 64GB'
	And Select first product with price and save the price
	And Click on the product
	Then Validate first price vs detail price
	When Click on Add to Cart
	Then Validate again, first price vs current price
	And Validate that the Shop car has '1' as a number
	When Search for another product: 'Alienware Aw3418DW'
	And Select First product
	And Add to Cart
	Then Verify that the cart number is now '2'