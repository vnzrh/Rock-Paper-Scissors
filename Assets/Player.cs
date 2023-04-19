using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
	[SerializeField] Character selectedCharacter;
	[SerializeField] List<Character> characterList;
	[SerializeField] Transform atkRef;
	[SerializeField] bool isBot;
	
	[SerializeField] UnityEvent onTakeDamage;
	[SerializeField] UnityEvent onCountdownStart;

	public Character SelectedCharacter { get => selectedCharacter; }
	
	public List<Character> CharacterList { get => characterList; }

	private void Start()
	{
		if (isBot)
		{
			foreach (var character in characterList)
			{
				character.Button.interactable = false;
			}	
		}
	}
	
	public void Prepare()
	{
		selectedCharacter = null;
	}

	public void SelectCharacter(Character character)
	{
		selectedCharacter = character;
	}

	public void SetPlay(bool value)
	{
		if (isBot)
		{
			List<Character> lotteryList = new List<Character>();
			foreach (var character in characterList)
			{
				int ticket = Mathf.RoundToInt( ((float) character.CurrentHP/(float) character.MaxHP)*10);
				for (int i = 0; i < ticket; i++)
				{
					lotteryList.Add(character);
				}
				character.Button.interactable = value;
			}
			int index = Random.Range(0,characterList.Count);
			selectedCharacter = CharacterList[index];
		}
		else
		{
			foreach (var character in characterList)
			{
				character.Button.interactable = value;
			}
		}
	}
	
	public void Attack()
	{
		onCountdownStart.Invoke();
		selectedCharacter.transform.DOMove(atkRef.position, 6f);
	}

	public bool IsAttacking()
	{
		if(selectedCharacter == null)
			return false;
		return DOTween.IsTweening(selectedCharacter.transform);
	}
	
	public void TakeDamage(int damageValue)
	{
		selectedCharacter.ChangeHP(-damageValue);
		var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
		spriteRend.DOColor(Color.red, 0.1f).SetLoops(6, LoopType.Yoyo);
		onTakeDamage.Invoke();
	}
	
	public bool IsDamaging()
	{
		if(selectedCharacter == null)
			return false;
		var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
		return DOTween.IsTweening(spriteRend);
	}
	
	public void Remove(Character character)
	{
		if(characterList.Contains(character) == false)
		 	return;
			
		if(selectedCharacter == character)
			selectedCharacter = null;
		character.Button.interactable = false;
		character.gameObject.SetActive(false);
		characterList.Remove(character);
	}
	
	public void Return()
	{
		selectedCharacter.transform.DOMove(selectedCharacter.InitialPosition, 0.7f);
	}
	
	public bool IsReturning()
	{
		if(selectedCharacter == null)
			return false;
		return DOTween.IsTweening(selectedCharacter.transform);
	}
	
}