using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoFondo : MonoBehaviour
{
    public AudioClip sonidoFondo;

    // Start is called before the first frame update
    void Start()
    {
        AudioManagerScript.Instance.m_audioSource.Stop();
        AudioManagerScript.Instance.m_audioSource.clip=sonidoFondo;
        AudioManagerScript.Instance.m_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
