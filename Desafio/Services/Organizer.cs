#region --Using--
using Desafio.Entidades;
using Desafio.Enums;
using Desafio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Desafio.Services
{
    public class Organizer<T> : IOrganizer<T>
    {
        public IList<T> Organize<K>(IList<T> listToOrganize, Func<T, K> field, Direction direction) where K : IComparable
        {
            var list = new List<T>(listToOrganize);

            var organizedList = new List<T>();

            var latestEntry = new LatestEntry<T, K>();
          
            while (ListToOrganizeHasItems(list))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (IsFirstIteration(currentIndex: i))
                    {
                        SetLatestEntry
                        (
                            latestEntry: latestEntry,
                            currentIndex: i,
                            listToOrganize: list,
                            organizeByField: field
                        );
                    }
                    else if (EntryShouldBeStored(latestEntry.Sorter, list.Select(field).ElementAt(i), direction))
                    {
                        SetLatestEntry
                        (
                            latestEntry: latestEntry,
                            currentIndex: i,
                            listToOrganize: list,
                            organizeByField: field
                        );
                    }


                }

                organizedList.Add(latestEntry.Value);
                list.RemoveAt(latestEntry.Index);
            }
            return organizedList;
        }
      
        private void SetLatestEntry<K>(LatestEntry<T, K> latestEntry, IList<T> listToOrganize, Func<T, K> organizeByField, int currentIndex) where K : IComparable
        {
            latestEntry.Sorter = listToOrganize.Select(organizeByField).ElementAt(currentIndex);
            latestEntry.Value = listToOrganize.ElementAt(currentIndex);
            latestEntry.Index = currentIndex;
        }

        private bool ListToOrganizeHasItems(IList<T> listToOrganize)
            => listToOrganize.Any();

        private bool IsFirstIteration(int currentIndex) 
            => currentIndex == 0;

        private bool EntryShouldBeStored<K>(K latestEntryValueSorter, K currentEntryElement, Direction direction) where K : IComparable
                => direction == Direction.Ascending
                ? latestEntryValueSorter.CompareTo(currentEntryElement) > 0
                : latestEntryValueSorter.CompareTo(currentEntryElement) < 0;

    }
}
