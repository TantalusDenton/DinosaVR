/*
//Code using gyro, euler and camera parent. From a tutorial from a Ubisoft guy on YouTube. Seems better suited for VR but this version can only look down.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AWSSDK.Examples
{
	public class GyroControl : MonoBehaviour {
		
		private GameObject cameraContainer;
		private Quaternion rot;
		
		void Start () {
		 cameraContainer = new GameObject("Camera Container");
		 cameraContainer.transform.position = transform.position;
		 transform.SetParent(cameraContainer.transform);
		 
		cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
		rot	= new Quaternion(0, 0, 1, 0);
		}
		
		
		void Update () {
			
			transform.localRotation = Quaternion.Euler(float.Parse(TableQueryAndScanExample.XaxisValue), float.Parse(TableQueryAndScanExample.YaxisValue), float.Parse(TableQueryAndScanExample.ZaxisValue)) * rot;
		
		}
	}
}*/




//Script stable, from Unity forums.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AWSSDK.Examples
{
	public class GyroControl : MonoBehaviour {
		
		void Start () {
		 //nothing
		}
		
		void Update () {
			
		 Quaternion tmp = transform.rotation;
		 tmp.x = float.Parse(TableQueryAndScanExample.XaxisValue);
		 tmp.y = float.Parse(TableQueryAndScanExample.YaxisValue);
		 tmp.z = float.Parse(TableQueryAndScanExample.ZaxisValue);
		 transform.rotation = tmp;
		 
		}
	}
}