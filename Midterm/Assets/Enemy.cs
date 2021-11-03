using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public TextMeshProUGUI levelCompletedText;
    public Image levelCompletedImg;

    void Start()
    {
        levelCompletedText.gameObject.SetActive(false);
        levelCompletedImg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Enemy") == null) && (GameObject.Find("Enemy1") == null) && (GameObject.Find("Enemy2") == null))
        {
            levelCompletedText.gameObject.SetActive(true);
            levelCompletedImg.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }


}
