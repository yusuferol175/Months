using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using GameObject = UnityEngine.GameObject;
using Image = UnityEngine.UI.Image;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;


public class buton_olay_sc : MonoBehaviour
{
    
    
    public GameObject dolap_kapi_sol;
    public GameObject dolap_kapi_sag;
    public GameObject months;
    public GameObject baslik_text;

    public TMP_Text aylar_text;
    public TMP_Text dogru_text;
    public GameObject sonuc;

    public void restart_but()
    {
        SceneManager.LoadScene("oyun_ekranı");
    }
    private void basla_late()
    {
        giysi.SetActive(true);
        can_bar.SetActive(true);
        dogru_bar.SetActive(true);
        sure_t.gameObject.SetActive(true);
        months.SetActive(true);
        aylar_text.gameObject.SetActive(true);
        oyun_basladi = true;
    }
    public void oyunbasla(Object sender )
    {
        ses.GetComponent<AudioSource>().PlayOneShot(dolap_ac_ses);
        baslik_text.SetActive(false);
        GameObject basla_buton = sender as GameObject;
        basla_buton.SetActive(false);
        dolap_kapi_sol.GetComponent<Animator>().SetBool("kapi",true);
        dolap_kapi_sag.GetComponent<Animator>().SetBool("kapi",true);
        Invoke("basla_late",1.3f);
    }

    private System.Random rnd = new System.Random();
    private List<int> benzersiz_sayilar = new List<int>();
    public List<int> benzersiz_aylar = new List<int>();
    public List<Sprite> aylar_resim = new List<Sprite>();
    public List<GameObject> aylar = new List<GameObject>();
    public List<Sprite> giysiler = new List<Sprite>();

    private int sayac = 0;
    public int ay_say = 0;
    private bool oyun_basladi = false;

    public Sprite dogru;
    public Sprite yanlis;
    public GameObject perde;

    public GameObject oyun_sonu_panel;
    
    public GameObject can_bar;

    public GameObject giysi;
    void Start()
    {
        giysi.SetActive(false);
        Time.timeScale = 1f;
        oyun_sonu_panel.SetActive(false);
        can_bar.SetActive(false);
        sonuc.SetActive(false);
        dogru_bar.SetActive(false);
        can = 3;
        perde.SetActive(false);
        sure_t.gameObject.SetActive(false);
        oyun_basladi = false;
        months.SetActive(false);
        aylar_text.gameObject.SetActive(false);
        while (benzersiz_sayilar.Count < 12)
        {
            int randomsayi = rnd.Next(0, 12);
            if (!benzersiz_sayilar.Contains(randomsayi))
            {   
                benzersiz_sayilar.Add(randomsayi);
                
            }
        }
        
        
        foreach (var sayi in benzersiz_sayilar)
        {
            aylar[sayac].GetComponent<Image>().sprite = aylar_resim[sayi];
            sayac++;
        }
        
        while (benzersiz_aylar.Count < 12)
        {
            int randomsayi_ay = rnd.Next(1, 13);
            if (!benzersiz_aylar.Contains(randomsayi_ay))
            {   
                benzersiz_aylar.Add(randomsayi_ay);
                
            }
        }

        aylar_text.GetComponent<TMP_Text>().text = benzersiz_aylar[0].ToString() + ".Months";
        dogru_text.GetComponent<TMP_Text>().text = dogru_sayi.ToString();

        giysi.GetComponent<Image>().sprite = giysiler[0];

    }

    private int giysi_say=0;
    private void tiklanan_late_yanlis()
    {
        if (can==0)
        {
            Invoke("game_over",1.1f);
            sonuc.SetActive(false);
            tiklanan.gameObject.GetComponent<Image>().sprite = tiklanan_sprite;
            perde.SetActive(false);
               
        }
        else
        {
            if (ay_say+2==benzersiz_aylar.Count)
            {
                ay_say = -1;
            }
            ay_say++;
            Debug.Log(ay_say);
            aylar_text.GetComponent<TMP_Text>().text = benzersiz_aylar[ay_say].ToString() + ".Months";
            
           
            
            sonuc.SetActive(false);
            tiklanan.gameObject.GetComponent<Image>().sprite = tiklanan_sprite;
            perde.SetActive(false);
            giysi_say++;
            if (giysi_say==12)
            {
                giysi_say = 0;
            }
            giysi.GetComponent<Image>().sprite = giysiler[giysi_say];
        }
        
    }
    private void tiklanan_late_dogru()
    {
        if (dogru_sayi==11)
        {
            dogru_sayi++;
            Invoke("bitis",1.1f);
            sonuc.SetActive(false);
            tiklanan.SetActive(false); 
            perde.SetActive(false);
        }
        else
        {
                
                
                
            benzersiz_aylar.Remove(benzersiz_aylar[ay_say]);
            if (benzersiz_aylar.Count==4)
            {
                ay_say = 0;
            }
            aylar_text.GetComponent<TMP_Text>().text = benzersiz_aylar[ay_say].ToString() + ".Months";
                
            dogru_sayi++;
                
            dogru_text.GetComponent<TMP_Text>().text = dogru_sayi.ToString();
                
            sonuc.SetActive(false);
            tiklanan.SetActive(false); 
            perde.SetActive(false);
            giysi_say++;
            if (giysi_say==12)
            {
                giysi_say = 0;
            }
            giysi.GetComponent<Image>().sprite = giysiler[giysi_say];
        }
        
    }
    private GameObject tiklanan;
    private Sprite tiklanan_sprite;
    private int dogru_sayi=0;
    private int can;
    public GameObject dogru_bar;

