using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource m_Source;
    [SerializeField] AudioSource b_Source;

    public GameObject butonP_On;
    public GameObject butonP_Off;
    public AudioClip background;
    public AudioClip move;
    public AudioClip Win;

    void Start()
    {
        m_Source.clip = move;
        if(b_Source != null)
        {
            b_Source.clip = background;
            b_Source.Play();
        }
        
    }


    public void moveSound()
    {
        m_Source.Play();
    }

    public void StopP()
    {
        b_Source.Stop();
        butonP_On.SetActive(false);
        butonP_Off.SetActive(true);

    }
    public void PlayP()
    {
        b_Source.Play();
        butonP_On.SetActive(true);
        butonP_Off.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
