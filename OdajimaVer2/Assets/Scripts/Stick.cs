using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    AudioSource audiosourse;
    [SerializeField] AudioClip In;
    [SerializeField] AudioClip Out;
    [SerializeField] Data data;
    // Start is called before the first frame update
    void Start()
    {
        audiosourse = GetComponent<AudioSource>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("siokara")) audiosourse.PlayOneShot(In);
        audiosourse.volume = (float)data.volume/200;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("siokara")) audiosourse.PlayOneShot(Out);
        audiosourse.volume = (float)data.volume/100;
        //start = true;
    }
}
