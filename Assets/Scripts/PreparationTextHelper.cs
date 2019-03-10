using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationTextHelper : MonoBehaviour
{
    [SerializeField] private AudioSource[] audios = new AudioSource[2];

    private void Start()
    {
        //startBeep = GetComponent<AudioSource>()
    }
    /*
        audios[0] -> StartSetBeepSound
        audios[1] -> GoBeepSound
    */
    public void playStartBeep()
    {
        audios[0].Play();
    }

    public void playGoBeep()
    {
        audios[1].Play();
    }
}
