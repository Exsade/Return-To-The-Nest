using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class Item {
	public int CoinsCost;
	public int GemsCost;
	public string Status;


	public void item(int coins, int gems, string status) {
		CoinsCost = coins;
		GemsCost = gems;
		Status = status;
	}


	public bool BuyAndSelect (string valuta) {
		bool bought = false;

		if (valuta == "Coins") {
			int Amount;
			if (PlayerPrefs.HasKey ("CoinsScore"))
				Amount = PlayerPrefs.GetInt ("CoinsScore");
			else
				Amount = 0;
			
			if (Amount >= CoinsCost) {
				PlayerPrefs.SetInt ("CoinsScore", Amount - CoinsCost);
				PlayerPrefs.Save ();
				Status = "Selected";

				bought = true;
			}
			else
				Debug.Log ("Purchase failed");

		}
		
		if (valuta == "Gems") {
			int Amount;
			if (PlayerPrefs.HasKey ("GemsScore"))
				Amount = PlayerPrefs.GetInt ("GemsScore");
			else
				Amount = 0;
			
			if (Amount >= GemsCost) {
				PlayerPrefs.SetInt ("GemsScore", Amount - GemsCost);
				PlayerPrefs.Save ();
				Status = "Selected";
				bought = true;
			}
			else
				Debug.Log ("Purchase failed");
		}

		return bought;
	}

	
}


public class StoreManager : MonoBehaviour {

	Item[] Items = new Item[7];
	
	public GameObject[] BuyPanels = new GameObject[7];
	public GameObject[] SelectPanels = new GameObject[7];
	public GameObject[] AvailablePanels = new GameObject[7];

	public GameObject[] ItemPanels = new GameObject[7];
	public Sprite[] ItemSprite = new Sprite[2];

	public GameObject Ask_Panel;

	public Text CoinsCostTxt, GemsCostTxt;

	string Valuta = "unknown";
	int ActiveItemNumber;

	void Start () {

		Items[0] = new Item();
		Items[0].item(0,0,"Selected");

		Items[1] = new Item();
		Items[1].item(200,2,"Not Available");

		Items[2] = new Item();
		Items[2].item(700,7,"Not Available");

		Items[3] = new Item();
		Items[3].item(950,9,"Not Available");

		Items[4] = new Item();
		Items[4].item(0,0,"Selected");

		Items[5] = new Item();
		Items[5].item(450,4,"Not Available");

		Items[6] = new Item();
		Items[6].item(900,9,"Not Available");

		//Shields
		if (PlayerPrefs.HasKey ("WhiteShield"))
			Items[0].Status = PlayerPrefs.GetString ("WhiteShield");
		else 
			Items[0].Status = "Selected";

		if (PlayerPrefs.HasKey ("YellowShield"))
			Items[1].Status = PlayerPrefs.GetString ("YellowShield");
		else
			Items[1].Status = "Not Available";

		if (PlayerPrefs.HasKey ("GreenShield"))
			Items[2].Status = PlayerPrefs.GetString ("GreenShield");
		else
			Items[2].Status =  "Not Available";

		if (PlayerPrefs.HasKey ("BlueShield"))
			Items[3].Status = PlayerPrefs.GetString ("BlueShield");
		else
			Items[3].Status =  "Not Available";

		//Magnets
		if (PlayerPrefs.HasKey ("LowMagnet"))
			Items[4].Status = PlayerPrefs.GetString ("LowMagnet");
		else
			Items[4].Status = "Selected";
		
		if (PlayerPrefs.HasKey ("Magnet"))
			Items[5].Status = PlayerPrefs.GetString ("Magnet");
		else
			Items[5].Status =  "Not Available";
		
		if (PlayerPrefs.HasKey ("MegaMagnet"))
			Items[6].Status = PlayerPrefs.GetString ("MegaMagnet");
		else
			Items[6].Status =  "Not Available";


		for (int i = 0; i < 7; i++) 
			ChangeItemsStatus (i);
		

	}

