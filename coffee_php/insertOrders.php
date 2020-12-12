<?php
	
    require "conn.php";

	$type = $_POST["type"];
	$order_date = $_POST["order_date"];
	$date_modified = $_POST["date_modified"];
	$status = $_POST["status"];
	$userID = $_POST["userID"];
	$productID = $_POST["productID"];
	

	$sql = "INSERT INTO orders(type,order_date,date_modified,status,userID,productID) VALUES ('$type','$order_date','$date_modified','$status', '$userID','$productID')";

	$result = mysqli_query($conn,$sql);

	if($result){
		echo "Data Inserted";
	} else {
		echo "Failed";
	}

	mysqli_close($conn);

?>