using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickDifficulty : MonoBehaviour
{
    private TMP_Text difficultyText;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        difficultyText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.difficulty)
        {
            case "Easy":

                for (int i = 0; i < GameManager.instance.musicInformation["Title"].Count; i++)
                {
                    if (GameManager.instance.musicInformation["Title"][i] == GameManager.instance.title)
                    {
                        difficultyText.text = "Easy LV" + GameManager.instance.musicInformation["Easy"][i];
                        scoreText.text = string.Format("{0:F2} %", float.Parse(GameManager.instance.musicInformation["EasyBestScore"][i]));
                    }
                }

                break;

            case "Normal":

                for (int i = 0; i < GameManager.instance.musicInformation["Title"].Count; i++)
                {
                    if (GameManager.instance.musicInformation["Title"][i] == GameManager.instance.title)
                    {
                        difficultyText.text = "Normal LV" + GameManager.instance.musicInformation["Normal"][i];
                        scoreText.text = string.Format("{0:F2} %", float.Parse(GameManager.instance.musicInformation["NormalBestScore"][i]));
                    }
                }

                break;

            case "Hard":

                for (int i = 0; i < GameManager.instance.musicInformation["Title"].Count; i++)
                {
                    if (GameManager.instance.musicInformation["Title"][i] == GameManager.instance.title)
                    {
                        difficultyText.text = "Hard LV" + GameManager.instance.musicInformation["Hard"][i];
                        scoreText.text = string.Format("{0:F2} %", float.Parse(GameManager.instance.musicInformation["HardBestScore"][i]));
                    }
                }

                break;
        }
    }
}
