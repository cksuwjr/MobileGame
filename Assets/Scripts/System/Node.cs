using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WebSocketSharp;//웹 소켓 라이브러리를 사용한다

public class Node : MonoBehaviour
{
    private WebSocket ws;//소켓 선언
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:3333");// 127.0.0.1은 본인의 아이피 주소이다. 3333포트로 연결한다는 의미이다.
        ws.OnMessage += ws_OnMessage; //서버에서 유니티 쪽으로 메세지가 올 경우 실행할 함수를 등록한다.
        ws.OnOpen += ws_OnOpen;//서버가 연결된 경우 실행할 함수를 등록한다
        ws.OnClose += ws_OnClose;//서버가 닫힌 경우 실행할 함수를 등록한다.
        ws.Connect();//서버에 연결한다.
        ws.Send("hello");//서버에게 "hello"라는 메세지를 보낸다.
    }
    void ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);//받은 메세지를 디버그 콘솔에 출력한다.
    }
    void ws_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("open"); //디버그 콘솔에 "open"이라고 찍는다.
    }
    void ws_OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("close"); //디버그 콘솔에 "close"이라고 찍는다.
    }
}
