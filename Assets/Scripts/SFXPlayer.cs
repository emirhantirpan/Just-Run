using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip Die;
    public AudioSource _as;
    public UI_Manager ui;
    
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (ui.health == 0)
        {
            _as.PlayOneShot(Die);
        }
    }
    
       
    
}
