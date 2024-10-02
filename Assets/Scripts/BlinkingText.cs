using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] float blinkingSpeed = 1f;
    [SerializeField] GameObject newRecordPanel;

    void Start()
    {
       StartCoroutine(BlinkText(blinkingSpeed));
    }
    
    private IEnumerator BlinkText(float speed)
    {
        while (true)
        {
            if (newRecordPanel.activeInHierarchy)
            {
                newRecordPanel.SetActive(false);
            }
            else
            {
                newRecordPanel.SetActive(true);
            }
            yield return new WaitForSeconds(speed);
        }
    }


}





