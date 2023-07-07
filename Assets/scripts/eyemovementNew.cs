using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class eyemovementNew : MonoBehaviour
{

    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private Vector2 lastScale;
    [SerializeField] private float Sacleuptime;
    [SerializeField] private GameObject rawImage_V_Player;
    [SerializeField] private AudioClip welcomeClip;
    [SerializeField] private float welcomeclip_Time;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        if(Input.GetMouseButtonDown(0))
        {
            // Invoke("eyeScaleUp" , Sacleuptime);
            eyeScaleUp();
        }
    }

    private void eyeScaleUp()
    {
        leftEye.transform.DOScale(lastScale, Sacleuptime);
        rightEye.transform.DOScale(lastScale, Sacleuptime);
      //  v_playerDesable();
        Invoke("v_playerDesable", Sacleuptime);
    }

    private void v_playerDesable()
    {
        rawImage_V_Player.SetActive(false);
        audioSource.clip = welcomeClip;
        audioSource.Play();
        Invoke("backToEyeZeroScale", welcomeclip_Time);

    }
}
