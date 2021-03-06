using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float timer;
    public Vector3 playerSpawn;
    Thread receiveThread;
    UdpClient client;
    int port;

    string text;
    bool left;
    bool right;
     

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.isStatic = true;
            GameObject[] Obstalces = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach(GameObject thing in Obstalces){
                Destroy(thing);
            }

            transform.position = playerSpawn;
   
        }
        gameObject.isStatic = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        StaticTimer();
        port = 5065;
        left = false;
        right = false;

        InitUDP();
    }

    // Update is called once per frame
    void Update()
    {
        if (text == "Left" && left == true && transform.position.z > -1.3)
        {  
            transform.Translate(Vector3.back * Time.deltaTime *16f);
            left = false;
        }
        if (text == "Right" && right == true && transform.position.z < 1.3)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 16f);
            right = false;
        }
        
    }


    private void InitUDP()
    {
        print("UDP Initialized");

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    { 
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
                byte[] data = client.Receive(ref anyIP);

                text = Encoding.UTF8.GetString(data);

                if (text == "Left")
                {
                    left = true;
                    Debug.Log("LEFT");
                }
                if (text == "Right")
                {
                    right = true;
                    Debug.Log("RIGHT");
                }

                text = Encoding.UTF8.GetString(data);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
            }
        }

    }

    private void StaticTimer()
    {
        for (timer = 0.0f; timer < 4.0f; timer += Time.deltaTime)
        {
            if (timer >= 3.0f)
            {
                gameObject.isStatic = false;
                return;
            }
        }       
    }
}
