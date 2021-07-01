using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 노래를 시선(ray)으로 선택한 뒤 버튼을 누르면 상세 설명으로 데이터 전송 및 출력 -> play에 연결된 screen 변경

public class MusicItem : MonoBehaviour
{
    private string player = null;

    public Text musicTitle;
    public Text musicComposer;
    //public Text musicLevel;
    public Text musicTime;
    public Text musicBpm;
    public Text playerScore;
    public Text musicPercent;
    public Text playerScore_text;

    public string[] music;
    public string InputMusicNum;

    void Start()
    {
        player = UserLogin.InputUserId;
        if (player != null)
        {
            StartCoroutine(GetMusicItem());
        }

    }

    IEnumerator GetMusicItem() //음악 리스트 및 그에 대한 사용자 정보
    {
        WWWForm form = new WWWForm();

        WWW musicData = new WWW("http://localhost/musicList.php", form); // 변경필요
        yield return musicData;
        string musicDataString = musicData.text;
        Debug.Log(musicDataString);
        music = musicDataString.Split(';');

        InputMusicNum = GetDataValue(music[0], "musicNumber:"); //score 검색할 musicNumber
        StartCoroutine(GetPlayerScore(player, InputMusicNum));

        musicTitle.text = GetDataValue(music[0], "title:");
        musicComposer.text = GetDataValue(music[0], "composer:");
        musicTime.text = GetDataValue(music[0], "runtime:00:");
        musicBpm.text = GetDataValue(music[0], "bpm:");

    }

    IEnumerator GetPlayerScore(string player, string musicNum) //음악에 대한 사용자 스코어
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", player);
        form.AddField("musicPost", int.Parse(musicNum));

        WWW ScoreData = new WWW("http://localhost/selectedMusicScore.php", form); //변경필요!
        yield return ScoreData;

        int PlayerScoreData = int.Parse(ScoreData.text);
        playerScore.text = "my score: "+PlayerScoreData;
        musicPercent.text = ""+PlayerScoreData+ "%"; //나중에 (실제 노래 플레이 타임/풀타임)으로 변경

        if (PlayerScoreData == 100) {
            playerScore_text.text = "S";
        } else if(PlayerScoreData > 80){
            playerScore_text.text = "A";
        } else if (PlayerScoreData > 60){
            playerScore_text.text = "B";
        } else if (PlayerScoreData > 40){
            playerScore_text.text = "C";
        } else if (PlayerScoreData > 20){
            playerScore_text.text = "D";
        } else if (PlayerScoreData > 0){
            playerScore_text.text = "E";
        } else {
            playerScore_text.text = "F";
        }
    }

    /*
    void changeStar(int level)
    {
        Debug.Log("-------------------------" + level);
        int t = 1;
        while (t <= level)
        {
            GameObject.Find("star" + t + "").SetActive(false);
            t++;
        }
    }
    */

    string GetDataValue(string data, string index1)
    {
        string value = data.Substring(data.IndexOf(index1) + index1.Length);
        value = value.Remove(value.IndexOf("|"));
        if(index1 == "level:")
        {
            value = value.Remove(value.IndexOf(";"));
        }
        return value;
    }
}
