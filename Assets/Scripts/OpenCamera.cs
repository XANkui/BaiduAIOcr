using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCamera : MonoBehaviour {

	public RawImage rawImage;
	private WebCamTexture webCamTexture;
	private Vector2 resolution = new Vector2(1280, 720);
	private int fps = 60;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(OpenBGCamera());
	}
	IEnumerator OpenBGCamera()
	{
		Debug.Log("Test");
		//获取摄像头权限
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
		if (Application.HasUserAuthorization(UserAuthorization.WebCam))
		{
			//停止正在使用的摄像头
			if (webCamTexture != null)
			{
				webCamTexture.Stop();
			}
			//判断时候有摄像头
			if (WebCamTexture.devices.Length != 0)
			{
				//new一个后置摄像头并且设置分辨率和FPS，渲染到UI上
				webCamTexture = new WebCamTexture(WebCamTexture.devices[0].name, (int)resolution.x, (int)resolution.y, fps);
				rawImage.texture = webCamTexture;
				webCamTexture.Play();
			}
		}
	}
}
