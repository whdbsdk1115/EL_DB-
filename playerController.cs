using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayController : MonoBehaviour
{
    public float hp;
    public float score;
    float size;

    public GameObject frontHp;//hp
    void Start()
    {
        hp = 100;
        score = 0;
        size = 350;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //핸들로 위치변경
        float x = transform.position.x;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(x - 2, 5, -2);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(x + 2, 5, -2);
        }
        //맵이탈금지
        if (x < -5) transform.position = new Vector3(-4,5,-2);
        else if (x > 5) transform.position = new Vector3(4, 5, -2);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            hp -= 10;
            Debug.Log("충돌함");
            RectTransform rectTran = frontHp.GetComponent<RectTransform>();
            size -= 35f;
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        }
        if (other.gameObject.tag == "item")
        {
            score += 10;
            Debug.Log("아이템을 먹음!");
        }
    }
}
