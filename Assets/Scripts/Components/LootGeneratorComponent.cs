using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct LootGeneratorComponent
{
    /// <summary>
    /// Время, раз в которое генерируется новый объект.
    /// </summary>
    public float generateTime;
    /// <summary>
    /// Сколько времени прошло после последней генерации.
    /// </summary>
    public float leftTime;
}
