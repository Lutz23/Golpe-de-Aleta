using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        
        //**para guardar el nivel de musica del slider que le ha puesto el jugador
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(){
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20); //para que el slider de la musica puede moverse + rango
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume(){
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume)*20); //para que el slider de la musica puede moverse + rango
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
{
    
    musicSlider.value=PlayerPrefs.GetFloat("musicVolume");
    sfxSlider.value=PlayerPrefs.GetFloat("SFXVolume");
    SetMusicVolume();
    SetSFXVolume();
}}
