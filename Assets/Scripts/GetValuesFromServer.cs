using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValuesFromServer : MonoBehaviour {

	//public string postURL = "heraldic.cloud/postGyro.php";
	public string getURL = "https://www.heraldic.cloud/getGyro.php";
	
	private string _player = "";
	
	void OnGUI() {
		//SaveGyro
		/*GUI.Label( new Rect( 10, 10, 50, 25), "Gyro");
		_player = GUI.TextField( new Rect(70, 10, 100, 25), _player);
		
		if( GUI.Button( new Rect(180, 10, 80, 25), "Send Gyro"))
			StartCoroutine("SaveGyro");*/
		
		//LoadGyro
		if(GUI.Button( new Rect(10, 80, 80, 25),"Get gyro"))
			StartCoroutine("LoadGyro");
	}
	
	private IEnumerator LoadGyro(){
		Debug.Log ("Getting name from " + getURL);
		
		//print out data returned here
		WWW getGyro = new WWW( getURL );
		
		//wait for a response
		yield return getGyro;
		
		Debug.Log ( getGyro.text);
	}
	
	/*private IEnumerator SaveGyro() {
		string urlString = postURL + "?gyro=" + WWW.EscapeURL(_player);
		
		//debug out the path that we are sending to
		Debug.Log ( "Sending: " + urlString);
		
		//send out data to the server to be processed
		WWW.postName = new WWW( urlString );
		
		yield return postName;
		
		Debug.Log ( postName.text );
	}*/
	
}
