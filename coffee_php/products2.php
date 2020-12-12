<?php
	
    require "conn.php";

	$userID = $_POST["userID"];	

	$result = array();
	$result['sales'] = array();
	$select = "SELECT o.order_date, o.type,p.unit_price, p.product_name,u.first_name FROM orders o INNER JOIN products p ON p.productID = o.productID INNER JOIN users u ON u.id = o.userID where o.userID = '$userID' and DATE(o.order_date) = CURDATE()";
	$responce = mysqli_query($conn,$select);

	while ($row = mysqli_fetch_array($responce)) {
			$index['order_date'] = $row['0'];
			$index['type'] = $row['1'];
			$index['unit_price'] = $row['2'];
			$index['product_name'] = $row['3'];
			$index['first_name'] = $row['4'];

			array_push($result['sales'], $index);
		}	
		
		$result["succes"] =1;
		echo json_encode($result);

	mysqli_close($conn);

?>