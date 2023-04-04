using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset shopItemTemplate;
    private readonly Dictionary<string, string> _shopItems = new Dictionary<string, string>()
    {
        { "cat", "50$" },
        { "dog", "50$" },
        { "rain", "100$" },
        { "unity", "3$" },
        { "time", "60$" },
        { "word", "15$" },
        { "game", "33$" },
        { "key", "44$" },
    };

    void Start()
    {
        ScrollView scrollContainer = GetComponent<UIDocument>().rootVisualElement.Q<ScrollView>("scrollContainer");

        foreach (var item in _shopItems)
        {
            VisualElement newElement = shopItemTemplate.CloneTree();
            Label label = newElement.Q<Label>("itemTitle");
            Label cost = newElement.Q<Label>("itemCost");

            label.text = item.Key;
            cost.text = item.Value;

            scrollContainer.Add(newElement);
        }
        print(scrollContainer);
    }
}
