using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] 
    private Text _livestext;
    [SerializeField] 
    private Text _pearltext;

    //function to update text uis for lives and pearls
    public void UpdateLives(int health)
    {
        _livestext.text = "Lives: " + health;
    }

    public void UpdatePearl(int pearls)
    {
        _pearltext.text = "Pearls: " + pearls;
    }

}
