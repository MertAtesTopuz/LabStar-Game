using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Controller : MonoBehaviour
{
    int saniye = 50;
    int para = 0;
    int hedef_para = 500;

    public GameObject kaybettin_pnl;
    public GameObject durdur_pnl;
    public GameObject sonraki_level_pnl;

    public TMPro.TextMeshProUGUI saniye_txt;
    public TMPro.TextMeshProUGUI para_txt;
    public TMPro.TextMeshProUGUI hedef_para_txt;

    void Start()
    {
        int simdiki_level = SceneManager.GetActiveScene().buildIndex;

        hedef_para = (simdiki_level * 200) + 100;

        saniye_txt.text ="saniy: " +saniye.ToString();
        para_txt.text ="para: "+ para.ToString();
        hedef_para_txt.text ="hedef para: "+ hedef_para.ToString();

        InvokeRepeating("saniye_azalt", 0.0f, 1.0f);
    }

    public void para_arttir(int deger)
    {
        para += deger;
        para_txt.text = "para: " + para.ToString();

        if (para>= hedef_para)
        {
            sonraki_levele_gec();
        }
    }

    void sonraki_levele_gec()
    {
        sonraki_level_pnl.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void sonraki_level_btn()
    {
        int simdiki_level_no = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(simdiki_level_no);
    }

    void saniye_azalt()
    {
        saniye--;

        saniye_txt.text ="saniye: "+ saniye.ToString();

        if (saniye <= 0)
        {
            kaybettin();
        }
    }

    public void tekrar_oyna_btn()
    {
        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void kaybettin()
    {
        kaybettin_pnl.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void cikis()
    {
        Application.Quit();
    }
    public void devam_et_btn()
    {

        Time.timeScale = 1.0f;
        durdur_pnl.SetActive(false);
    }
    public void durdur_btn()
    {

        Time.timeScale = 0.0f;
        durdur_pnl.SetActive(true);
    }
}
