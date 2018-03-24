using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject roomPrefab;
    public GameObject startPrefab;
    public GameObject bubble;

    public float offset = 16f;
    public string[] roomTypes;
    public float bubbleSpeed = 3f;

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
        buildRoomInterior(0);
    }

    void buildRoomInterior(int roomNum)
    {
        GameObject newRoom = GameObject.Find("newRoom");
        switch(roomNum)
        {
            //Random
            case 0:
                newRoom.transform.GetChild(3).gameObject.SetActive(false);
                randomizeDif();
                break;
            // Event
            case 1:
                newRoom.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
                break;
            // Question
            case 2:
                newRoom.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
                newRoom.transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
                newRoom.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
                break;
        }
    }

    void randomizeDif()
    {
        int dif1 = Random.Range(0, 10);
        int dif2 = Random.Range(0, 10);
        int dif3 = Random.Range(0, 10);
        int dif4 = Random.Range(0, 10);

        InvokeRepeating("spawnBubble1", 1f, dif1 * Random.Range(0.25f, 0.75f));
        InvokeRepeating("spawnBubble2", 1f, dif2 * Random.Range(0.25f, 0.75f));
        InvokeRepeating("spawnBubble3", 1f, dif3 * Random.Range(0.25f, 0.75f));
        InvokeRepeating("spawnBubble4", 1f, dif4 * Random.Range(0.25f, 0.75f));
    }

    void spawnBubble1()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(0).GetChild(3).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-9f, -6.5f), y, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 4f);
    }
    void spawnBubble2()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(0).GetChild(3).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(-4f, 0f), y, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 4f);
    }
    void spawnBubble3()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(0).GetChild(3).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(0f, 4f), y, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 4f);
    }
    void spawnBubble4()
    {
        GameObject newRoom = GameObject.Find("newRoom");
        float y = newRoom.transform.GetChild(0).GetChild(3).transform.position.y;
        GameObject bub = Instantiate(bubble, new Vector3(Random.Range(6.5f, 9f), y, 0f), Quaternion.identity);
        bub.GetComponent<Rigidbody2D>().velocity = bub.transform.up * bubbleSpeed;
        Destroy(bub, 4f);
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
            Vector3 prefabPos = roomPrefab.transform.position;
            float newHeight = prefabPos.y + offset * counter;
            GameObject newRoom = Instantiate(roomPrefab, new Vector3(prefabPos.x, newHeight, prefabPos.z), Quaternion.identity);
            if (GameObject.Find("newRoom") != null)
            {
                GameObject oldRoom = GameObject.Find("newRoom");
                oldRoom.name = "oldRoom";
            }
            newRoom.name = "newRoom";
            getRoomType();
        }
        

    }
}
