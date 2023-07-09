using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Uimaneger : MonoBehaviour
{
    public TMP_InputField inputField;
    public string inputValue;

    private void Update()
    {
        // Add a listener to the input field's onEndEdit event
        inputField.onEndEdit.AddListener(OnInputEndEdit);
    }

    private void OnInputEndEdit(string value)
    {
        inputValue = value;
        Debug.Log("Input Value: " + inputValue);
        // Do something with the input value
    }
}
