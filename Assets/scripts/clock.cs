using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;


public class clock : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] hours = new GameObject[12];
    public GameObject[] minuts = new GameObject[12];
    public TextMeshPro formin;
    public TextMeshPro forhour;
    public TextMeshPro WIN;
    public TextMeshProUGUI min;
    public TextMeshProUGUI hor;
    void Start() // убирается определённые стрелки для минут и часов
    {
        WIN.text = "";
        hours[0].SetActive(true);
        hours[1].SetActive(false);
        hours[2].SetActive(false);
        hours[3].SetActive(false);
        hours[4].SetActive(false);
        hours[5].SetActive(false);
        hours[6].SetActive(false);
        hours[7].SetActive(false);
        hours[8].SetActive(false);
        hours[9].SetActive(false);
        hours[10].SetActive(false);
        hours[11].SetActive(false);
        minuts[11].SetActive(true);
        minuts[1].SetActive(false);
        minuts[2].SetActive(false);
        minuts[3].SetActive(false);
        minuts[4].SetActive(false);
        minuts[5].SetActive(false);
        minuts[6].SetActive(false);
        minuts[7].SetActive(false);
        minuts[8].SetActive(false);
        minuts[9].SetActive(false);
        minuts[10].SetActive(false);
        minuts[0].SetActive(false);
        hour = UnityEngine.Random.Range(1, 13);
        minu = UnityEngine.Random.Range(1, 13);
        if (hour == 1) hour = UnityEngine.Random.Range(1, 13); ;
        formin.text=minu.ToString();
        forhour.text = hour.ToString();
        hour = -1; // значения, нужные для головоломки (часы минуты соответственно)
        minu = -1; // 
    }
    
    int hour;
    int minu;
    int lasthor;
    int lastmin;
    //public TextMeshProUGUI output;
    // Update is called once per frame

    public void DataHour(int val)
    {
        if (val == 0)
        {
            hour = 1; hours[0].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 1)
        {
            hour = 2; hours[1].SetActive(true); 
            hours[0].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 2)
        {
            hour = 3; hours[2].SetActive(true);
            hours[1].SetActive(false);
            hours[0].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 3)
        {
            hour = 4; hours[3].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[0].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 4)
        {
            hour = 5; hours[4].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[0].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 5)
        {
            hour = 6; hours[5].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[0].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 6)
        {
            hour = 7; hours[6].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[0].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 7)
        {
            hour = 8; hours[7].SetActive(true);
            hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[0].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 8)
        {
            hour = 9; hours[8].SetActive(true); hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[0].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);
        }
        if (val == 9)
        {
            hour = 10; hours[9].SetActive(true); hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[0].SetActive(false);
            hours[10].SetActive(false);
            hours[11].SetActive(false);

        }
        if (val == 10)
        {
            hour = 11; hours[10].SetActive(true); hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[0].SetActive(false);
            hours[11].SetActive(false);

        }
        if (val == 11)
        {
            hour = 12; hours[11].SetActive(true); hours[1].SetActive(false);
            hours[2].SetActive(false);
            hours[3].SetActive(false);
            hours[4].SetActive(false);
            hours[5].SetActive(false);
            hours[6].SetActive(false);
            hours[7].SetActive(false);
            hours[8].SetActive(false);
            hours[9].SetActive(false);
            hours[10].SetActive(false);
            hours[0].SetActive(false);
        }
        lasthor = val;
    }
    public void DataMins(int val)
    {
        if (val == 0)
        {
            minu = 1; minuts[0].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 1)
        {
            minu = 2; minuts[1].SetActive(true); 
            minuts[0].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 2)
        {
            minu = 3; minuts[2].SetActive(true);
            minuts[1].SetActive(false);
            minuts[0].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 3)
        {
            minu = 4; minuts[3].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[0].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 4)
        {
            minu = 5; minuts[4].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[0].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 5)
        {
            minu = 6; minuts[5].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[0].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 6)
        {
            minu = 7; minuts[6].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[0].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 7)
        {
            minu = 8; minuts[7].SetActive(true);
            minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[0].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 8)
        {
            minu = 9; minuts[8].SetActive(true); minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[0].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);
        }
        if (val == 9)
        {
            minu = 10; minuts[9].SetActive(true); minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[0].SetActive(false);
            minuts[10].SetActive(false);
            minuts[11].SetActive(false);

        }
        if (val == 10)
        {
            minu = 11; minuts[10].SetActive(true); minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[0].SetActive(false);
            minuts[11].SetActive(false);

        }
        if (val == 11)
        {
            minu = 12; minuts[11].SetActive(true); minuts[1].SetActive(false);
            minuts[2].SetActive(false);
            minuts[3].SetActive(false);
            minuts[4].SetActive(false);
            minuts[5].SetActive(false);
            minuts[6].SetActive(false);
            minuts[7].SetActive(false);
            minuts[8].SetActive(false);
            minuts[9].SetActive(false);
            minuts[10].SetActive(false);
            minuts[0].SetActive(false);
        }
        lastmin = val;
    }
    void Update()
    {
        if ((hour == Convert.ToInt32(forhour.text)) && (minu == Convert.ToInt32(formin.text)))
        {
            WIN.text = "YOU WIN";
        }
        else WIN.text = "";
    }
}
