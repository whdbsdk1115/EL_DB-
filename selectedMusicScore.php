<?php
	$servername = "localhost";
	$server_username = "phpmyadmin";
	$server_password = "abcd1234";
	$dbname = "wisecle";
	
	$user_id = $_POST["idPost"]; //사용자 id
	$musicNum = $_POST["musicPost"]; //검색할 음악번호
	
	$conn = new mysqli($servername, $server_username, $server_password, $dbname); 
	
	if(!$conn)
	{
		die("Connection Failed.". mysqli_connect_error());
	}
	
	if($user_id != null and $musicNum != null){ //선택된 음악의 사용자 점수
		$sql = "select * from record where id='".$user_id."' AND musicNumber = ".$musicNum.";"; 
		$result = mysqli_query($conn, $sql);
			
		if(mysqli_num_rows($result) > 0){
			while($row = mysqli_fetch_assoc($result)){
				echo $row['score'];
			}
		}else {
			echo "score not found";
		}
	}

?>