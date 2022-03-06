using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    [SerializeField]
    GameObject kazandiPanel, kayipettiPanel;
    public void kazandiPanelGoster()
    {
        kazandiPanel.SetActive(true);
    }
    public void kayipettiPanelGoster()
    {
        kayipettiPanel.SetActive(true);
    }
    public void devamEtbtn()
    {
        int simdikilvl = PlayerPrefs.GetInt("level");
        simdikilvl++;
        PlayerPrefs.SetInt("level", simdikilvl);
        SceneManager.LoadScene(0);


    }
    public void tekrarEtbtn()
    {
        
        SceneManager.LoadScene(0);


    }




}
