//Developed by Diego Salamanca
//Tel +57 350 823 2690
//Email: Diegocolmayor@gmail.com
//Bogota, Colombia 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PokemonManager : MonoBehaviour
{
    public InputField pokemonName;
    string apiPokemonUrl = "https://pokeapi.co/api/v2/pokemon/";

    public Text idText, typesText, nameText;

    public RawImage pokemonImage;


   public void GetPokemonInfo()
   {
        if(string.IsNullOrEmpty(pokemonName.text))
        {
            pokemonName.text = "bulbasaur";
        }

        pokemonName.text = pokemonName.text.ToLower();

        StartCoroutine(Network_Manager.GetJson(apiPokemonUrl+pokemonName.text, SetData));
   }

   public void SetData(string jsonRepsonse)
   {

        print(jsonRepsonse);

        var objectData = JsonUtility.FromJson<PokemonData>(jsonRepsonse);

        idText.text = "Pokedex #";
        typesText.text = "Type:";

        idText.text +=" "+ objectData.id.ToString();

        nameText.text = objectData.name;

        print(objectData.sprites.front_default);

        StartCoroutine(Network_Manager.GetTextureData(objectData.sprites.front_default, SetTexture));

        foreach (var item in objectData.types)
        {
           print(item.slot.ToString());
           print(item.type.name);           
           typesText.text += " "+ item.type.name +" ";              
           
            
        }
   }

   public void SetTexture(Texture texture)
    {
        pokemonImage.texture = texture;
    }
}

[Serializable]
public class PokemonData
{
    public int id;      

    public PokemonTypes[] types;

    public Sprites sprites;

    public string name;
}

[Serializable]
public class PokemonTypes
{    
   public PokemonType type;
   public int slot;
}

[Serializable]
public class PokemonType
{    
    public string name;
    public string url;
}

[Serializable]
public class Sprites
{    
    public string front_default;
}

