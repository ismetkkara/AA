using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class yonetici : MonoBehaviour
{
    public GameObject topRrefab;
    int toplamTopSayisi;
    List<Rigidbody2D> tumToplar = new List<Rigidbody2D>();
    float hiz = 40f;
    float ilkToplunYPozisyonu = -3f;
    [SerializeField]
    TextMeshProUGUI levelText;
    int level;
    Ui Ui;
    void Start()
    {
       Ui= GameObject.FindObjectOfType<Ui>();
        levelKontrol();
        ilkToplariEkle();
    }
    void levelKontrol()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }
        levelText.text = level.ToString();
    }
    void ilkToplariEkle()
    {
        toplamTopSayisi = level * 3;
        for (int i = 0; i < toplamTopSayisi; i++)
        {
            GameObject yeniTop = Instantiate(topRrefab);
            if (i == 0)
            {
                yeniTop.transform.position = new Vector2(0, ilkToplunYPozisyonu);
            }
            else
            {
                yeniTop.transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }
            yeniTop.GetComponentInChildren<TextMeshProUGUI>().text = (toplamTopSayisi - i).ToString();
            tumToplar.Add(yeniTop.GetComponent<Rigidbody2D>());
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && tumToplar.Count > 0)
        {
            tumToplar[0].velocity = Vector2.up * hiz;
            tumToplar.RemoveAt(0);
           // toplarinPozisyonlariGuncelle();

        }
        else if (tumToplar.Count <= 0)
        {
            kazandin();
        }
    }
    public void toplarinPozisyonlariGuncelle()
    {
        for (int i = 0; i < tumToplar.Count; i++)
        {


            if (i == 0)
            {
                tumToplar[i].transform.position = new Vector2(0, ilkToplunYPozisyonu);
            }
            else
            {
                tumToplar[i].transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }


        }



    }
   public void kazandin()
    {
       Ui.kazandiPanelGoster();
        this.enabled = false;
    }
    public void kayipettin()
    {
       Ui.kayipettiPanelGoster();
        this.enabled = false;
    }
}
