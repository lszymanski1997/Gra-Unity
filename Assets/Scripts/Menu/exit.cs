using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class exit : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
