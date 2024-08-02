using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int testNumber
    {
        get => PlayerPrefs.GetInt("testNumber", 0);
        set => PlayerPrefs.SetInt("testNumber", value);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        //不限制帧数
        Application.targetFrameRate = -1;
        //关闭垂直同步
        QualitySettings.vSyncCount = 0;

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += (arg0, arg1) =>
        {
            var go = GameObject.Find("InputField");
            if (go != null)
            {
                var inputField = go.GetComponent<TMP_InputField>();
                if (testNumber == 0)
                {
                    testNumber = 3000;
                }
                inputField.text = testNumber.ToString();
                inputField.onEndEdit.AddListener(str =>
                {
                    if (int.TryParse(str, out var number))
                    {
                        testNumber = number;
                        PlayerPrefs.SetInt("testNumber", testNumber);
                        Debug.Log("testNumber: " + testNumber);
                    }else{
                        inputField.text = testNumber.ToString();
                    }

                });
            }
        };
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


}
