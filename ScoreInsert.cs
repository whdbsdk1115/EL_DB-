using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//게임 종료 후, insert하는 cs
public class ScoreInsert : MonoBehaviour
{
    dbconn mysqlDB = new dbconn();
    public void OnClickUpdate()
    {
        mysqlDB.sqlcmdall("INSERT INTO `player`(`musicnum`, `username`, `score`) VALUES (10,'LEE',100000)");
    }
    
}

//스크립트 파일 button에 적용하고 On Click()부분에 맞는 함수 적용시켜주면 돼용
