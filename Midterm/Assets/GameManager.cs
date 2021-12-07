using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float startTimeValue = 10;
    public float timeValue;
    public TextMeshProUGUI timeRemaining;
    public TextMeshProUGUI redHanded;
    public Image redImage;
    public TextMeshProUGUI levelCompletedText;
    public Image levelCompletedImg;
    public AudioSource RedHand;
    public bool hasSoundPlayed = false;
    // Audio File citation: https://mixkit.co/free-sound-effects/buzzer/
    // Start is called before the first frame update
    void Start()
    {
        NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        RedHandedTimer();
        LevelCompleted();
    }

    void LevelCompleted()
    {
        if (transform.childCount == 0 && !(redImage.IsActive()))
        {
            levelCompletedText.gameObject.SetActive(true);
            levelCompletedImg.gameObject.SetActive(true);

            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(1);
                LoadingScene();
                LoadingScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level2"));
                NewLevel();
            }
        }
    }

    void NewLevel()
    {
        levelCompletedText.gameObject.SetActive(false);
        levelCompletedImg.gameObject.SetActive(false);
        redImage.gameObject.SetActive(false);
        redHanded.gameObject.SetActive(false);
    }

    void RedHandedTimer()
    {
        if (startTimeValue > 0)
        {
            startTimeValue -= Time.deltaTime;
            timeValue = Mathf.Round(startTimeValue);
            timeRemaining.SetText(timeValue + "s");
        }
        else if (startTimeValue <= 0 && !(levelCompletedImg.IsActive()))
        {
            redImage.gameObject.SetActive(true);
            redHanded.gameObject.SetActive(true);
            PlaySound();
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(0);
                LoadingScene();
                LoadingScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
                NewLevel();
                hasSoundPlayed = false;
            }
        }
    }

    // Delaying setting active scene so scene can load fully
    private IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(3);
    }

    void PlaySound()
    {
        if (!hasSoundPlayed) 
        {
            RedHand.Play();
            hasSoundPlayed = true;
        }
    }

}
