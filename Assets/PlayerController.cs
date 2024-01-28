using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public CharacterController controller;
    public bool isMoving = false;
    public GameObject fish;
    public GameObject adventurers;
    public GameObject spawnPoint;
    bool isFishSpawned = false;
    bool isAdventurersSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            PlaySound();
        }


        float x = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float z = Input.GetAxis("Vertical"); // W/S or Up/Down
        Vector3 move = new Vector3(x, 0.0f, z);

        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * speed);
            transform.forward = move;
            StartCoroutine(quitGame());
            isMoving = true;
        }else 
        {
            isMoving = false;   
            GetComponent<AudioSource>().Stop();
        }

        
            
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    void spawnFish()
    {
        if(!isFishSpawned){
        Instantiate(fish, spawnPoint.transform.position, Quaternion.identity);
        isFishSpawned = true;
        }
    }
    void spawnAdventurers()
    {
        if(!isAdventurersSpawned){
        Instantiate(adventurers, spawnPoint.transform.position, Quaternion.identity);
        isAdventurersSpawned = true;
        }
    }

    IEnumerator quitGame()
    {
        yield return new WaitForSeconds(5);
        spawnFish();
        yield return new WaitForSeconds(5);
        spawnAdventurers();
        yield return new WaitForSeconds(5);
        #if (UNITY_WEBGL)
                Application.OpenURL("about:blank");
        #endif
        Application.Quit();
    }

}

