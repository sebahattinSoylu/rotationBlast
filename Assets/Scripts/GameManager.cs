
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    [SerializeField] private Color greenColor;
    

    [SerializeField] private Transform circleTransform;

   

    public int alinanPuan;

    private Vector3 startPos;

    public TMP_Text puanTxt;

  
    private void Awake()
    {
        instance = this;
        startPos = player.transform.position;
    }

    private void Start()
    {
        
        alinanPuan = 0;
        
       
        OyunuBaslat();
    }

    public void OyunuBaslat()
    {
        player.transform.position = startPos;
        player.GetComponent<PlayerController>().donsunmu = false;
        player.transform.rotation=Quaternion.identity;
       
       
        
        circleTransform.GetChild(0).name = "hedefCircle";
        DaireRengiDegistir(0);
    }

    public void Click()
    {
        
       player.GetComponent<PlayerController>().IleriFirlat();
        
    }


    public void RastgeleRenkDegistir()
    {
        int randomIndex=Random.Range(0, circleTransform.childCount);;
        
        
        DaireRengiDegistir(randomIndex);
    }


    public void DaireRengiDegistir(int hangiDaire)
    {
        
        
        
        foreach (Transform circle in circleTransform)
        {
           
            circle.GetComponent<BoxCollider2D>().isTrigger = true;
            circle.GetComponent<SpriteRenderer>().material.color = Color.white;
            circle.name = "circle";
        }
        
        circleTransform.GetChild(hangiDaire).GetComponent<BoxCollider2D>().isTrigger = false;
        circleTransform.GetChild(hangiDaire).GetComponent<SpriteRenderer>().material.color = greenColor;

        
        circleTransform.GetChild(hangiDaire).name = "hedefCircle";
        

    }

    public void PuaniArtir()
    {
        alinanPuan += 5;
        puanTxt.text = alinanPuan.ToString();
       

    }

    
}
