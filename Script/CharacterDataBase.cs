using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataBase", menuName = "CreateCharacterDataBase")]
public class CharacterDataBase : ScriptableObject
{
        [SerializeField]private List<Character> CharacterLists = new List<Character>();

        //�@�L�����N�^�[���X�g��Ԃ�
        public List<Character> GetCharacterLists()
        {
            return CharacterLists;
        }
}
