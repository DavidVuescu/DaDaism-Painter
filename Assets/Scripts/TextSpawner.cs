using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Intendix.Board;
using System;
using System.Net;
using Unity.ItemRecever;


namespace textSpawner
{
    public class TextSpawner : MonoBehaviour
    {
        public GameObject textElement;
        public bool shouldTextBeSpawned;
        public string currentTextItem;

        public ScreenshotTaker photo;
        
        [SerializeField]
        public GameObject Abstract;
        public GameObject Acrylic;
        public GameObject Algorithm;
        public GameObject Antique;
        public GameObject Argument;
        public GameObject Artwork;
        public GameObject Blueprint;
        public GameObject Brush;
        public GameObject Bug;
        public GameObject Business;
        public GameObject Cable;
        public GameObject Carving;
        public GameObject Clay;
        public GameObject Code;
        public GameObject Coding;
        public GameObject Colour;
        public GameObject Construction;
        public GameObject Displays;
        /*public GameObject Drawer;
        public GameObject Figure;
        public GameObject Full;
        public GameObject Functions;
        public GameObject Graphics;
        public GameObject Hackathon;
        public GameObject Hardware;
        public GameObject Idea;
        public GameObject Install;
        public GameObject Job;
        public GameObject Loops;
        public GameObject Machine;
        public GameObject Making;
        public GameObject Modeling;
        public GameObject Monet;
        public GameObject Movies;
        public GameObject Multiprocessor;
        public GameObject Musical;
        public GameObject Picasso;
        public GameObject Plaster;
        public GameObject Platform;
        public GameObject Prints;
        public GameObject Robotics;
        public GameObject Script;
        public GameObject Sculpture;
        public GameObject Software;
        public GameObject Solving;
        public GameObject Stain;
        public GameObject Statement;
        public GameObject Syntax;
        public GameObject Uninstall;
        public GameObject Variable; */
    

        public void spawnText()
        {
            for (int i = 0; i < 128; i++)
            {
                float x = UnityEngine.Random.Range(-1840, 1920);
                float y = UnityEngine.Random.Range(-1060, 1080);

                    
                switch(currentTextItem)
                {
                    case "abstract":
                        {
                            Instantiate(Abstract, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "acrylic":
                        {
                            Instantiate(Acrylic, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "algorithm":
                        {
                            Instantiate(Algorithm, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "antique":
                        {
                            Instantiate(Antique, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "argument":
                        {
                            Instantiate(Argument, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "artwork":
                        {
                            Instantiate(Artwork, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "blueprint":
                        {
                            Instantiate(Blueprint, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "brush":
                        {
                            Instantiate(Brush, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "bug":
                        {
                            Instantiate(Bug, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "business":
                        {
                            Instantiate(Business, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "cable":
                        {
                            Instantiate(Cable, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "carving":
                        {
                            Instantiate(Carving, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "clay":
                        {
                            Instantiate(Clay, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "code":
                        {
                            Instantiate(Code, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "coding":
                        {
                            Instantiate(Coding, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "colour":
                        {
                            Instantiate(Colour, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "construction":
                        {
                            Instantiate(Construction, new Vector2(x, y), Quaternion.identity);
                            break;
                        }
                    case "displays":
                        {
                            Instantiate(Displays, new Vector2(x, y), Quaternion.identity);
                            break;
                        }

                }

                Debug.Log("Spawning text");
            }
            shouldTextBeSpawned = false;
            ScreenCapture.CaptureScreenshot(Application.dataPath + "\\Screenshot " + System.DateTime.Now.ToString("MM-dd-yy (HH-mm-ss)") + ".png");
        }

        public static string ips = "127.0.0.1";
        public static int port = 1000;
        public static IPAddress ip = IPAddress.Parse(ips);
        void connection(IPAddress ip, int port)
        {
            // Connection with Unicorn BCI
            try
            {
                //Start listening for Unicorn Speller network messages
                SpellerReceiver r = new SpellerReceiver(ip, port);

                //attach items received event
                r.OnItemReceived += OnItemReceived;

                Debug.Log(String.Format("Listening to {0} on port {1}.", ip, port));
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }

        }
        private void OnItemReceived(object sender, EventArgs args)
        {
            ItemReceivedEventArgs eventArgs = (ItemReceivedEventArgs)args;
            Debug.Log(string.Format("Received BoardItem:\tName: {0}\tOutput Text: {1}", eventArgs.BoardItem.Name, eventArgs.BoardItem.OutputText));

            shouldTextBeSpawned = true;
            currentTextItem = eventArgs.BoardItem.OutputText;
        }


        // Start is called before the first frame update
        void Start()
        {
            shouldTextBeSpawned = false;
            connection(ip, port);
        }

        // Update is called once per frame
        void Update()
        {
            if (shouldTextBeSpawned) spawnText();
        }
    }
}
