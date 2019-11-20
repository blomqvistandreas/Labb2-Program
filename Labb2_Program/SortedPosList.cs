using System.Collections.Generic;

namespace Labb2_Program
{
    internal class SortedPosList
    {
        List<Position> posList { get; set; }
        public SortedPosList() => posList = new List<Position>();

        public int Count()
        {
            return posList.Count;
        }

        public void Add(Position pos)
        {
            if (posList.Count <= 0)
            {
                posList.Add(pos);
            }
            else
            {
                for (int i = 0; i < posList.Count; i++)
                {
                    if (posList[i] > pos)
                    {
                        posList.Insert(i, pos);
                        return;
                    }

                }
                posList.Add(pos);
            }
        }

        public bool Remove(Position pos)
        {
            bool didRemove = false;

            for (int i = 0; i < posList.Count; i++)
            {
                if (posList[i].Equals(pos))
                {
                    posList.RemoveAt(i);
                    didRemove = true;
                }
            }
            return didRemove;
        }

        public SortedPosList Clone()
        {
            SortedPosList copy = new SortedPosList();

            foreach (Position position in posList)
            {
                Position pos = position.Clone();
                copy.Add(pos);
            }
            return copy;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList posInsideCircle = new SortedPosList();

            for (int i = 0; i < this.posList.Count; i++)
            {
                Position position = this.posList[i];
                bool isInside = (position.X - centerPos.X) * (position.X - centerPos.X) + (position.Y - centerPos.Y) * (position.Y - centerPos.Y) < radius * radius;

                if (isInside)
                {
                    posInsideCircle.Add(position.Clone());
                }
            }

            return posInsideCircle;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList copiedList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                copiedList.Add(sp2.posList[i]);
            }
            return copiedList;
        }

        public override string ToString()
        {
            return string.Join(", ", posList);
        }
    }
}