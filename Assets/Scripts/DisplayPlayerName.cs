using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerName : MonoBehaviour {
	Text PlayerName;

	// Use this for initialization
	void Start () {
		PlayerName = gameObject.GetComponent<Text> ();
		PlayerName.text = "";
	}

	// Update is called once per frame
	void Update () {
		if (PlayerName.text.Length < 8) {
			if (Input.GetKeyDown (KeyCode.A)) {
				PlayerName.text = PlayerName.text + "A";
			}
			if (Input.GetKeyDown (KeyCode.B)) {
				PlayerName.text = PlayerName.text + "B";
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				PlayerName.text = PlayerName.text + "C";
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				PlayerName.text = PlayerName.text + "D";
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				PlayerName.text = PlayerName.text + "E";
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				PlayerName.text = PlayerName.text + "F";
			}
			if (Input.GetKeyDown (KeyCode.G)) {
				PlayerName.text = PlayerName.text + "G";
			}
			if (Input.GetKeyDown (KeyCode.H)) {
				PlayerName.text = PlayerName.text + "H";
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				PlayerName.text = PlayerName.text + "I";
			}
			if (Input.GetKeyDown (KeyCode.J)) {
				PlayerName.text = PlayerName.text + "J";
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				PlayerName.text = PlayerName.text + "K";
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				PlayerName.text = PlayerName.text + "M";
			}
			if (Input.GetKeyDown (KeyCode.N)) {
				PlayerName.text = PlayerName.text + "N";
			}
			if (Input.GetKeyDown (KeyCode.L)) {
				PlayerName.text = PlayerName.text + "L";
			}
			if (Input.GetKeyDown (KeyCode.O)) {
				PlayerName.text = PlayerName.text + "O";
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				PlayerName.text = PlayerName.text + "P";
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				PlayerName.text = PlayerName.text + "Q";
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				PlayerName.text = PlayerName.text + "R";
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				PlayerName.text = PlayerName.text + "S";
			}
			if (Input.GetKeyDown (KeyCode.T)) {
				PlayerName.text = PlayerName.text + "T";
			}
			if (Input.GetKeyDown (KeyCode.U)) {
				PlayerName.text = PlayerName.text + "U";
			}
			if (Input.GetKeyDown (KeyCode.V)) {
				PlayerName.text = PlayerName.text + "V";
			}
			if (Input.GetKeyDown (KeyCode.W)) {
				PlayerName.text = PlayerName.text + "W";
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				PlayerName.text = PlayerName.text + "X";
			}
			if (Input.GetKeyDown (KeyCode.Y)) {
				PlayerName.text = PlayerName.text + "Y";
			}
			if (Input.GetKeyDown (KeyCode.Z)) {
				PlayerName.text = PlayerName.text + "Z";
			}
			if (Input.GetKeyDown (KeyCode.Alpha0)) {
				PlayerName.text = PlayerName.text + "0";
			}
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				PlayerName.text = PlayerName.text + "1";
			}
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				PlayerName.text = PlayerName.text + "2";
			}
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				PlayerName.text = PlayerName.text + "3";
			}
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				PlayerName.text = PlayerName.text + "4";
			}
			if (Input.GetKeyDown (KeyCode.Alpha5)) {
				PlayerName.text = PlayerName.text + "5";
			}
			if (Input.GetKeyDown (KeyCode.Alpha6)) {
				PlayerName.text = PlayerName.text + "6";
			}
			if (Input.GetKeyDown (KeyCode.Alpha7)) {
				PlayerName.text = PlayerName.text + "7";
			}
			if (Input.GetKeyDown (KeyCode.Alpha8)) {
				PlayerName.text = PlayerName.text + "8";
			}
			if (Input.GetKeyDown (KeyCode.Alpha9)) {
				PlayerName.text = PlayerName.text + "9";
			}
			if (Input.GetKeyDown (KeyCode.Keypad0)) {
				PlayerName.text = PlayerName.text + "0";
			}
			if (Input.GetKeyDown (KeyCode.Keypad1)) {
				PlayerName.text = PlayerName.text + "1";
			}
			if (Input.GetKeyDown (KeyCode.Keypad2)) {
				PlayerName.text = PlayerName.text + "2";
			}
			if (Input.GetKeyDown (KeyCode.Keypad3)) {
				PlayerName.text = PlayerName.text + "3";
			}
			if (Input.GetKeyDown (KeyCode.Keypad4)) {
				PlayerName.text = PlayerName.text + "4";
			}
			if (Input.GetKeyDown (KeyCode.Keypad5)) {
				PlayerName.text = PlayerName.text + "5";
			}
			if (Input.GetKeyDown (KeyCode.Keypad6)) {
				PlayerName.text = PlayerName.text + "6";
			}
			if (Input.GetKeyDown (KeyCode.Keypad7)) {
				PlayerName.text = PlayerName.text + "7";
			}
			if (Input.GetKeyDown (KeyCode.Keypad8)) {
				PlayerName.text = PlayerName.text + "8";
			}
			if (Input.GetKeyDown (KeyCode.Keypad9)) {
				PlayerName.text = PlayerName.text + "9";
			}
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
				if (PlayerName.text.Length > 0) {
					PlayerPrefs.SetString ("CurrentUser", PlayerName.text);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (PlayerName.text.Length > 0) {
				PlayerName.text = PlayerName.text.Remove (PlayerName.text.Length - 1);		
			}
		}
	}
}