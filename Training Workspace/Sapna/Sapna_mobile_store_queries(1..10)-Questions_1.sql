-- 1. List all the products
	

-- 2. List product name and product price
	

-- 3. List all customers
	

-- 4. List Customername and mobile no
	

-- 5. List all orders
	

-- 6. List customer id and orderd date
	

-- 7. List all the order item
select * from orderitem;
	

-- 8. List all the product with product id 100
	select * from product where pid=100;

-- 9. List all the info of product with name Lumia 640
	select * from product where productname like 'lumia 640';

-- 10. List pid, productname, price of the phone named "Galaxy Grand"
	
	select pid,productname,price  from product where productname like 'Galaxy Grand';
-- 11. Print product info for all the product with category id 10003
select * from product where categoryid=10003;
	

-- 12. List all the customers address with city as 'Bangalore'
select * from customeraddress where city like 'bangalore';

-- 13. List all the orders which was ordered on '2013-02-02'
select * from orderd where orderdate like '2013-02-02';

-- 14. Print all the orders of the customer with id 1
select * from orderd where customerid=1;

-- 15. List all the product with company id 1001 or 1002
select * from product where companyid in (1001,1002);
-- 16. List all the product with price more than 30000
select * from product where price>30000;
-- 17. List all the products of the category id 10001 or 10003 with 
-- the price more than 30000

select * from product where categoryid in (10001,10003) and price>30000;
-- 18. List all the order customer id 1 or 4 ordered on '2013-02-02' 
-- or '2013-02-07'
select * from orderd where customerid in (1,4) and orderdate like  '2013-02-02' ;

-- 19. List all the customer whos name starts with character 'A'

select * from customer where customername like 'a%';
-- 20. List all the customer who name ends with character 'i'

select * from customer where customername like '%i';
-- 21. List all the customer whos name starts with 'R' and ends with 'i'
select * from customer where customername like 'R%i';

-- 22. List all the orders for the year 2013
select * from orderd where orderdate like '2013%'
-- 23. List all the products which are not from the category 10001
select * from product where categoryid not in (10001);
-- 24. List all the products which are not from the category 10001
-- or 10003 with the price more than 30000 and product name starts 
-- with '6'
select * from product where categoryid not in (10001,10003) and price>30000 and productname like '6%';
-- 25. List all the customers whos mobile no doesnt start with 9

select * from customer where mobileno not like '9%';
-- 26. List all the nokia phones
select productname from product,company where product.companyid=company.companyid and company.companyname like 'nokia';
-- 27. List all the samsung phones
select productname from product where companyid in (select companyid from company where companyname like 'samsung');

-- 29. List all the customers from Bangalore
select * from customer where customerid in (select customerid from customeraddress where city like 'bangalore');

-- 30. List all the customers who are not from Bangalore
select * from customer where customerid in (select customerid from customeraddress where city  not like 'bangalore');
-- 31. List all the customer who have orderd on the date '2013-02-02'
select * from customer where customerid in (select customerid from orderd where orderdate like '2013-02-02');
-- 32. List all the customer who have orderd for phone '6S'
select * from customer where  customerid in 
(select customerid from orderd where orderid in 
(select orderid from orderitem where pid in 
(select pid from product where productname like '6s'))); 
-- 33. List all the customers who have ordered for Moto-G from bangalore
select * from customer where  customerid in
(select customerid from orderd where orderid in 
(select orderid from orderitem where pid in 
(select pid from product where productname like 'Moto-G')))and customerid in
( select customerid from customeraddress where city like 'bangalore'); 
-- 34. List all the phones which Goutham orderd for
select productname from product where pid in 
(select pid from orderitem where orderid in 
(select orderid from orderd where customerid in
(select customerid from customer where customername like 'Goutham')));
-- 35. List all the phones which Amrutha orderd for in the 2014
select productname from product where pid in 
(select pid from orderitem where orderid in 
(select orderid from orderd where orderdate like '%2014' and customerid in
(select customerid from customer where customername like 'amrutha')));




select productname from product where pid in 
(select pid from orderitem where orderid in 
(select orderid from orderd where customerid in
(select customerid from customer where customername like 'Amrutha')))and pid in
(select pid from orderitem where orderid  in 
(select orderid from orderd where orderdate like '%2014')) ;
-- 36. List all the customer who have not bought any product

-- 37. List Fav phones of Bangalorean

-- 38. List all the products which were sold in the year 2013
 
-- 39. List all the Nokia phones orderd by 'Ravi'

-- 40. List all the phones with its company name

-- 41. List companyid, companyname, pdoructname, product price of all products

-- 42. List customer name, stname and city of all the customer.

-- 43. List customer name and customer city  of all the customer
-- who have never bought any product

-- 44. List Customer id, customer name, orderdate, of all the orders

-- 45. List Customer id, customer name, orderdate, company and 
-- product name with qty, price of all the orders

-- 46. List Customer id, customer name, orderdate, company and 
-- product name with qty, price and amount of all the orders 
-- where amount is qty*price

/* 47. List Customer id, customer name, orderdate, company and 
product name with qty, price and amount of all the orders  
where amount > 50,000 (amount is qty*price) */


/* 48. List customerid, customername, city, companyname, productname,
qty, price and amount of all the products orderd */


/* 49. List all product, company, customer and 
customer address details for all orders
which were ordered in the year 2014
*/


/* 50. Update amount of order item */





































































































































