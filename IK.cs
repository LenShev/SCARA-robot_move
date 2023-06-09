using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    public Joint m_root; //первый узел цепочки

    public Joint m_end; //последний узел цепочки

    public GameObject m_target; //точка за которой следует последний узел
     
    public float m_theshold = 0.05f; //допущение

    public float m_rate = 2.0f; //скорость вращения

    public int m_steps = 20; //частота просчётов

    float CalculateSlope(Joint _joint) //расчитать угловой коэффициент
    {
        float deltaAlpfa = 0.01f; //произвольно задаём очень маленький угол
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position); //получаем текущую позицию последнего узла

        _joint.Rotate(deltaAlpfa); //поворачиваем узел на заданый минимальный угол
       
        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position); //получаем новую позицию

        _joint.Rotate(-deltaAlpfa); //возвращаем узел в исходную позицию
        return (distance2 - distance1)/deltaAlpfa; //вычисляем угловой коэффициент
    }
    void Update() //вращение
    {
        for(int i = 0; i < m_steps; i++) //частота просчётов за одно обновление
        {
            if (GetDistance(m_end.transform.position, m_target.transform.position) > m_theshold) //если растояние между точкой и концом больше допустимого
            {
                Joint current = m_root; //присваеваем текущий узел, с которого обратываем информацию
                while (current != null) //пока узлы не закончились
                {
                    float slope = CalculateSlope(current); //расчитываем угловой коэффициент для текущего узла
                    current.Rotate(-slope * m_rate); //поворачиваем 
                    current = current.GetChild(); //переходим к следующему дочернему узлу
                }
            }
        }
    }
    float GetDistance(Vector3 _point1, Vector3 _point2) //получаем растояние
    {
        return Vector3.Distance(_point1, _point2);
    }
}