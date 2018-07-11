using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodViewAI;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using Baidu.Aip.Ocr;

public class Test : MonoBehaviour {

	[Header("UI")]
	public Text TextTip;
	public Text textOcrResult;
	public Button buttonTakePhoto;
	public Button buttonClose;

	[Header("GameObject")]
	public GameObject SettingsOcrPanel;
	public GameObject OcrPanel;

	bool isTip = false;
	byte[] imageBytes;
	[SerializeField]
	private OcrType CurrentOcrType = OcrType.GeneralBasic;
	// Use this for initialization
	void Start () {

		buttonTakePhoto.onClick.AddListener (OnClickTakePhoto);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			var result = GodViewOcr.Instance.Bankcard (Application.dataPath +"/BankCard.jpg");
			Debug.Log (result.ToString ());

			Bankcard ();
		}


	}

	/// <summary>
	/// Sets to bankcard.
	/// </summary>
	public void SetToBankcard(){
		CurrentOcrType = OcrType.Bankcard;
		textOcrResult.text = "";
	}

	/// <summary>
	/// Sets to general basic.
	/// </summary>
	public void SetToGeneralBasic(){
		CurrentOcrType = OcrType.GeneralBasic;
		textOcrResult.text = "";
	}

	/// <summary>
	/// Sets to business license.
	/// </summary>
	public void SetToBusinessLicense(){
		CurrentOcrType = OcrType.BusinessLicense;
		textOcrResult.text = "";
	}

	/// <summary>
	/// Sets to driving license.
	/// </summary>
	public void SetToDrivingLicense(){
		CurrentOcrType = OcrType.DrivingLicense;
		textOcrResult.text = "";
	}

	/// <summary>
	/// Sets to idcard.
	/// </summary>
	public void SetToIdcard(){
		CurrentOcrType = OcrType.Idcard;
		textOcrResult.text = "";
	}

	/// <summary>
	/// Sets to license plate.
	/// </summary>
	public void SetToLicensePlate(){
		CurrentOcrType = OcrType.LicensePlate;
		textOcrResult.text = "";
	}


	/// <summary>
	/// 使用拍照截图方式.
	/// </summary>
	public void OnClickTakePhoto(){

		StartCoroutine (ScreenShot_ReadPixels(CurrentOcrType));

	}

	/// <summary>
	/// 识别银行卡
	/// </summary>
	public void Bankcard(){
		
		var result = GodViewOcr.Instance.Bankcard (imageBytes);
		//var result = GodViewOcr.Instance.client.Bankcard(imageBytes);

		var words = result ["result"];

		if (words != null) {
			textOcrResult.text += "卡号：" + (words ["bank_card_number"] != null ? words ["bank_card_number"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "银行：" + (words ["bank_name"] != null ? words ["bank_name"] : "未识别，请重新确认")+ "\n";
		} 
		else {
			textOcrResult.text += "未识别，请重新确认";
		}



		Debug.Log ("Byte[] :" + result);
	}

	/// <summary>
	/// 识别文字
	/// </summary>
	public void GeneralBasic(){

		var result = GodViewOcr.Instance.GeneralBasic (imageBytes);
		Debug.Log ("Byte[] :" + result);

		var words = result["words_result"];
		Debug.Log ("words[] :" + words);

		if (words != null) {
			foreach (var word in words) {
				textOcrResult.text += word ["words"] + "\n";
			}
		} 
		else {
			textOcrResult.text += "未识别，请重新确认";
		}




	}

	/// <summary>
	/// 识别营业执照
	/// </summary>
	public void BusinessLicense(){

		var result = GodViewOcr.Instance.BusinessLicense (imageBytes);


		Debug.Log ("Byte[] :" + result);


	}

	/// <summary>
	/// 识别驾驶证
	/// </summary>
	public void DrivingLicense(){


		var result = GodViewOcr.Instance.DrivingLicense (imageBytes);

		var words = result["words_result"];	

		if (words != null) {
			textOcrResult.text += "有效期限：" + (words["有效期限"] != null ? words ["有效期限"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "准驾车型：" + (words["准驾车型"] != null ? words ["准驾车型"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "有效起始日期：" + (words["有效起始日期"] != null ? words ["有效起始日期"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "住址：" + (words["住址"] != null ? words ["住址"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "姓名：" + (words["姓名"]!= null ? words ["姓名"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "国籍：" + (words["国籍"] != null ? words ["国籍"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "出生日期：" + (words["出生日期"] != null ? words ["出生日期"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "性别：" + (words["性别"] != null ? words ["性别"] ["words"] : "未识别，请重新确认")+ "\n";
			textOcrResult.text += "初次领证日期：" + (words["初次领证日期"] != null ? words ["初次领证日期"] ["words"] : "未识别，请重新确认")+ "\n";
		} 
		else {
			textOcrResult.text += "未识别，请重新确认";
		}


	}

	/// <summary>
	/// 识别身份证
	/// </summary>
	public void Idcard(){


		var result = GodViewOcr.Instance.Idcard (imageBytes);
		Debug.Log ("Byte[] :" + result);

		var words = result["words_result"];	
		if (words != null) {

			textOcrResult.text += "姓名：" + (words ["姓名"] != null ? words ["姓名"] ["words"] : "未识别，请重新确认") + "\n";
			textOcrResult.text += "性别：" + (words ["性别"] != null ? words ["性别"] ["words"] : "未识别，请重新确认") + "\n";
			textOcrResult.text += "民族：" + (words ["民族"] != null ? words ["民族"] ["words"] : "未识别，请重新确认") + "\n";
			textOcrResult.text += "出生：" + (words ["出生"] != null ? words ["出生"] ["words"] : "未识别，请重新确认") + "\n";
			textOcrResult.text += "住址：" + (words ["住址"] != null ? words ["住址"] ["words"] : "未识别，请重新确认") + "\n";
			textOcrResult.text += "公民身份号码：" + (words ["公民身份号码"] != null ? words ["公民身份号码"] ["words"] : "未识别，请重新确认") + "\n";

		} else {
			textOcrResult.text += "未识别，请重新确认";
		}



	}

	/// <summary>
	/// 识别通用票据
	/// </summary>
	public void Receipt(){
		var result = GodViewOcr.Instance.Receipt (imageBytes);

		Debug.Log ("Byte[] :" + result);
	}

	/// <summary>
	/// 识别车牌
	/// </summary>
	public void LicensePlate(){

		var result = GodViewOcr.Instance.LicensePlate (imageBytes);

		Debug.Log ("Byte[] :" + result);

		TextTip.text = "";
	}

	/// <summary>
	/// 协程拍照
	/// </summary>
	/// <returns>The shot read pixels.</returns>
	private IEnumerator ScreenShot_ReadPixels(){
		yield return new WaitForEndOfFrame ();
		//读取像素
		Texture2D tex = new Texture2D(Screen.width, Screen.height);
		tex.ReadPixels(new Rect(0, 0, tex.width, tex.height),0,0);
		tex.Apply();
		//保存读取的结果

		imageBytes = tex.EncodeToPNG ();

	}

	/// <summary>
	/// Screens the shot read pixels.带参数的重载函数
	/// </summary>
	/// <returns>The shot read pixels.</returns>
	/// <param name="ocrType">Ocr type.</param>
	private IEnumerator ScreenShot_ReadPixels(OcrType ocrType){
		textOcrResult.text = "";
		buttonTakePhoto.gameObject.SetActive (false);
		yield return new WaitForEndOfFrame ();
		//读取像素
		Texture2D tex = new Texture2D(Screen.width, Screen.height);
		tex.ReadPixels(new Rect(0, 0, tex.width, tex.height),0,0);
		tex.Apply();
		//保存读取的结果

		imageBytes = tex.EncodeToPNG ();

		yield return new WaitForSeconds (0.01f);
		//保存截图
//		string path = Application.dataPath + "/ScreenShot_ReadPixels.png";
//		System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());

		JObject result;

		switch(ocrType){
		case OcrType.Bankcard:
			Bankcard ();

			break;
		case OcrType.BusinessLicense:
			BusinessLicense ();

			break;
		case OcrType.DrivingLicense:
			DrivingLicense ();

			break;
		case OcrType.GeneralBasic:
			GeneralBasic ();

			break;
		case OcrType.Idcard:
			Idcard ();

			break;
		case OcrType.LicensePlate:
			LicensePlate ();

			break;
		default:
			break;
		}
			
		TextTip.gameObject.SetActive (false);
		buttonClose.gameObject.SetActive (true);
		buttonTakePhoto.gameObject.SetActive (true);
	}

}
