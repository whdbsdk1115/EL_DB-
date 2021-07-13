using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//text
using UnityEngine.SceneManagement;//씬매니저

public class musicController : MonoBehaviour
{
    //오디오
    public AudioClip music;
    AudioSource aud;
    bool done;
    //텍스트
    public GameObject pauseText;//정지텍스트
    public Text hpText;
    public Text gameOver;
    //게임오브젝트
    private PlayController player;
    private ItemGenerator item;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayController>();
        item = this.GetComponent<ItemGenerator>();
        //오디오
        this.aud = GetComponent<AudioSource>();
        aud.Stop();
        aud.clip = music;
        // 뮤트: true일 경우 소리가 나지 않음
        aud.mute = false;
        // 루핑: true일 경우 반복 재생
        aud.loop = false;
        // 자동 재생: true일 경우 자동 재생
        aud.playOnAwake = false;
        //재생
        aud.Play();
        Time.timeScale = 1;//시간 정지
        done = true;
        //텍스트 안보이게
        pauseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //오디오 버튼
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            BackGroundMusicOffButton();
        }
        else if ((aud.isPlaying == false) && (done == true))
        {
            Test();
            if (Input.GetKeyDown(KeyCode.Z)) SceneManager.LoadScene("hardMap");//재시작
            else if (Input.GetKeyDown(KeyCode.X)) SceneManager.LoadScene("MainMenu");//나가기
        }

        //hp UI
        hpText.GetComponent<Text>().text = "HP: " + player.hp + "/100";
        
        if (player.hp <= 0)
        {
            GameOver();
            if (Input.GetKeyDown(KeyCode.Z)) SceneManager.LoadScene("hardMap");//재시작
            else if(Input.GetKeyDown(KeyCode.X)) SceneManager.LoadScene("MainMenu");//나가기
        }
    }

    [ContextMenu("clear")]
    void Test()
    {
        aud.Stop();
        Time.timeScale = 0;//시간 정지
        gameOver.GetComponent<Text>().text = "클리어\n점수:" + player.score + "\n" + clear() + "\n좌클릭:재시작/우클릭:나가기";
    }

    void GameOver()
    {
        gameOver.GetComponent<Text>().text = "게임오버\n점수:"+player.score+"\n좌클릭:재시작/우클릭:나가기";
        Time.timeScale = 0;//시간 정지
 
    }

    public void BackGroundMusicOffButton() //배경음악 키고 끄는 버튼
    {
        aud = GetComponent<AudioSource>(); //배경음악 저장해둠
        if (aud.isPlaying)
        {
            aud.Pause();
            done = false;
            pauseText.SetActive(true);
            Time.timeScale = 0;//시간 정지
            
        }
        else
        {
            done = true;
            Time.timeScale = 1;//시간 정상
            pauseText.SetActive(false);
            aud.Play();
        }
    }

    public string clear() //여기를 점수를 받고 db입력으로 바꾸자!
    {
        Debug.Log("점수" + player.score / item.total);

        if ((player.score / item.total) >= 0.9)
        {
            Debug.Log("S");
            return "S";
        }
        else if ((player.score / item.total) >= 0.8)
        {
            Debug.Log("A");
            return "A";
        }
        else if ((player.score / item.total) >= 0.7)
        {
            Debug.Log("B");
            return "B";
        }
        else if ((player.score / item.total) >= 0.6)
        {
            Debug.Log("C");
            return "C";
        }
        else if ((player.score / item.total) >= 0.5)
        {
            Debug.Log("D");
            return "D";
        }
        else
        {
            Debug.Log("E");
            return "E";
        }
    }

}
