using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{   
    public string lvlName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("TotalScore", GameController.instance.totalScore);
            SceneManager.LoadScene(lvlName);
        }
    }


    // Update is called once per frame
}
