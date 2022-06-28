//Developed by Diego Salamanca
//Tel +57 350 823 2690
//Email: Diegocolmayor@gmail.com
//Bogota, Colombia 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Network_Manager : MonoBehaviour
{   

    public static IEnumerator GetTextureData(string url, Slider slider, Action<Texture> CallBack)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            var request = www.SendWebRequest(); 
        
            while(!request.isDone)
            {               
                slider.value =  www.downloadProgress*100;
                yield return null;
            }   

            
            if(www.result == UnityWebRequest.Result.ConnectionError)
            {
                print(www.result);
            }
            else
            {
                Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                CallBack(myTexture);
            }
           
        }
        
        

    }
}
