using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class eyemovementNew : MonoBehaviour
{

    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private Vector2 lastScale;
    [SerializeField] private float Sacleuptime;
    [SerializeField] private GameObject rawImage_V_Player;
    [SerializeField] private AudioClip welcomeClip;
    [SerializeField] private float welcomeclip_Time;
    [SerializeField] private float alphaValue;
    [SerializeField] private RenderTexture video1;
    [SerializeField] private RenderTexture video2;
    [SerializeField] private float secondVideowaitTime;
    [SerializeField] private float secondVideoTime;

    private AudioSource audioSource;
    private bool isPrseed = false;
    private bool isLonagWait = false;   
    RawImage v_player_rawImage;
    private float timer;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
         v_player_rawImage = rawImage_V_Player.GetComponent<RawImage>();
    }
    void Start()
    {
        backToEyeZeroScale();
    }

    private void backToEyeZeroScale()
    {
        leftEye.transform.DOScale(Vector2.zero, Sacleuptime);
        rightEye.transform.DOScale(Vector2.zero,Sacleuptime);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isPrseed)
        {
           isPrseed = true;
            rawImage_V_Player.SetActive(false);
            eyeScaleUp();
        }
        if (Input.GetMouseButton(0))
        {
            isLonagWait = true;
        }
        else
        {
            isLonagWait = false;
        }

        if(isLonagWait)
        {
            timer += Time.deltaTime;
            if(timer>= secondVideowaitTime && isLonagWait)
            {
                isLonagWait = false;
                v_player_rawImage.texture = video2;
               // Invoke("BackVideo1", secondVideoTime);
                Debug.Log("30s");
            }
        }
        
        
    }
    /*private void BackVideo1()
    {
        v_player_rawImage.texture=video1;//raw image texture equle video1
    }*/

    private void eyeScaleUp()
    {
        leftEye.transform.DOScale(lastScale, Sacleuptime);
        rightEye.transform.DOScale(lastScale, Sacleuptime);
      //  v_playerDesable();
        Invoke("v_playerDesable", Sacleuptime);
    }

    private void v_playerDesable()
    {
      //  rawImage_V_Player.SetActive(false);
       // change_RawImage_alphavaluve();
        audioSource.clip = welcomeClip;
        audioSource.Play();
        Invoke("backToEyeZeroScale", welcomeclip_Time);
        Invoke("PreseedTrue", welcomeclip_Time);
    }

    private void change_RawImage_alphavaluve()
    {
        Color newColor = v_player_rawImage.color;
        newColor.a = alphaValue;
        v_player_rawImage.color = newColor;
    }

    private void PreseedTrue()
    {
        rawImage_V_Player.SetActive(true);
        isPrseed=false;
    }

    /*IEnumerator secondDisplay()
    {
        yield return new WaitForSeconds(30);
        isLonagWait = true;
    }*/
}
