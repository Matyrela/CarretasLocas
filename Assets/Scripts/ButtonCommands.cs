using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommands : MonoBehaviour
{
    [SerializeField]
	private GameObject panel;
	private void Start()
	{
		panel.SetActive(false);
	}
	public void ActivatePanel()
    {
		panel.SetActive(true);
	}
	public void DesactivatePanel()
	{
		panel.SetActive(false);
	}
}
