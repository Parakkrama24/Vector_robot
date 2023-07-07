using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class eyemovementNew : MonoBehaviour
{

    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;
    [SerializeField] private float lastScale;
    [SerializeField] private float Sacleuptime;
    void Start()
    {
       leftEye.transform.localScale = Vector3.one;
        rightEye.transform.localScale = Vector3.one;    
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            eyeScaleUp();
        }
    }

    private void eyeScaleUp()
    {
        leftEye.transform.DOScale(lastScale, Sacleuptime);
    }
}
