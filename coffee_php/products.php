<?php
	
    require "conn.php";

	$category = $_POST["category"];	

	$result = array();
	$result['products'] = array();
	$select = "SELECT * from products where category = '$category'";
	$responce = mysqli_query($conn,$select);

	while ($row = mysqli_fetch_array($responce)) {
			$index['id'] = $row['0'];
			$index['product_name'] = $row['1'];
			$index['unit_price'] = $row['2'];
			$index['description'] = $row['3'];
			$index['category'] = $row['4'];
			$index['type'] = $row['5'];
			$index['date_created'] = $row['6'];
			$index['date_modified'] = $row['7'];

			array_push($result['products'], $index);
		}	
		
		$result["succes"] =1;
		echo json_encode($result);

	mysqli_close($conn);

?>