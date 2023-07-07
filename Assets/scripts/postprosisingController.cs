using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class postprosisingController : MonoBehaviour
{
     private Volume _GlobleVolume;
    private Bloom _Bloom;
    private bool isPressed;



    public float amplitude = 1000f;     // The amplitude of the wave
    public float frequency = 12f;     // The frequency of the wave
    public float speed = 1f;         // The speed at which the wave moves
    public float yOffset = 0f;
    public int numberOfPoints = 100; // The number of points to generate
   // [SerializeField] private float scaterYOfset=0.5f;

    [SerializeField] private VolumeProfile _Profile;
    void Start()
    {
        _GlobleVolume = GetComponent<Volume>();
        _GlobleVolume.profile.TryGet(out _Bloom);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(updateintensity());
        }

    }

    IEnumerator updateintensity()
    {
        yield return new WaitForSeconds(1);
        //float x = (float)i / numberOfPoints;
        float z = Random.Range(0.3f, 0.7f); //Mathf.Sin((x * frequency + Time.time * speed) * 2f * Mathf.PI);
        float y = amplitude * z;
        // Debug.Log("Inrensity"+y);

        _Bloom.intensity.value = y;
        if (z < 0.7)
        {
            //Debug.Log("Scatter" + z);
            // z = z + scaterYOfset;
            Debug.Log("Scatter" + z);
            _Bloom.scatter.value = z;
        }
    }
}
