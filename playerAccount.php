<?php
	$servername = "localhost";
	$server_username = "phpmyadmin";
	$server_password = "abcd1234";
	$dbname = "wisecle";
	
	$user_id = $_POST["idPost"]; //사용자 id
	$command = $_POST["cmd"]; //사용할 sql
	
	$conn = new mysqli($servername, $server_username, $server_password, $dbname);
	
	if(!$conn)
	{
		die("Connection Failed.". mysqli_connect_error());
	}
	
	if($command == "player"){ //사용자의 닉네임
		$sql = "select * from users where id = '".$user_id."'";
		$result = mysqli_query($conn, $sql);
	
		if(mysqli_num_rows($result) != 0){
			while($row = mysqli_fetch_assoc($result)){
				echo $row['nickname'];
			}
		}else {
			echo "player not found";
		}
	}
	
	if($command == "music"){ //사용자의 S등급 클리어 개수
		$sql = "select COUNT(*) AS clear from record where id = '".$user_id."' AND score >= 100"; 
		$result = mysqli_query($conn, $sql);
	
		if(mysqli_num_rows($result) != 0){
			while($row = mysqli_fetch_assoc($result)){
				echo $row['clear'];
			}
		}else {
			echo "music not found";
		}
	}
	
	if($command == "achieve"){ //사용자의 업적 개수
		$sql = "select COUNT(*) AS achieveC from achieve where id = '".$user_id."' AND ok = '1'";
		$result = mysqli_query($conn, $sql);
	
		if(mysqli_num_rows($result) != 0){
			while($row = mysqli_fetch_assoc($result)){
				echo $row['achieveC'];
			}
		}else {
			echo "achive not found";
		}
	}
	
	if($command == "health"){ //사용자의 하루치 운동량
		$sql = "select playTime, distance, calorie from health where id = '".$user_id."' AND today = date(now())";
		$result = mysqli_query($conn, $sql);
	
		if(mysqli_num_rows($result) != 0){
			while($row = mysqli_fetch_assoc($result)){
				echo "|playTime:".$row['playTime']. "|distance:".$row['distance']. "|calorie:".$row['calorie'];
			}
		}else {
			echo "health not found";
		}
	}
	
	
?>