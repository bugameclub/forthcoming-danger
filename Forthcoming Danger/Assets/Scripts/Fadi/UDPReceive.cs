using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class UDPReceive : MonoBehaviour
{

    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;

    public void Start()
    {
        StartCoroutine(ReceiveData());
    }


    // receive thread
    IEnumerator ReceiveData()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.1f);




            UnityWebRequest request = new UnityWebRequest();
            request.downloadHandler = new DownloadHandlerBuffer();
            request.url = "http://127.0.0.1:7777";
            request.method = UnityWebRequest.kHttpVerbGET;
            yield return request.SendWebRequest();
            while(!request.isDone)
            {
                yield return null;
            }
            if (request.responseCode == 200)
            {
                string bestmove_text = request.downloadHandler.text;

                data = bestmove_text;
            }
            else
            {
                //errorFlag = true;
                Debug.Log("failed");
            }
            
        }
    }

}