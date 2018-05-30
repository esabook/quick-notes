-- Check if record of inventory Borrowed or Returned
SELECT DISTINCT
	i.*,
	b.`Borrower_ID
`,
IF
	(ISNULL( r.`Returned_ID`), 'Borrowed' , 'Returned') AS 'Loan_Condition',
IF
	(ISNULL( r.`Returned_ID`), b.`Borrowed_ID` , r.`Returned_ID`) AS 'Condition_ID'
FROM
	`inventory` AS i
	INNER JOIN `borrowed_inventory` AS b ON i.`Inventory_ID` = b.`Inventory_ID`
	left JOIN `returned_inventory` AS r ON r.`Borrowed_ID` = b.`Borrowed_ID` 