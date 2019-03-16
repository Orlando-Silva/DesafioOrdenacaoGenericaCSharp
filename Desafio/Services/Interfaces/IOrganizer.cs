#region --Using--
using Desafio.Enums;
using System;
using System.Collections.Generic;
#endregion

namespace Desafio.Services.Interfaces
{
    public interface IOrganizer<T> 
    {
        /// <summary>
        /// Organiza uma lista genérica.
        /// </summary>
        /// <typeparam name="K">Tipo do campo que será organizado.</typeparam>
        /// <param name="list">Lista que será organizada.</param>
        /// <param name="field">Campo pelo qual se deseja organizar.</param>
        /// <param name="direction">Direção em que a lista deve ser ordenada.</param>
        /// <returns>Uma Lista do tipo T organizada.</returns>
        IList<T> Organize<K>(IList<T> list, Func<T, K> field, Direction direction) where K : IComparable;
    }
}
