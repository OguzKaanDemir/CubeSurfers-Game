using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOver gameOver;

    public GameObject RestartPanel;

    Image image;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0, len;
    float t = 0f;

    void Start()
    {
        gameOver = gameOver.GetComponent<GameOver>();
        image = RestartPanel.GetComponent<Image>();
        len = myColors.Length;
    }

    void Update()
    {
        if (gameOver.isDied)
        {
            RestartPanel.SetActive(true);

            image.color = Color.Lerp(image.color, myColors[colorIndex], lerpTime);
            t = Mathf.Lerp(t, 1f, lerpTime);
            if (t > .9f)
            {
                t = 0f;
                colorIndex++;
                colorIndex = (colorIndex >= len) ? 0 : colorIndex;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }

       
    }
}
