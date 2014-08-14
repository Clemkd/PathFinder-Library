using System;

namespace PathFinderLibrary
{
    public class Vector2
    {
        /// <summary>
        /// Constante de coordonnee horizontale par defaut
        /// </summary>
        private const int DEFAULT_X = 0;

        /// <summary>
        /// Constante de coordonnee verticale par defaut
        /// </summary>
        private const int DEFAULT_Y = 0;

        /// <summary>
        /// Nouveau vecteur de coordonnees par defaut { x = 0; y = 0 }
        /// </summary>
        public Vector2()
        {
            X = DEFAULT_X;
            Y = DEFAULT_Y;
        }

        /// <summary>
        /// Nouveau vecteur de coordonees entrees
        /// </summary>
        /// <param name="x">Coordonnee horizontale</param>
        /// <param name="y">Coordonnee verticale</param>
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Obtenir ou modifier la coordonnee X
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Obtenir ou modifier la coordonnee Y
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Test l'equivalence entre l'instance actuelle est l'objet en parametre
        /// </summary>
        /// <param name="o">Objet a comparer</param>
        /// <returns>Retourne Vrai si les deux objets sont equivalents et Faux dans le cas contraire</returns>
        public override bool Equals(Object o)
        {
            if (o == null)
                return false;
            if (!(o is Vector2))
                return false;
            Vector2 obj = (Vector2)o;
            if (obj == this)
                return true;
            if (obj.X == this.X && obj.Y == this.Y)
                return true;
            return false;
        }

        /// <summary>
        /// Convertion en chaine de caracteres
        /// </summary>
        /// <returns>Retourne une chaine de caracteres definissant le vecteur</returns>
        public override string ToString()
        {
            return "{" + this.X.ToString() + ", " + this.Y.ToString() + "}";
        }

        /// <summary>
        /// Hashcode de l'instance actuelle 
        /// </summary>
        /// <returns>Retourne le hashcode de l'instance actuelle</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Operateur d'addition de vecteur
        /// </summary>
        /// <param name="vector1">Premier vecteur a additionner</param>
        /// <param name="vector2">Second vecteur a additionner</param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}
