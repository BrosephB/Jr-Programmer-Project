using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit // Inherits from unit 
{
    private ResourcePile m_currentPile = null;
    public float productivityMultiplier = 2;
    protected override void BuildingInRange()
    {
        if (m_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_currentPile = pile;
                m_currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }

    }

    void ResetProductivity()
    {
        if (m_currentPile != null)
        {
            m_currentPile.ProductionSpeed /= productivityMultiplier;
            m_currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
