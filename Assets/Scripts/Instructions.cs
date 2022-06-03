using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] int TextDelay =3;
    [SerializeField] List<GameObject> InfoTexts;
    private void Awake()
    {
        
            StartCoroutine(ActivateText(InfoTexts));
          
        
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
}
