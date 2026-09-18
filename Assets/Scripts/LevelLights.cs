using System;
using UnityEngine;

public class LevelLights : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private bool PLeftPass=false;
    private bool PRightPass=false;


    [Header("Light Objects")]
    [SerializeField] private SpriteRenderer leftLight;
    [SerializeField] private SpriteRenderer rightLight;


    [Header("Door Objects")]
    [SerializeField] private Door doorLeft;
    [SerializeField] private Door doorRight;


    public void Pass()
    {
        if (doorLeft.GetUnlockStatus())
        {
            PLeftPass=true;
            leftLight.color=Color.green;
        }
        else
        {
            PLeftPass=false; 
            leftLight.color=Color.red;
        }
        if (doorRight.GetUnlockStatus())
        {
            PRightPass=true;
            rightLight.color=Color.green;
        }
        else
        {
            PRightPass=false;
            leftLight.color=Color.red;
        }
        
    }
}