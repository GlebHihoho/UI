using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip removeSound;
    [SerializeField] private VisualTreeAsset shopItemTemplate;

    private ScrollView _scrollContainer;
    private Button _addNameButton;
    private TextField _nameField;
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
        var rootElement = GetComponent<UIDocument>().rootVisualElement;

        _scrollContainer = rootElement.Q<ScrollView>("scrollContainer");

        Button closeButton = rootElement.Q<Button>("closeButton");

        _addNameButton = rootElement.Q<Button>("addNameBtn");
        _nameField = rootElement.Q<TextField>("nameField");

        closeButton.clicked += () => CloseButton();

        _addNameButton.clicked += () => AddNewItem();

        foreach (var item in _shopItems)
        {
            VisualElement newElement = shopItemTemplate.CloneTree();
            Label label = newElement.Q<Label>("itemTitle");
            Label cost = newElement.Q<Label>("itemCost");
            Button removeButton = newElement.Q<Button>("removeBtn");

            label.text = item.Key;
            cost.text = item.Value;

            removeButton.clicked += () => RemoveItem(newElement);

            _scrollContainer.Add(newElement);
        }
    }

    private void AddNewItem()
    {
        VisualElement newElement = shopItemTemplate.CloneTree();

        Label label = newElement.Q<Label>("itemTitle");
        label.text = _nameField.value;
        _nameField.value = "";
        Button removeButton = newElement.Q<Button>("removeBtn");

        removeButton.clicked += () => RemoveItem(newElement);
        _scrollContainer.Add(newElement);

        source.PlayOneShot(clickSound);
    }

    private void CloseButton()
    {
        source.PlayOneShot(clickSound);
    }

    private void RemoveItem(VisualElement element)
    {
        source.PlayOneShot(removeSound);
        _scrollContainer.Remove(element);
    }
}
