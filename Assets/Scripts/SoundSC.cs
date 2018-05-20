using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSC : MonoBehaviour {

	public float sensitivity = 100;
	public float loudness = 0;
	public GameObject bombPrefab;
	AudioSource _audio;

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource> ();
		_audio.clip = Microphone.Start (null, true, 10, 44100);
		_audio.loop = true;
		_audio.mute = true;
		while (!(Microphone.GetPosition (null) > 0)) {
		}

		_audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		loudness = GetAveragedVolume () * sensitivity;
		if (loudness > 15)
			Debug.Log ("bisa");
	{
		Vector2 pos = transform.position;
		pos.x = Mathf.Round (pos.x);
		pos.y = Mathf.Round (pos.y);
		Instantiate (bombPrefab, pos, Quaternion.identity);

	}
}
	float GetAveragedVolume()
	{
		float[] data = new float[256];
		float a = 0;
		_audio.GetOutputData (data, 0);
		foreach (float s in data)
		{
			a+=Mathf.Abs(s);
		}
		return a / 256;
	}

}
