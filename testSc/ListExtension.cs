
//  ListExtension.cs
//  http://kan-kikuchi.hatenablog.com/entry/ListExtension
//
//  Created by kan.kikuchi on 2016.04.29.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// List�̊g���N���X
/// </summary>
public static class ListExtension
{

    //=================================================================================
    //�d��
    //=================================================================================

    /// <summary>
    /// �d�����Ȃ��悤�ɒǉ�
    /// </summary>
    public static void AddToNotDuplicate<T>(this List<T> list, T t)
    {
        if (list.Contains(t))
        {
            return;
        }
        list.Add(t);
    }

    /// <summary>
    /// �d���𖳂���
    /// </summary>
    public static void RemoveDuplicate<T>(this List<T> list)
    {
        List<T> newList = new List<T>();

        foreach (T item in list)
        {
            newList.AddToNotDuplicate(item);
        }

        list = newList;
    }

    //=================================================================================
    //���ѕς�
    //=================================================================================

    /// <summary>
    /// �����_���ɕ��ёւ�
    /// </summary>
    public static List<T> Shuffle<T>(this List<T> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }

    //=================================================================================
    //�擾
    //=================================================================================

    /// <summary>
    /// �w�肵��No�̂��̂��擾���A���X�g�������
    /// </summary>
    public static T GetAndRemove<T>(this List<T> list, int targetNo)
    {
        if (list.Count <= targetNo || targetNo < 0)
        {
            Debug.LogError("���X�g�͈̔͂𒴂��Ă��܂��I(ListCount : " + list.Count + ", No : " + targetNo + ")");
        }

        T target = list[targetNo];
        list.Remove(target);
        return target;
    }

    //=================================================================================
    //�����o
    //=================================================================================

    /// <summary>
    /// �擪������o���A���X�g�������
    /// </summary>
    public static T Pop<T>(this List<T> list)
    {
        return list.GetAndRemove(list.Count - 1);
    }

    //=================================================================================
    //�����o
    //=================================================================================

    /// <summary>
    /// �Ō��������o���A���X�g�������
    /// </summary>
    public static T Dequeue<T>(this List<T> list)
    {
        return list.GetAndRemove(0);
    }

    //=================================================================================
    //�����_���擾
    //=================================================================================

    /// <summary>
    /// �����_���Ɏ擾����
    /// </summary>
    public static T GetAtRandom<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            Debug.LogError("���X�g����ł��I");
        }

        return list[Random.Range(0, list.Count)];
    }

    /// <summary>
    /// �����_���Ɏ擾���A���X�g�������
    /// </summary>
    public static T GetAndRemoveAtRandom<T>(this List<T> list)
    {
        T target = list.GetAtRandom();
        list.Remove(target);
        return target;
    }

}

