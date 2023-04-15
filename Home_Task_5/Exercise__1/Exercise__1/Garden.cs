using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__1
{
    public class Garden : IEquatable<Garden>
    {
        private Tree[] trees;
        private double dovzhinaZabory;

        public Garden(Tree[] trees)
        {
            this.trees = trees;
            this.dovzhinaZabory=ComputePerimeter(trees);
        }
        public static bool operator ==(Garden g, Garden g2)
        {
            if (g.dovzhinaZabory == g2.dovzhinaZabory) { return true; }
            else { return false; }
        }
        public static bool operator !=(Garden g, Garden g2)
        {
            if (g.dovzhinaZabory == g2.dovzhinaZabory) { return false; }
            else { return true; }
        }
        private double DistanceBetweenTrees(Tree p1, Tree p2)//відстань між 2 деревами
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        private Tree[] JarvisAlgo() { //створення масиву дерев по яким буде створений наша огорожа за допомогою алгоритма джарвіса
            List<Tree> ogorozha = new List<Tree>();

            if (trees.Length < 3)
            {
                return ogorozha.ToArray();
            }
            Tree startTree = trees[0];//початкове дерево
            foreach (Tree t in trees)
            {
                if (t.Y < startTree.Y || (t.Y ==startTree.Y && t.X<startTree.X ))
                {
                    startTree = t;
                }
            }
            ogorozha.Add(startTree);
            Tree tree1 = startTree;
            Tree tree2;
            do {
                tree2 = trees[0];
                foreach (Tree t1 in trees)
                {
                    if (t1 == tree1)
                    {
                        continue;
                    }

                    double dir = Direction(tree1, tree2, t1);
                    if (dir > 0)
                    {
                        tree2 = t1;
                    }
                    else if (dir == 0 && DistanceBetweenTrees(tree1, t1) > DistanceBetweenTrees(tree1, tree2))
                    {
                        tree2 = t1;
                    }
                }

                ogorozha.Add(tree2);
                tree1 = tree2;


            } while (tree1 != startTree);
            ogorozha.RemoveAt(ogorozha.Count - 1);

            return ogorozha.ToArray();

        }


        public  double ComputePerimeter(Tree[] myOgorosha)//пошук довжини огорожи
        {
            myOgorosha = JarvisAlgo();
            double perimeter = 0;
            if (myOgorosha.Length < 2)
            {
                return perimeter;
            }
            else if (myOgorosha.Length == 2) { double d = DistanceBetweenTrees(myOgorosha[0], myOgorosha[1]);return d; }

            Tree first = myOgorosha[0];
            for (int i = 1; i < myOgorosha.Length; i++)
            {
                perimeter += DistanceBetweenTrees(first, myOgorosha[i]);
                first = myOgorosha[i];
            }

            perimeter += DistanceBetweenTrees(first, myOgorosha[0]);

            return perimeter;
        }
        private static double Direction(Tree A, Tree B, Tree C)//напрям формування забору
        {
            return (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Garden);
        }

        public bool Equals(Garden? other)
        {
         
            if (dovzhinaZabory == other.dovzhinaZabory) { return true; }
            else { return false; }
        }
        public override string? ToString()
        {
            return $"This garden fence's length is {dovzhinaZabory} and it contains {trees.Length} trees";
        }
    }
}
