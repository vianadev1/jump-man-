using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class autoguardado : MonoBehaviour
{
    public GameObject player;
    public Vector3 posicionplayer;
    float tiempo;
    public GameObject MENU;
    bool load = true;
    void Update()
    {
        posicionplayer = player.transform.position;


        tiempo +=Time.deltaTime;
        if (tiempo >= 5)
        {
            SaveManager.savepositiondata(this);
            Debug.Log("DATA GUARDADA");
            tiempo = 0; 
        }

        if (MENU.activeSelf == true  )
        {
            try
            {
                guardado Guardado = SaveManager.loadposition();
                player.transform.position = new Vector3(Guardado.positionn[0], Guardado.positionn[1], Guardado.positionn[2]);
                Debug.Log("cargado");
            }
            catch
            {
                SaveManager.savepositiondata(this);
                Debug.Log("DATA GUARDADA");
            }
            
        }


        if (MENU.activeSelf == false && load == true)
        {
            StartCoroutine(delay());
            player.SetActive(true);
            load = false;

        }

    }

    IEnumerator delay()
    {
        player.SetActive(true);
        yield return new WaitForSeconds(3);
        player.SetActive(false);
        
    }
}
