using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.IO.Ports;


public class eyemovementNew : MonoBehaviour
{
   

    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private Vector2 lastScale;
    [SerializeField] private float Sacleuptime;
    [SerializeField] private GameObject rawImage_V_Player;
    [SerializeField] private AudioClip welcomeClip;
    [SerializeField] private AudioClip secondAudioClip;
    [SerializeField] private float welcomeclip_Time;
    [SerializeField] private float alphaValue;
    [SerializeField] private RenderTexture video1;
    [SerializeField] private RenderTexture video2;
    [SerializeField] private float secondVideowaitTime;
    [SerializeField] private float secondVideoTime;
    [SerializeField] private SensorData _sensorData;
    [SerializeField] private double dis=15;
  

    private AudioSource audioSource;
    private bool isPrseed = false;
    private bool isLonagWait = false;   
    RawImage v_player_rawImage;
    private float timer;
    private float timer_0;



    bool mouseInput;
    bool longMouseInput;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
         v_player_rawImage = rawImage_V_Player.GetComponent<RawImage>();

    }
    void Start()
    {
      // _sensorData.distance=15;
        backToEyeZeroScale();
    }

    private void backToEyeZeroScale()
    {
        leftEye.transform.DOScale(Vector2.one, Sacleuptime);
        rightEye.transform.DOScale(Vector2.one,Sacleuptime);
    }

    float time = 0;
    void Update()
    {


        if(_sensorData.distance> 0 && _sensorData.distance<130)
        {
            
            time += Time.deltaTime;
            if (time<3)
            {
                Debug.Log("Least50");
                 
                mouseInput = true;
               
            }
            else
            {
                mouseInput = false;
            }

        }
        else
        {
            mouseInput = false;
        }

        

        if (time>10 && _sensorData.distance > 0)
        {
            if (time > 35)
            {
                time = 0;
                Debug.Log("Timecall");
            }
           
           
            longMouseInput = true;
            Debug.Log("wrgeg");
        }
        else
        {
            longMouseInput = false;
        }


        if (mouseInput && !isPrseed)//can convert mousee click
        {
            isPrseed = true;
            Debug.Log("aaaaaaaaaaaaaaaaa");
            rawImage_V_Player.SetActive(false);
            eyeScaleUp();
        }
        if (longMouseInput && !isLonagWait)//can convert mouse click--> get mousebotton 0
        {
            isLonagWait = true;
        }
        else
        {
            isLonagWait = false;
        }

        if (isLonagWait)
        {
            if( audioSource.clip == secondAudioClip)
            {
                isLonagWait= false;
            }
            timer += Time.deltaTime;
            if (timer >= secondVideowaitTime && isLonagWait)
            {
               timer = 0;
              
                v_player_rawImage.texture = video2;
                audioSource.clip = secondAudioClip;
                audioSource.Play();
                Invoke("BackVideo1", secondVideoTime);
                Debug.Log("30s");
            }
        }


    }
    private void BackVideo1()
    {
       
        v_player_rawImage.texture=video1;//raw image texture equle video1
        Debug.Log("second voice stop");
        audioSource.Stop();
        time = 0;
    }

    private void eyeScaleUp()
    {
        leftEye.transform.DOScale(lastScale, Sacleuptime);
        rightEye.transform.DOScale(lastScale, Sacleuptime);
     
        Invoke("Audioplayer", Sacleuptime);
    }

    private void Audioplayer()
    {

        audioSource.clip = welcomeClip;
        audioSource.Play();
        isLonagWait=false;
        Invoke("backToEyeZeroScale", welcomeclip_Time);
        Invoke("PreseedTrue", welcomeclip_Time);
    }

    private void PreseedTrue()
    {
        rawImage_V_Player.SetActive(true);
       isPrseed=false;
    }


}
