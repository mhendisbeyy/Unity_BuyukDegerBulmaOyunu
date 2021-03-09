using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObje;
    [SerializeField]
    private Text geriSayimText;

    GameManager gameManager;
     private AudioSource audioSource;
    [SerializeField]
    private AudioClip geriSayimSesi;

    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
        audioSource=GetComponent<AudioSource>();
    }
    
    void Start()
    {
        StartCoroutine(GeriSayimRoutine());
    }

    IEnumerator GeriSayimRoutine()
    {
        
        for(int i=3;i>=0;i--)
        {
        audioSource.PlayOneShot(geriSayimSesi);

        geriSayimText.text= i.ToString();

        yield return new WaitForSeconds(0.5f);

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        }
        
        StopAllCoroutines();
        gameManager.OyunaBasla();
        
    }
   
}
