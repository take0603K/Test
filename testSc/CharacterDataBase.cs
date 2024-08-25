using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataBase", menuName = "CreateCharacterDataBase")]
public class CharacterDataBase : ScriptableObject
{
        [SerializeField]private List<Character> CharacterLists = new List<Character>();

        //　キャラクターリストを返す
        public List<Character> GetCharacterLists()
        {
            return CharacterLists;
        }
}
