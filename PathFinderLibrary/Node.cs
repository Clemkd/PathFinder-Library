using System;
using System.Collections.Generic;

namespace PathFinderLibrary
{
    [CLSCompliant(true)]
    public class Node
    {
        private Vector2 position;
        private bool isObstacle;
        private int uF, uG, uH;
        private Node nParent;

        /// <summary>
        /// Créer un nouveau noeud et initialise sa position
        /// </summary>
        /// <param name="position">La position absolue du noeud</param>
        public Node(Vector2 position)
        {
            this.position = position;
            this.parent = parent;
        }

        /// <summary>
        /// Créer un nouveau noeud et initialise sa position et son état
        /// </summary>
        /// <param name="position">La position absolue du noeud</param>
        /// <param name="obstacle">L'état "bloquant" du noeud</param>
        public Node(Vector2 position, bool obstacle)
        {
            this.position = position;
            this.isObstacle = obstacle;
            this.parent = null;
        }

        // Obtenir ou modifier l'état "bloquant" du noeud
        public bool obstacle
        {
            get { return this.isObstacle; }
            set { this.isObstacle = value; }
        }

        /// <summary>
        /// L'heuristique f
        /// </summary>
        public int f
        {
            get { return this.uF; }
            set { this.uF = value; }
        }

        /// <summary>
        /// L'heuristique g
        /// </summary>
        public int g
        {
            get { return this.uG; }
            set { this.uG = value; }
        }

        /// <summary>
        /// L'heuristique h
        /// </summary>
        public int h
        {
            get { return this.uH; }
            set { this.uH = value; }
        }

        /// <summary>
        /// Le noeud parent
        /// </summary>
        public Node parent
        {
            get { return this.nParent; }
            set { this.nParent = value; }
        }

        /// <summary>
        /// La position absolue du noeud
        /// </summary>
        /// <returns>Retourne la position absolue du noeud</returns>
        public Vector2 getPosition()
        {
            return this.position;
        }

        /// <summary>
        /// La liste des noeuds voisins adjacents de l'instance actuelle
        /// </summary>
        /// <param name="map">La carte de noeuds</param>
        /// <returns>Retourne la liste des noeuds voisins de distance 1 du noeud</returns>
        public List<Node> GetAdjacentNeighbors(Node[,] map)
        {
            List<Node> neighbors = new List<Node>();
            Vector2[] coordinates = {new Vector2(1,0), new Vector2(-1, 0),
                                     new Vector2(0, 1), new Vector2(0, -1)};
            foreach (Vector2 coordinate in coordinates)
            {
                Vector2 location = coordinate + this.position;
                if (location.X >= 0 && location.Y >= 0 && location.X < map.GetLength(0) && location.Y < map.GetLength(1))
                    if (!map[location.X, location.Y].obstacle)
                        neighbors.Add(map[location.X, location.Y]);
            }

            return neighbors;
        }

        /// <summary>
        /// La liste des noeuds voisins de l'instance actuelle
        /// </summary>
        /// <param name="map">La carte de noeuds</param>
        /// <returns>Retourne la liste des noeuds voisins de distance 1 du noeud</returns>
        public List<Node> GetNeighbors(Node[,] map)
        {
            List<Node> neighbors = new List<Node>();
            Vector2[] coordinates = {new Vector2(1,0), new Vector2(-1, 0),
                                     new Vector2(0, 1), new Vector2(0, -1),
                                     new Vector2(-1, -1), new Vector2(1, -1),
                                     new Vector2(-1, 1), new Vector2(1, 1)};

            foreach (Vector2 coordinate in coordinates)
            {
                Vector2 location = coordinate + this.position;
                if (location.X >= 0 && location.Y >= 0 && location.X < map.GetLength(0) && location.Y < map.GetLength(1))
                    if (!map[location.X, location.Y].obstacle)
                        neighbors.Add(map[location.X, location.Y]);
            }

            return neighbors;
        }

        /// <summary>
        /// Compare l'instance actuelle et un autre objet
        /// </summary>
        /// <param name="o">L'objet à comparer</param>
        /// <returns>Retourne vrai si l'objet actuel est équivalent à l'objet passé en paramètre</returns>
        public override bool Equals(Object o)
        {
            if (o == null)
                return false;
            if (!(o is Node))
                return false;
            Node obj = (Node)o;
            if (obj == this)
                return true;
            if (obj.position.Equals(this.position))
                return true;
            return false;
        }

        /// <summary>
        /// Le hashcode de l'instance actuelle
        /// </summary>
        /// <returns>Retourne le hashcode de l'instance</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
