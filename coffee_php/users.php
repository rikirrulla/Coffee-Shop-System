<?php
	
    require "conn.php";

	$result = array();
	$result['users'] = array();
	$select = "SELECT * from users";
	$responce = mysqli_query($conn,$select);

	while ($row = mysqli_fetch_array($responce)) {
			$index['id'] = $row['0'];
			$index['first_name'] = $row['1'];
			$index['last_name'] = $row['2'];
			$index['username'] = $row['3'];
			$index['pin_code'] = $row['4'];
			$index['password_hash'] = $row['5'];
			$index['telephone_number'] = $row['6'];



			array_push($result['users'], $index);
		}	
		
		$result["succes"] =1;
		echo json_encode($result);

	mysqli_close($conn);

?>