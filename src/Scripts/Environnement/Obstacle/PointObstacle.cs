// Vector3
using UnityEngine;
//List
using System.Collections.Generic;

// Classe pour les obstacles qui sont des points d'impacts
public class PointObstacle : Obstacle
{
   
   // Attributs

   // les tangentes au point
   public List<Vector3> tangentes;

   // Méthodes

   // point d'obstacle construit par rapport à sa position et à ses tangentes
   public PointObstacle(Environnement e, Vector3 p, List<Vector3> t) : base(e,p) {
       tangentes = t;
   }

   // point d'obstacle construit par rapport à sa position
   public PointObstacle(Environnement e, Vector3 p) : base(e,p) {
       tangentes = new List<Vector3>();
   }
   
   // retourne le point de contact en l'Agent a et l'obstacle
   public override Vector3 getPointContact(Agent a) {
       return position;
   }
   
   // retourne les deux tangentes au point d'impact entre l'agent et l'obstacle
   public override List<Vector3> getTangentes(Agent a) {
       return tangentes;
   }
   
   // créer l'objet 3D relatif à cet obstacle
   public override void createObject() {} 

}
