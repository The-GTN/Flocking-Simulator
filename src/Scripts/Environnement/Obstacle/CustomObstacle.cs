// Vector3
using UnityEngine;
//List
using System.Collections.Generic;

// Classe pour les obstacles qui sont des points d'impacts
public class CustomObstacle : Obstacle
{
   // Attributs

   // l'esthetique de l'obstacle
   public GameObject figure;

   // Méthodes

   // point d'obstacle construit par rapport à sa position
   public CustomObstacle(Environnement e, Vector3 p,GameObject g) : base(e,p) {figure = g;}
   
   // créer l'objet 3D relatif à cet obstacle
   public override void createObject() { 
        env.createObject(figure, position);
   } 

   // retourne les deux tangentes au point d'impact entre l'agent et l'obstacle
   public override List<Vector3> getTangentes(Agent a) {
      return new List<Vector3> {
            Quaternion.Euler(-90, 0, 0) * a.deplacement, Quaternion.Euler(90, 0, 0) * a.deplacement,
            Quaternion.Euler(0, -90, 0) * a.deplacement, Quaternion.Euler(0, 90, 0) * a.deplacement,
            Quaternion.Euler(0, 0, -90) * a.deplacement, Quaternion.Euler(0, 0, 90) * a.deplacement
        };
   }

   // retourne le point de contact en l'Agent a et l'obstacle
   public override Vector3 getPointContact(Agent a) {
      return position;
   }

}
