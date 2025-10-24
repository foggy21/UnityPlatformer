using System;
using Clicker.Services;
using TMPro;
using UnityEngine;

namespace Clicker.View
{
    public class UpgradeView : MonoBehaviour
    {
        private Service _service;
        [SerializeField] private TMP_Text _bonus;
        [SerializeField] private TMP_Text _cost;

        private void Start()
        {
            _service = GetComponent<Service>();
            _service.OnUpgrade.AddListener(SetView);
            SetView();
        }

        private void SetView()
        {
            _bonus.text = $"Bonus: {_service.MoneyIncome}";
            _cost.text = $"Cost: {_service.Cost}";
        }
    }
}
