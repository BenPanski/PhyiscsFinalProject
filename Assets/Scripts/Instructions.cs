using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] int TextDelay =3;
    [SerializeField] List<GameObject> InfoTexts;
    [SerializeField] TMP_Text ScoreTxt;
    int Score;
    private void Awake()
    {
        
            StartCoroutine(ActivateText(InfoTexts));
          
        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    private IEnumerator ActivateText(List<GameObject> texts) 
    {
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].SetActive(true);
            yield return new WaitForSeconds(TextDelay);
            texts[i].SetActive(false);
            yield return new WaitForSeconds(TextDelay-1);

        }

      
    }

    public  void Goalllllllllll() 
    {
        Score++;
        ScoreTxt.text = "Score: "+Score.ToString();
    }
}
