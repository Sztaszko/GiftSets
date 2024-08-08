-- Write your own SQL object definition here, and it'll be included in your package.

-- Insert rows into table 'Products'
INSERT INTO Products
( -- columns to insert data into
 [name], [price], [vendor]
)
VALUES
( -- first row: values for the columns in the list above
 'koszyk', 10, 'Auchan'
),
( -- second row: values for the columns in the list above
 'czekolada Milka', 8.50 , 'Biedronka'
)
-- add more rows here
GO