<?php
	
    require "conn.php";

	$result = array();
	$result['users'] = array();
	$username = $_POST["username"];
	$password_hash = $_POST["password_hash"];
	
	$sql_query = "SELECT * FROM users WHERE username ='$username' and password_hash = '$password_hash'";
		
	$responce = mysqli_query($conn,$sql_query);

	while ($row = mysqli_fetch_array($responce)) {
			$index['id'] = $row['0'];
			$index['first_name'] = $row['1'];
			$index['last_name'] = $row['2'];
			$index['username'] = $row['3'];
			$index['password_hash'] = $row['4'];
			$index['telephone_number'] = $row['5'];


			array_push($result['users'], $index);
		}
		$result["succes"] =1;
		echo json_encode($result);	

		 $res = mysqli_query($conn,$sql_query);

    //fetching result
    $check = mysqli_fetch_array($res);	

		if($check){
		echo "po";
	} else {
		echo "Failed";
	}
		mysqli_close($conn);


?>