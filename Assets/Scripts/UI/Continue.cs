using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        if (PlayerPrefs.GetInt("current_lvl") == 1)
        {
            yourButton.gameObject.SetActive(false);
        }
        else
        {
            yourButton.gameObject.SetActive(true);
        }
    }

    void TaskOnClick()
    {
        switch (PlayerPrefs.GetInt("current_lvl"))
        {
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
        }
    }
}
