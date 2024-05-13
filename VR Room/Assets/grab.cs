using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public string publicFace = "1";
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] directions = {transform.forward, -transform.forward, transform.right, -transform.right, transform.up, -transform.up};

        for(int i = 0; i<directions.Length; i++){
            RaycastHit hit;
            string face = "1";

            if(Physics.Raycast(transform.position, directions[i], out hit, 0.3f)){
                Debug.DrawRay(transform.position, directions[i] * 1f, Color.green);

                if(directions[i] == transform.forward){
                    face = "6";
                }
                else if(directions[i] == -transform.forward){
                    face = "1";
                }
                else if(directions[i] == transform.right){
                    face = "3";
                }
                else if(directions[i] == -transform.right){
                    face = "4";
                }
                else if(directions[i] == transform.up){
                    face = "5";
                }
                 else if(directions[i] == -transform.up){
                    face = "2";
                }
                if(publicFace != face){
                    Debug.Log("Face changed to " + face);
                    GetComponent<AudioSource>().Play();
                }
                publicFace = face;
            }
        }
        
    }
}
