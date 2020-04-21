using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class CoinCounter : MonoBehaviour {

	private int _totalCoins = 0;
	private int _collected = 0;
	private UnityEngine.UI.Text _text;

	private const string _message = "YOU WIN\n\r{0} / {1} Coins\n\r Found";
	// Use this for initialization
	void Start () {
		_totalCoins = FindObjectsOfType<Coin>().Count();
		_text = GetComponent<UnityEngine.UI.Text>();
	}
	
	private void UpdateText()
	{
		_text.text = string.Format(_message, _collected, _totalCoins);
	}
	
	public void CollectCoin()
	{
		++_collected;
		UpdateText();
	}
}
