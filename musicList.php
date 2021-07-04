<?php
	$servername = "localhost";
	$server_username = "phpmyadmin";
	$server_password = "abcd1234";
	$dbname = "wisecle";
	
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	if(!$conn)
	{
		die("Connection Failed.". mysqli_connect_error());
	}
	
	$sql = "select * from music"; //모든 음악 리스트 출력
	$result = mysqli_query($conn, $sql);
		
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo "|musicNumber:".$row['musicNumber']. "|title:" .$row['title'];
			echo "|composer:" .$row['composer']. "|img:" .$row['img'];
			echo "|runtime:" .$row['runtime']. "|bpm:" .$row['bpm'];
			echo "|route:" .$row['route']. "|level:" .$row['level'].";";
		}
	}else {
		echo "music not found";
	}
	
?>
