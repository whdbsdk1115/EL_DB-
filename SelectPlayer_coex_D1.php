<?php
	$servername = "122.32.165.55";
	$server_username = "team";
	$server_password = "abcd1234";
	$dbname = "coex";
	
	$musicnum = $_POST["musicnum"]; //고유 음악 번호
	
	$conn = new mysqli($servername, $server_username, $server_password, $dbname); 
	
	if(!$conn)
	{
		die("Connection Failed.". mysqli_connect_error());
	}
	
	if($musicnum == 10){ //10번음악일 경우
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 11) { //11
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 20) { //20
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 21) { //21
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 30) { //30
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 31) { //31
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 40) { //40
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else if($musicnum == 41) { //41
		$sql = "select * from player where musicnum = ".$musicNum.";";
		$result = mysqli_query($conn, $sql);
	} else {
		echo "Warning : Query Error!";
	}
?>