	public void ButtonPressed (int ItemNumber) {

		if (Items [ItemNumber].Status == "Not Available" && Valuta == "unknown") {
			Ask_Panel.SetActive (true);
			CoinsCostTxt.text = Items[ItemNumber].CoinsCost + "";
			GemsCostTxt.text =  Items[ItemNumber].GemsCost + "";
			ActiveItemNumber = ItemNumber;
		}

		if (Items [ItemNumber].Status == "Not Available" && Valuta != "unknown") {

			if(Items [ItemNumber].BuyAndSelect (Valuta)){   //If purchases complate
				if(ItemNumber < 4){
					Items [PlayerPrefs.GetInt ("SelectedShield")].Status = "Available";
					ItemPanels [PlayerPrefs.GetInt ("SelectedShield")].GetComponent<Image> ().sprite = ItemSprite [0];
					ChangeItemsStatus (PlayerPrefs.GetInt ("SelectedShield"));
					ChangeItemsStatus (ItemNumber);
				}
				else{
					Items [PlayerPrefs.GetInt ("SelectedMagnet")].Status = "Available";
					ItemPanels [PlayerPrefs.GetInt ("SelectedMagnet")].GetComponent<Image> ().sprite = ItemSprite [0];
					ChangeItemsStatus (PlayerPrefs.GetInt ("SelectedMagnet"));
					ChangeItemsStatus (ItemNumber);
				}

				Ask_Panel.SetActive(false);
			}

			Valuta = "unknown";
		}
		else if (Items [ItemNumber].Status == "Available") {
			Items [ItemNumber].Status = "Selected";

			if(ItemNumber < 4){
				Items [PlayerPrefs.GetInt ("SelectedShield")].Status = "Available";
				ItemPanels [PlayerPrefs.GetInt ("SelectedShield")].GetComponent<Image> ().sprite = ItemSprite [0];
				
				ChangeItemsStatus (PlayerPrefs.GetInt ("SelectedShield"));
				ChangeItemsStatus (ItemNumber);
			}
			else {
				Items [PlayerPrefs.GetInt ("SelectedMagnet")].Status = "Available";
				ItemPanels [PlayerPrefs.GetInt ("SelectedMagnet")].GetComponent<Image> ().sprite = ItemSprite [0];

				ChangeItemsStatus (PlayerPrefs.GetInt ("SelectedMagnet"));
				ChangeItemsStatus (ItemNumber);
			}

		} 
		else
			Debug.Log ("Item was selected befor press");


		PlayerPrefs.SetString ("WhiteShield", Items [0].Status);
		PlayerPrefs.SetString ("YellowShield", Items [1].Status);
		PlayerPrefs.SetString ("GreenShield", Items [2].Status);
		PlayerPrefs.SetString ("BlueShield", Items [3].Status);
		PlayerPrefs.SetString ("LowMagnet", Items [4].Status);
		PlayerPrefs.SetString ("Magnet", Items [5].Status);
		PlayerPrefs.SetString ("MegaMagnet", Items [6].Status);
		PlayerPrefs.Save ();

		Debug.Log ("Selected shield: " + PlayerPrefs.GetInt ("SelectedShield"));
		Debug.Log ("Selected magnet: " + PlayerPrefs.GetInt ("SelectedMagnet"));
	}
	
	
	void ChangeItemsStatus (int ItemNumber) {

		switch(Items[ItemNumber].Status) {
					
		case "Selected":
			BuyPanels[ItemNumber].SetActive(false);
			SelectPanels[ItemNumber].SetActive(true);
			AvailablePanels[ItemNumber].SetActive(false);
					
			ItemPanels [ItemNumber].GetComponent<Image> ().sprite = ItemSprite [1];

			if(ItemNumber < 4)
				PlayerPrefs.SetInt("SelectedShield", ItemNumber);
			else
				PlayerPrefs.SetInt("SelectedMagnet", ItemNumber);

			PlayerPrefs.Save();
					
			break;
					
		case "Not Available":
			BuyPanels[ItemNumber].SetActive(true);
			SelectPanels[ItemNumber].SetActive(false);
			AvailablePanels[ItemNumber].SetActive(false);
			break;

		case "Available":
			BuyPanels[ItemNumber].SetActive(false);
			SelectPanels[ItemNumber].SetActive(false);
			AvailablePanels[ItemNumber].SetActive(true);
			break;

		default:
			Debug.Log("Incorrect status in " + ItemNumber + " item");
			break;
		}

	}

	public void ChooseValute(string valuta) {
		Valuta = valuta;
		ButtonPressed (ActiveItemNumber);
	}

}
