using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli,sonucPaneli;
    
    [SerializeField]
    private GameObject puaniKapYazisi,buyukOlanSayiyiySec;
    [SerializeField]
    private GameObject ustDikdortgen,altDikdortgen;
    [SerializeField]
    private Text ustText,altText,puanText;

    DairelerManager dairelerManager;
    SonucManager sonucManager;
    TrueFalseManager trueFalseManager;
    TimerManager timerManager;

    int oyunsayac,kacinciOyun;

    int ustDeger,altDeger;
    int buyukDeger;
    int butonDegeri;
    int toplamPuan,artisPuani;
    int dogruAdet,yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi,dogruSesi,yanlisSesi,bitisSesi;

    private void Awake()
    {
        timerManager=Object.FindObjectOfType<TimerManager>();
        dairelerManager=Object.FindObjectOfType<DairelerManager>();
        trueFalseManager=Object.FindObjectOfType<TrueFalseManager>();
        
        audioSource=GetComponent<AudioSource>();
    }


    void Start()
    {
        kacinciOyun=0;
        oyunsayac=0;
        toplamPuan=0;


        ustText.text="Ali";
        altText.text="ATALAY";
        puanText.text="0";
        SahneEkraniniGuncelle();
    }


    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1,1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1,1f);
        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
        
    }
    public void OyunaBasla()
    {
        audioSource.PlayOneShot(baslangicSesi);

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0,1f);

        buyukOlanSayiyiySec.GetComponent<CanvasGroup>().DOFade(1,1f);


        KacinciOyun();
        

        timerManager.SureyiBaslat();
    }
    void KacinciOyun()
    {
        if(oyunsayac<5)
        {
            kacinciOyun=1;
            artisPuani=25;
        }
        else if(oyunsayac>=5 && oyunsayac<10)
        {
            kacinciOyun=2;
            artisPuani=50;
        }
        else if(oyunsayac>=10 && oyunsayac<15)
        {
            kacinciOyun=3;
            artisPuani=75;
        }
         else if(oyunsayac>=15 && oyunsayac<20)
        {
            kacinciOyun=4;
            artisPuani=100;
        }
        else if(oyunsayac>=20 && oyunsayac<25)
        {
            kacinciOyun=5;
            artisPuani=125;
        }
        else
        {
            kacinciOyun=Random.Range(1,6);
            artisPuani=150;
        }
        switch (kacinciOyun)
        {
            case 1 :
                BirinciFonksiyon();
                break;
            case 2 :
                İkinciFonksiyon();
                break;
            case 3 :
                UcuncuFonksiyon();
                break;
            case 4 :
                DorduncuFonksiyon();
                break;
            case 5 :
                BesinciFonksiyon();
                break;
                
        }

    }
    void BirinciFonksiyon()
    {
        int rastgeleDeger=Random.Range(1,50);

        if(rastgeleDeger<=25)
        {
            ustDeger=Random.Range(2,50);
            altDeger=ustDeger+Random.Range(1,15);
        }
        else
        {
            ustDeger=Random.Range(2,50);
            altDeger=Mathf.Abs(ustDeger-Random.Range(1,15));   
        }

        if(ustDeger>altDeger)
        {
            buyukDeger=ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }
        else if(ustDeger==altDeger)
        {
            BirinciFonksiyon();
            return;
        }
        ustText.text=ustDeger.ToString();
        altText.text=altDeger.ToString();
       
    }
    
    void İkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1,10);
        int ikinciSayi = Random.Range(1,20);
        int ucuncuSayi = Random.Range(1,10);
        int dorduncuSayi =Random.Range(1,20);
        ustDeger=birinciSayi+ikinciSayi;
        altDeger=ucuncuSayi+dorduncuSayi;

        if(ustDeger>altDeger)
        {
            buyukDeger=ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }
        if(ustDeger==altDeger)
        {
            İkinciFonksiyon();
            return;
        }
        ustText.text = birinciSayi + " + " + ikinciSayi;
        altText.text = ucuncuSayi + " + " + dorduncuSayi;

    }
    
    void UcuncuFonksiyon()
    {
         int birinciSayi = Random.Range(11,30);
        int ikinciSayi = Random.Range(1,11);
        int ucuncuSayi = Random.Range(11,40);
        int dorduncuSayi =Random.Range(1,11);
        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if(ustDeger>altDeger)
        {
            buyukDeger=ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }
        if(ustDeger==altDeger)
        {
            UcuncuFonksiyon();
            return;
        }
        ustText.text = birinciSayi + " - " + ikinciSayi;
        altText.text = ucuncuSayi + " - " + dorduncuSayi;
    }
    
    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1,10);
        int ikinciSayi = Random.Range(1,10);
        int ucuncuSayi = Random.Range(1,10);
        int dorduncuSayi =Random.Range(1,10);
        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if(ustDeger>altDeger)
        {
            buyukDeger=ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }
        if(ustDeger==altDeger)
        {
            DorduncuFonksiyon();
            return;
        }
        ustText.text = birinciSayi + " * " + ikinciSayi;
        altText.text = ucuncuSayi + " * " + dorduncuSayi;
    }
    
    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2,10);
        ustDeger = Random.Range(2,10);
        int bolunen1 = bolen1*ustDeger;

        int bolen2 = Random.Range(2,10);
        altDeger = Random.Range(2,10);
        int bolunen2 = bolen2*altDeger;

         if(ustDeger>altDeger)
        {
            buyukDeger=ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger=altDeger;
        }
        if(ustDeger==altDeger)
        {
            BesinciFonksiyon();
            return;
        }
        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;



        
    }
    public void ButonDegeriniBelirle(string butonAdi)
    {
        if(butonAdi=="ustButon")
        {
            butonDegeri=ustDeger;
        }
        else if(butonAdi=="altButon")
        {
            butonDegeri=altDeger;
        }
       if(butonDegeri==buyukDeger)
       { 
           trueFalseManager.TrueFalseScaleAc(true);
           dairelerManager.DairelerinScaleAc(oyunsayac%5);
           oyunsayac++;
           toplamPuan+=artisPuani;
           puanText.text=toplamPuan.ToString();

           dogruAdet++;

           audioSource.PlayOneShot(dogruSesi);
           KacinciOyun();
       }
       else
       {
          trueFalseManager.TrueFalseScaleAc(false);
          HatayaGoreSayaciAzalt();

          yanlisAdet++;

          audioSource.PlayOneShot(yanlisSesi);
          KacinciOyun();
       }
    }
    void HatayaGoreSayaciAzalt()
    {
        oyunsayac-=(oyunsayac%5+5);

        if(oyunsayac<0)
        {
            oyunsayac=0;
        }
        dairelerManager.DairelerinScaleKapat();
    }

    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }
    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);
        sonucPaneli.SetActive(true);
        sonucManager=Object.FindObjectOfType<SonucManager>();

        sonucManager.SonuclariGoster(dogruAdet,yanlisAdet,toplamPuan);
    }
        
}
    


