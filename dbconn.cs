using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;     //C#의 데이터 테이블 때문에 사용
using MySql.Data;     //MYSQL함수들을 불러오기 위해서 사용
using MySql.Data.MySqlClient;    //클라이언트 기능을사용하기 위해서 사용
MySqlConnection sqlconn = null;
private string sqlDBip = "122.32.165.55";
private string sqlDBname = "coex";
private string sqlDBid = "team";
private string sqlDBpw = "abcd1234";

private void sqlConnect()
{
    //DB정보 입력
    string sqlDatabase = "Server=" + sqlDBip + ";Database=" + sqlDBname + ";UserId=" + sqlDBid + ";Password=" + sqlDBpw + "";

    //접속 확인하기
    try
    {
        sqlconn = new MySqlConnection(sqlDatabase);
        sqlconn.Open();
        Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 되면 OPEN이라고 나타남
    }
    catch (Exception msg)
    {
        Debug.Log(msg); //기타다른오류가 나타나면 오류에 대한 내용이 나타남
    }
}

private void sqldisConnect()
{
    sqlconn.Close();
    Debug.Log("SQL의 접속 상태 : " + sqlconn.State); //접속이 끊기면 Close가 나타남 
}

public void sqlcmdall(string allcmd) //함수를 불러올때 명령어에 대한 String을 인자로 받아옴
{
    sqlConnect(); //접속

    MySqlCommand dbcmd = new MySqlCommand(allcmd, sqlconn); //명령어를 커맨드에 입력
    dbcmd.ExecuteNonQuery(); //명령어를 SQL에 보냄

    sqldisConnect(); //접속해제
}

public DataTable selsql(string sqlcmd)  //리턴 형식을 DataTable로 선언함
{
    DataTable dt = new DataTable(); //데이터 테이블을 선언함

    sqlConnect();
    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmd, sqlconn);
    adapter.Fill(dt); //데이터 테이블에  채워넣기를함
    sqldisConnect();

    return dt; //데이터 테이블을 리턴함
}


# 클래스 불러오는 방법 
# dbconn mysqlDB = new dbconn();
# mysqlDB.sqlcmdall("SQL구문을 적으면 됩니다. (UPDATE, INSERT 구문 사용)");
# DataTable dt = mysqlDB.selsql("SQL구문을 적으면 됩니다. (SELECT구문 사용)'")
