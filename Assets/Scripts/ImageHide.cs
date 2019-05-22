using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Utils;


public class ImageHide : MonoBehaviour
{
	public bool imageFlag;
	public Image img;

	void Start()
	{
		img.enabled = true;
		imageFlag = true;
	}

	void Update()
	{
		if (imageFlag == true) { 
			GetComponent<Button>().onClick.AddListener(() =>
				{
					img.enabled = false;
					imageFlag = false;
				});
		}
			
		else 
		{
			GetComponent<Button>().onClick.AddListener(() =>
				{
					img.enabled = true;
					imageFlag = true;
				});
		}
	}
}
