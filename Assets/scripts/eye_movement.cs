using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_movement : MonoBehaviour
{
    //[SerializeField] private GameObject _eyePrent;
    [SerializeField] private Vector3 _lastscale;
    [SerializeField] private float _scaleTime=0.3f;
   
    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
          gameObject.SetActive(true);
          changeScale();

        }*/
    }

    /*private void changeScale()
    {
        transform.DOScale(_lastscale, _scaleTime);
    }*/
}
