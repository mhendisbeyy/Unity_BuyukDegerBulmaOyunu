using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    int kalanSure;
    bool sureSaysinmi=true;
    GameManager gameManager;

    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        kalanSure=90;
        sureSaysinmi=true;
        
    }
    public void SureyiBaslat()
    {
        StartCoroutine(SuretimerRoutine());
    }
    IEnumerator SuretimerRoutine()
    {
        while(sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);
            
            if(kalanSure<10)
            {
                sureText.text="0" +kalanSure;
            }
            else 
            {
                sureText.text=kalanSure.ToString();
            }
            if(kalanSure<=0)
            {
                sureSaysinmi=false;
                sureText.text="";
                gameManager.OyunuBitir();
            }
            
            kalanSure--;
        }
    }

}
