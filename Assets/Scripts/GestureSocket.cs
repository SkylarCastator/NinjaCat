using UnityEngine;
using System.Collections;
 
 
public class GestureSocket : MonoBehaviour {
       public string IP = ("localhost");
       public int port = 42685;
       public Vector3 XYZ = new Vector3(0,0,0);
       public int hand = 1;
       public GameObject input;
       bool connected = true;
       public SwordScript jsScript;
       public Texture2D videotexture;
       public int skipTexture = 0;
       public bool video = false;
	   
	private Perceptual.GestureClientAsync client;
	private Perceptual.GestureVideoClient videoClient;
	
       // Use this for initialization
       void Start () {
				if(video){
//              client = new Perceptual.GestureVideoClient(IP);
				} else{
			client = new Perceptual.GestureClientAsync(IP);
				}
              try {
                     (client as Perceptual.GestureClientAsync).Start();
              } catch (System.Exception ex) {
                     Debug.Log("Couldn't connect to socket.");
                     connected = false;
              }
                    
              //glider = GameObject.Find("Glider");
		if(video){
//              GameObject VideoPlane = GameObject.Find("VideoPlane");
//			  VideoPlane.active = true;
//              videotexture = new Texture2D(client.Image.Width/2,client.Image.Height/2);
//              VideoPlane.renderer.material.mainTexture = videotexture;
		}
             
       }
      
       // Update is called once per frame
       void Update () {
              if(connected){
                     if(client.Data.gestureList != null){
                          /*
                           int maxHand = (int)client.Data.nGesture;
                           for(int i=0; i<maxHand;i++){
                                  //Debug.Log("hand: " + i + "x:" + client.Data.gestureList[i].x + " y: " + client.Data.gestureList[i].y);
                    
                                  int label = (int)client.Data.gestureList[i].label;
                                  //Debug.Log(label);
                                  if(label == (int)PXC.GestureLabel.SRHandRockStatic) {
                                         Debug.Log("ROCK");        
                                  }
                                 
                                  if(label == (int)PXC.GestureLabel.SRHandPaperStatic) {
                                         Debug.Log("PAPER");       
                                  }
                                 
                                  if(label == (int)PXC.GestureLabel.SRHandScissorStatic) {
                                         Debug.Log("SCISSORS");           
                                   }
                                   
                           }
				*/
                           float X = (float)client.Data.gestureList[0].x; //0-640  0,0 is top left
                           float Y = (float)client.Data.gestureList[0].y; //0-480 640,480 is bottom right
				
				X = -(X-320)+320;
				Y = -(Y-240)+240;
                     XYZ = new Vector3(X, Y, 0);
                  //   Debug.Log("hand: " + 0 + "x:" + XYZ.x + " y: " + XYZ.y);
                    
                     jsScript = this.GetComponent<SwordScript>();
                     jsScript.XY = new Vector2(XYZ.x, XYZ.y);
                     }
                    if(video){
//                     if ( skipTexture == 0 ){
//                     Color32 color = new Color32(0,0,0,0);
//                     for ( int y=0, p=0; y< videotexture.height; y++ ){
//                           for ( int x=0; x<videotexture.width; x++ ){
//                                  color.r = client.Image.Data[p++];
//                                  color.g = client.Image.Data[p++];
//                                  color.b = client.Image.Data[p++]; p+=5;
//                                  color.a = 255;
//                                  videotexture.SetPixel(x,y,color);
//                           }
//                           //p+= (client as Perceptual.GestureVideoClient).Image.Width*4;
//                     }
//                           videotexture.Apply();
//                     }
//                     skipTexture = ++skipTexture > 4 ? 0 : skipTexture;
				}
              }
       }//end update
	
       void OnApplicationQuit(){
              if(connected){
                     client.Terminate();
                     Debug.Log("Stop");
              }
       }
}