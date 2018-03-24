using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject randomPrefab;
    public GameObject startPrefab;
    public GameObject questionPrefab;
    public GameObject eventPrefab;
    public GameObject bubble;
    public Text countdown;

    public float offset = 16f;
    public string[] roomTypes;
    public float bubbleSpeed = 3f;
    public float duration = 8f;
    public float timer = 10f;

    private bool[] playerReadyForChange;
    private Vector3 spawnPos = new Vector3(0f, 0f, 0f);
    private int counter = 1;



    // Raumwechsel
    // Raumbuilding

    private void Start()
    {
        buildNewRoom(true);

    }

    // Use this for initialization
    void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // Camera Lerp
            CameraMovement camMov = cam.GetComponent<CameraMovement>();
            camMov.enableCam();
            buildNewRoom();
            timer = 10f;
        }
        else
        {
            countdown.text = (Mathf.Round(timer)).ToString();
        }
        

        /*
		for (int i = 0; i < readyForChange.Length; i++)
        {
            if (readyForChange[i] == true)
            {
                if (i == playerReadyForChange.Length)
                {
                    changeSzene();
                    buildNewRoom();
                }
            }
            else
            {
                break;
            }
        }
        */
	}



    void getRoomType()
    {
        int randomNum = Random.Range(0, roomTypes.Length);
        buildRoomInterior(randomNum);
    }

    void buildRoomInterior(int roomNum)
    {
        GameObject newRoom = GameObject.Find("newRoom");
        if (newRoom != null)
        {
            GameObject oldRoom = GameObject.Find("newRoom");
            oldRoom.name = "oldRoom";
        }
        switch (roomNum)
        {
            //Random
            case 0:
                Vector3 prefabPos0 = randomPrefab.transform.position;
                float newHeight0 = prefabPos0.y + offset * counter;
                GameObject ranRoom = Instantiate(randomPrefab, new Vector3(prefabPos0.x, newHeight0, prefabPos0.z), Quaternion.identity);
                ranRoom.name = "newRoom";
                randomizeDif();
                break;
            // Event
            case 1:
                Vector3 prefabPos1 = eventPrefab.transform.position;
                float newHeight1 = prefabPos1.y + offset * counter;
                GameObject eventRoom = Instantiate(eventPrefab, new Vector3(prefabPos1.x, newHeight1, prefabPos1.z), Quaternion.identity);
                eventRoom.name = "newRoom";
                break;
            // Question
            case 2:
                Vector3 prefabPos2 = eventPrefab.transform.position;
                float newHeight2 = prefabPos2.y + offset * counter;
                GameObject questionRoom = Instantiate(questionPrefab, new Vector3(prefabPos2.x, newHeight2, prefabPos2.z), Quaternion.identity);
                questionRoom.name = "newRoom";
                break;
        }
    }

    void randomizeDif()
    {
        int dif1 = Random.Range(0, 10);
        int dif2 = Random.Range(0, 10);
        int dif3 = Random.Range(0, 10);
        int dif4 = Random.Range(0, 10);

        InvokeRepeating("spawnBubble1", 1f, Random.Range(5f, 6.5f) / dif1);
        InvokeRepeating("spawnBubble2", 1f, Random.Range(5f, 6.5f) / dif2);
        InvokeRepeating("spawnBubble3", 1f, Random.Range(5f, 6.5f) / dif3);
        InvokeRepeating("spawnBubble4", 1f, Random.Range(5f, 6.5f) / dif4);
    }

    void spawnBubble1()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-8.75f, -5.75f), y + 2f, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 3f);
    }
    void spawnBubble2()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-4.25f, -0.75f), y + 2f, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 3f);
    }
    void spawnBubble3()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(0.75f, 4.25f), y + 2f, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 3f);
    }
    void spawnBubble4()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(1).GetChild(1).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(5.75f, 8.75f), y + 2f, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 3f);
    }

    void changeSzene()
    {

    }

    void buildNewRoom(bool startRoom = false)
    {
        counter--;
        if (startRoom)
        {
            Instantiate(startPrefab);
            buildNewRoom();
        }
        else
        {
            getRoomType();
        }
        

    }
}
