using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] Text cmdText;
    public int MetabaguCount{ get; set; } = 0;

    void Update()
    {
        DisplayWindow();
        UpdateText();
    }

    void DisplayWindow()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            window.SetActive(!window.activeSelf);
        }
    }

    void UpdateText()
    {
        cmdText.text = "メタバグ：" + MetabaguCount + "メタ";
    }
}
