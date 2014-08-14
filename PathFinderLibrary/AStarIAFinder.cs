using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinderLibrary
{
    [CLSCompliant(true)]
    public class AStarIAFinder
    {
        /// <summary>
        /// La distance de base entre deux noeuds
        /// </summary>
        public const int DISTANCE_NODE = 10;

        /// <summary>
        /// Selectionne le meilleur noeud de la liste, d'un point de vu heuristique
        /// </summary>
        /// <param name="listNode">La liste de noeud a etudier</param>
        /// <returns>Retourne le noeud ayant le cout de deplacement le plus faible</returns>
        private static Node bestNode(List<Node> listNode)
        {
            if (listNode.Count() > 0)
            {
                Node bestNode = listNode.ElementAt(0);
                for (int i = 1; i < listNode.Count(); i++)
                    if (listNode.ElementAt(i).f < bestNode.f)
                        bestNode = listNode.ElementAt(i);
                return bestNode;
            }
            return null;
        }

        /// <summary>
        /// Calcul le cout de deplacement de chaque noeud d'une liste
        /// </summary>
        /// <param name="listNode">La liste de noeud a gerer</param>
        /// <param name="endNode">Le noeud de destination</param>
        private static void setQuality(List<Node> listNode, Node endNode)
        {
            foreach (Node node in listNode)
            {
                int g;
                if (node.parent == null)
                    g = DISTANCE_NODE;
                else
                    g = node.parent.g + DISTANCE_NODE;

                int h = (int)(Math.Abs(endNode.getPosition().X - node.getPosition().X) +
                    Math.Abs(endNode.getPosition().Y - node.getPosition().Y)) * DISTANCE_NODE;
                int f = g + h;

                node.g = g;
                node.h = h;
                node.f = f;
            }
        }

        /// <summary>
        /// Resolveur de chemin selon la methode de resolution AStar
        /// </summary>
        /// <param name="startNode">Le noeud de depart</param>
        /// <param name="endNode">Le noeud de destination</param>
        /// <param name="map">Le tableau de noeuds</param>
        /// <returns>Retourne la liste des noeuds resolvant le chemin entre le noeud de depart et le noeud d'arrivee</returns>
        public static List<Node> FindPath(Node startNode, Node endNode, Node[,] map)
        {
            if (map.Length.Equals(0))
                throw new PathFinderException("Le tableau est vide");
            if (!(startNode.getPosition().X >= 0 && startNode.getPosition().Y >= 0 &&
                startNode.getPosition().X < map.GetLength(0) && startNode.getPosition().Y < map.GetLength(1)))
                throw new PathFinderException("Le noeud de depart est en dehors du tableau");
            if (!(endNode.getPosition().X >= 0 && endNode.getPosition().Y >= 0 &&
                endNode.getPosition().X < map.GetLength(0) && endNode.getPosition().Y < map.GetLength(1)))
                throw new PathFinderException("Le noeud de fin est en dehors du tableau");

            List<Node> resultPath = new List<Node>();
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(startNode);
            Node currentNode = null;

            while (openList.Count() > 0)
            {
                setQuality(openList, endNode);
                currentNode = bestNode(openList);

                if (currentNode == endNode)
                    break;

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                List<Node> neighbours = currentNode.Neighbors(map);

                foreach (Node node in neighbours)
                {
                    if (closedList.Exists(x => x.Equals(node)) || node.obstacle)
                        continue;

                    node.parent = currentNode;

                    int g = node.parent.g + DISTANCE_NODE;
                    int h = (int)(Math.Abs(endNode.getPosition().X - node.getPosition().X) +
                        Math.Abs(endNode.getPosition().Y - node.getPosition().Y)) * DISTANCE_NODE;
                    int f = g + h;

                    if (openList.Exists(x => x.Equals(node)))
                    {
                        if (g < node.g)
                        {
                            node.parent = currentNode;
                            node.g = g;
                            node.h = h;
                            node.f = f;
                        }
                    }
                    else
                    {
                        closedList.Remove(node);
                        openList.Add(node);
                        node.parent = currentNode;
                        node.g = g;
                        node.h = h;
                        node.f = f;
                    }
                }
            }

            if (openList.Count() == 0)
                return resultPath;

            Node lastNode = endNode;

            while (lastNode != startNode)
            {
                lastNode = lastNode.parent;
                resultPath.Add(lastNode);
            }

            resultPath.Reverse();

            if (resultPath.Count() > 0)
                resultPath.RemoveAt(0);
            resultPath.Add(endNode);

            return resultPath;
        }
    }
}
