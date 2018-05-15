using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] { "i remember", "pardon me", "sure why not", "im sorry i can not", "you can do it", "just give up", "play", "deploy", "go", "after" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    //public Text results;
   // public Image target;
    public Bomb bombspawn;
	//public BombSpawner bombspawn;
	public GameObject player;
	public GameObject bombPrefab;
	//public Bomb bombexplode;

    //public TalkTalkScene2_2 talk2;
    //public TalkTalkScene3 talk3;

    protected PhraseRecognizer recognizer;
    public string word = "";

    public bool Read=false;

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }

        bombspawn = FindObjectOfType<Bomb>();
		//bombspawn = FindObjectOfType<BombSpawner>();
        //talk2 = FindObjectOfType<TalkTalkScene2_2>();
        //talk3 = FindObjectOfType<TalkTalkScene3>();
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        //results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        switch (word)
        {
            case "i remember":
                Application.LoadLevel(2);
                //y += speed;
                break;
            case "pardon me":
                Application.LoadLevel(4);
                //y -= speed;
                break;
            case "sure why not":
                //x -= speed;
                Application.LoadLevel(3);
                break;
            case "im sorry i can not":
                //x += speed;
                Application.LoadLevel(5);
                break;
            case "you can do it":
                //x += speed;
                Application.LoadLevel(6);
                break;
            case "just give up":
                //x += speed;
                Application.LoadLevel(7);
                break;
            case "play":
                Application.LoadLevel(1);
                break;
            case "deploy":
                {
                    word = " ";
				Instantiate (bombPrefab, player.transform.position, Quaternion.identity);
				//bombspawn.bombPrefab ();
                    //talk1.talking();
                }
                break;
            case "go":
                {
                    word = " ";
                    //talk2.talking();
                }
                break;
            case "after":
                {
                    word = " ";
                    //talk3.talking();
                }
                break;
        }

    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
