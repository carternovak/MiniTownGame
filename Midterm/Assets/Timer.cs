using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTimeValue = 10;
    public float timeValue;
    public TextMeshProUGUI timeRemaining;
    public TextMeshProUGUI redHanded;
    public Image redImage;
    void Awake()
    {
        redImage.gameObject.SetActive(false);
        redHanded.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (startTimeValue > 0)
        {
            startTimeValue -= Time.deltaTime;
            timeValue = Mathf.Round(startTimeValue);
            timeRemaining.SetText(timeValue + "s");
        }
        else
        {
            redImage.gameObject.SetActive(true);
            redHanded.gameObject.SetActive(true);
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("SampleScene");
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            }
        }
            
    }

}
