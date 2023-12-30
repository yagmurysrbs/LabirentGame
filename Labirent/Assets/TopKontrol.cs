using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour


{
    private Rigidbody rb;
    public float Hiz = 1.8f;
    public Text zaman, can,durum;
    float canSayaci = 20;
    float zamanSayaci = 500;
    bool oyunDevam = true;
    bool oyuntamam = false;
    public Button btn;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
 

    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyuntamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyuntamam)
        {
           
            btn.gameObject.SetActive(true);

            durum.text = "Oyun tamamlanamadý!!!";
            btn.gameObject.SetActive(true);


        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
            btn.gameObject.SetActive(true);


            durum.text = "Oyun tamamlanamadý111";
        }

    }
    private void FixedUpdate()
    {
        if (oyunDevam && !oyuntamam)
        {
            //float yatay = Input.GetAxis("Horizontal");
            //float dikey = Input.GetAxis("Vertical");
            //Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            //rb.AddForce(kuvvet * Hiz);
            Vector3 farePozisyonu = Input.mousePosition;
            farePozisyonu.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 fareYon = (Camera.main.ScreenToWorldPoint(farePozisyonu) - transform.position).normalized;

            // Fare ile hareket
            rb.AddForce(fareYon * Hiz, ForceMode.Force);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            btn.gameObject.SetActive(true);
            




        }
    }
    private void OnCollisionEnter(Collision other)

    {
        string objIsmi = other.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            print("Oyunu Kazandýnýz");
            oyuntamam = true;
            btn.gameObject.SetActive(true);
            durum.text = "Oyunu Kazandýnýzz,Tebriklerr!";



        }
        else if (!objIsmi.Equals("zemin") &&  !objIsmi.Equals("basla") && !objIsmi.Equals("bitis") )
        {

            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
            {

                oyunDevam = false;
                btn.gameObject.SetActive(true);
                durum.text = "Oyun tamamlanamadý";


            }


        }

    }
}


