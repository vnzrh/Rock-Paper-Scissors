// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using DG.Tweening;

// public class Player : MonoBehaviour
// {
//    [SerializeField] Character selectedCharater;
//    [SerializeField] List<Character> charactersList;
//    [SerializeField] Transform atkRef;

//       public Character SelectedCharacter { get => selectedCharater; }
//       public List<Character> CharactersList { get => charactersList; set => charactersList = value;}

//       public void Prepare()
//       {
//             selectedCharater = null;
//       }

//       public void SelectCharacter(Character character)
//       {
//             selectedCharater = character;
//       }

//       public void Setplay(bool value)
//       {
//          foreach (var character in charactersList)
//             {
//                   character.Button.interactable = value;
//             }
//       }

//       public void Attack()
//       {
//             selectedCharater.transform.DOMove(atRef.position, 1f);
//       }

//       public bool IsAttacking()
//       {
//             if (selectedCharater == null)
//                   return false;
//             return DOTween.IsTweening(selectedCharater.transform) ;
//       }

//       internal void TakeDamage(int damageValue)
//       {
//             selectedCharater.ChangeHP(-damageValue);
//             var spriteRend = selectedCharater.getComponent<SpriteRenderer>();
//             spriteRend.DOColor(Color.red, duration: 0.1f).SetLoops(6, looptype.Yoyo);
//       }

//       public bool IsDamaging()
//       {
//             if (selectedCharater == null)
//                   return false;

//             var spriteRend = selectedCharater.getComponent<SpriteRenderer>();
//             return DOTween.IsTweening(spriteRend);
//       }

//       public void Remove(Character charater)
//       {
//             if (characterList.Contains(item: charater) == false)
//                   return;
          
//             if (selectedCharater == charater)
//                   selectedCharater = null;
          
//             charater.Button.interactable = false;
//             charater.gameObject.SetActive(false);
//             characterList.remove(charater);
//       }

//       internal void Return()
//       {
//             selectedCharater.transform.DOMove(selectedCharater.InitialPosition, 1f);
//       }

//       public bool IsReturning()
//       {
//             if (selectedCharater == null)
//                   return false;

//             return DOTween.IsTweening(TselectedCharater.transform);
//       }
// }
