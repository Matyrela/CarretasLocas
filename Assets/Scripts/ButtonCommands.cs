using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommands : MonoBehaviour
{
    [SerializeField]
	private GameObject panel1;
	[SerializeField]
	private GameObject panel2;

	private void Start()
	{
		panel1.SetActive(false);
		panel2.SetActive(false);
	}
	public void ActivatePanel()
    {
		panel1.SetActive(true);
	}
	public void DesactivatePanel()
	{
		panel1.SetActive(false);
	}
	public void ActivateConfirmationPanel()
    {
		panel2.SetActive(true);
	}
	public void DesactivateAllPanel()
	{
		panel1.SetActive(false);
		panel2.SetActive(false);
	}
}
