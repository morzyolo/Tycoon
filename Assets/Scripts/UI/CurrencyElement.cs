using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutElement))]
public class CurrencyElement : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private TMP_Text _text;

	public void Initialize(Sprite sprite, uint value)
	{
		_image.sprite = sprite;
		_text.text = value.ToString();
	}

	public void ChangeValue(uint value)
	{
		_text.text = value.ToString();
	}
}