//Developed by Diego Salamanca
//Tel +57 350 823 2690
//Email: Diegocolmayor@gmail.com
//Bogota, Colombia 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public RawImage rawImage;
    public Image image;
    public InputField inputField; 

     public Slider slider; 

    string deafultUrl = "https://unsplash.com/photos/WeSZSnnYojY/download?force=true";

    private void Start() {
        inputField.text = deafultUrl;
    }
    public void StartDowloadImagetexture()
    {
        StartCoroutine(Network_Manager.GetTextureData(inputField.text,slider,SetTexture));
    }

    public void StartDowloadImageSprite()
    {
        StartCoroutine(Network_Manager.GetTextureData(inputField.text,slider,SetSprite));
    }

    public void SetTexture(Texture texture)
    {
        rawImage.texture = texture;
    }

    public void SetSprite(Texture texture)
    {        
        image.sprite = SpriteFromTexture2D((Texture2D)texture);
    }

    Sprite SpriteFromTexture2D(Texture2D texture) 
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }   
   

    

}