    public List<GameObject> kalpler = new List<GameObject>();

    public TMP_Text zaman_t;
    public TMP_Text skor_t;
    public TMP_Text bitis_t;

    public GameObject ses;
    public GameObject arka_ses;
    public AudioClip dolap_ac_ses;
    public AudioClip fail;
    public AudioClip success;
    public AudioClip wrong;
    public AudioClip correct;
    private void can_()
    {
        if (can==2)
        {
            kalpler[2].SetActive(false);
        }

        if (can == 1)
        {
            kalpler[2].SetActive(false);
            kalpler[1].SetActive(false);
        }
        if (can == 0)
        {
            kalpler[2].SetActive(false);
            kalpler[1].SetActive(false);
            kalpler[0].SetActive(false);
        }
    }

    private void bitis()
    {
        arka_ses.GetComponent<AudioSource>().Stop();
        ses.GetComponent<AudioSource>().PlayOneShot(success);
        Time.timeScale = 0f;
        oyun_sonu_panel.SetActive(true);
        bitis_t.GetComponent<TMP_Text>().text = "Game Successful";
        zaman_t.GetComponent<TMP_Text>().text = "Time = "+ dakika +":" + (int)saniye;
        skor_t.GetComponent<TMP_Text>().text = "Score = "+dogru_sayi.ToString();
        dogru_sayi++;
        dogru_text.GetComponent<TMP_Text>().text = dogru_sayi.ToString();
    }

    private void game_over()
    {
        ses.GetComponent<AudioSource>().PlayOneShot(fail);
        arka_ses.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0f;
        oyun_sonu_panel.SetActive(true);
        bitis_t.GetComponent<TMP_Text>().text = "Game Failed";
        zaman_t.GetComponent<TMP_Text>().text = "Time = "+ dakika +":" + (int)saniye;
        skor_t.GetComponent<TMP_Text>().text = "Score = "+dogru_sayi.ToString();
    }
    public void aylar_tikla(Object sender)
    {
        
        
        GameObject tiklanan_ay = sender as GameObject;
        
        
        if (tiklanan_ay.GetComponent<Image>().sprite.name==benzersiz_aylar[ay_say].ToString())
        {
            ses.GetComponent<AudioSource>().PlayOneShot(correct);
            Invoke("tiklanan_late_dogru",1f);
            tiklanan = tiklanan_ay;
            tiklanan_ay.gameObject.GetComponent<Image>().sprite = dogru;
            perde.SetActive(true);
            sonuc.SetActive(true);
            sonuc.GetComponent<Image>().sprite = dogru;
            

        }
        else
        {
            ses.GetComponent<AudioSource>().PlayOneShot(wrong);
            Handheld.Vibrate();
            can--;
            can_();
            perde.SetActive(true);
            sonuc.SetActive(true);
            sonuc.GetComponent<Image>().sprite = yanlis;
            tiklanan_sprite = tiklanan_ay.gameObject.GetComponent<Image>().sprite;
            tiklanan_ay.gameObject.GetComponent<Image>().sprite = yanlis;
            Invoke("tiklanan_late_yanlis",1f);
            tiklanan = tiklanan_ay;
            
            
            
        }

        
    }

    private float saniye;
    private int dakika;
    public TMP_Text sure_t;
    void Update()
    {
        
        if (oyun_basladi)
        {
            
            saniye += Time.deltaTime * 1;
            sure_t.GetComponent<TMP_Text>().text = dakika +":" + (int)saniye;
            if ((int)saniye==60)
            {
                dakika++;
                saniye = 0;
            }
        }
        
    }
}
