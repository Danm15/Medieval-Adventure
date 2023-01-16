using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private WidgetDamageValue _widgetDamageValuePrefab;
    [SerializeField] private Transform _damageValueContainer;

    private Dictionary<DamageType, Color> _damageColorMap = new Dictionary<DamageType, Color>
    {
        {DamageType.Electric,Color.yellow},
        {DamageType.Critical,Color.red},
        {DamageType.Physical,Color.white}
    };

    
    

    public void CreateWidgetDamageValue(DamageType damageType, int damage)
    {
        var color = _damageColorMap[damageType];
        var widget = Instantiate(_widgetDamageValuePrefab, _damageValueContainer);
        var maxDistance = 0.5f;
        var randomOffset = Random.insideUnitCircle * maxDistance;
        var position = _damageValueContainer.position + new Vector3(randomOffset.x, randomOffset.y, randomOffset.x);
        widget.transform.position = position;

        widget.SetValue(damage.ToString());
        widget.SetColor(color);
    }

   
}
