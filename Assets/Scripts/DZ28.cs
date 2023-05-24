using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DZ28 : MonoBehaviour
{
    [SerializeField] public TextAsset _textAsset;

    void Awake()
    {
        var names = _textAsset.text.Split('\n').Select(name => name.Trim());

        var namesEndingWithS = names.Where(name => name.LastOrDefault() == 'S');
        var maxNameLength = names.Select(name => name.Length).Max();

        print(string.Join(", ", namesEndingWithS));
        print(maxNameLength);
    }
}
