// List
using System.Collections.Generic;
// Vector3 + GameObject
using UnityEngine;

// Classe pour une topologie d'environnement en forme de cube
public class Cube : Topologie
{

    // Attributs

    // borne inférieur en x
    protected float minX;
    // borne maximum en x
    protected float maxX;
    // borne inférieur en y
    protected float minY;
    // borne maximum en y
    protected float maxY;
    // borne inférieur en z
    protected float minZ;
    // borne maximum en z
    protected float maxZ;
    // visuel du cube 
    protected GameObject cube;

    // Méthodes

    // la topologie en cube se construit à partir du visuel du cube
    public Cube(Environnement e, GameObject c) : base(e) { 
        cube = c;
        float scaleX = cube.transform.localScale.x;
        float scaleY = cube.transform.localScale.y;
        float scaleZ = cube.transform.localScale.z;
        minX = -scaleX/2.0f;maxX = scaleX/2.0f;
        minY = -scaleY/2.0f;maxY = scaleY/2.0f;
        minZ = -scaleZ/2.0f;maxZ = scaleZ/2.0f;
        
    }

    // retourne la liste des limites du cube dans cet ordre [minX,maxX,minY,maxY,minZ,maxZ] 
    public List<float> getExtremums() {
        return new List<float> {minX,maxX,minY,maxY,minZ,maxZ};
    }

    // retourne le GameObject de la topologie
    public override GameObject getGameObject() { return cube;}

    // retourne le point de la topologie que l'agent current pourrait heurter
    public override Observation detectEnv(Agent current) {
        Vector3 pos = current.transform.position;
        List<Vector3> p = new List<Vector3>
        { 
            new Vector3(minX,pos.y,pos.z), new Vector3(maxX,pos.y,pos.z),
            new Vector3(pos.x,minY,pos.z), new Vector3(pos.x,maxY,pos.z),
            new Vector3(pos.x,pos.y,minZ), new Vector3(pos.x,pos.y,maxZ),
        };
        float dist = Utils.normVector(p[0] - pos);
        float d; Vector3 res = p[0];
        for(int i=1;i<p.Count;i++) {
            d = Utils.normVector(p[i] - pos);
            if(d<dist) {
                dist = d;
                res = p[i];
            }
        }

        Vector3 XY = (new Vector3(1.0f,1.0f,0.0f)).normalized;
        Vector3 XZ = (new Vector3(1.0f,0.0f,1.0f)).normalized;
        Vector3 YZ = (new Vector3(0.0f,1.0f,1.0f)).normalized;
        Vector3 haut = new Vector3(0.0f,1.0f,0.0f);
        Vector3 droite = new Vector3(1.0f,0.0f,0.0f);
        Vector3 devant = new Vector3(0.0f,0.0f,1.0f);
        List<Vector3> X = new List<Vector3> {haut,-haut,devant,-devant,YZ,-YZ};
        List<Vector3> Y = new List<Vector3> {droite,-droite,devant,-devant,XZ,-XZ};
        List<Vector3> Z = new List<Vector3> {haut,-haut,droite,-droite,XY,-XY};
        if (res.x == minX || res.x == maxX) 
            return new Observation(new PointObstacle(environnement,res,X),res-pos);
        else if (res.y == minY || res.y == maxY)
            return new Observation(new PointObstacle(environnement,res,Y),res-pos);
        else
            return new Observation(new PointObstacle(environnement,res,Z),res-pos);
    }

    // retourne une position valide dans la topologie
    public override Vector3 validPosition() {
        return Utils.randomVector(minX, maxX, minY, maxY, minZ, maxZ);
    }

    // indique si la position est valide dans la topologie
    public override bool isValidPosition(Vector3 pos) {
        bool x = (minX <= pos.x) && (pos.x <= maxX);
        bool y = (minY <= pos.y) && (pos.y <= maxY);
        bool z = (minZ <= pos.z) && (pos.z <= maxZ);
        return (x && y) && z;
    }

    // retourne la distance maximale mesurable dans la topologie
    public override float getMaxDistance() {
        return Utils.normVector(minX,maxX,minY,maxY,minZ,maxZ);
    }

    // renvoie la position v de tel sorte à ce qu'elle soit valide dans le cube 
    protected Vector3 convertToValidOne(Vector3 v) {
        Vector3 res = v;
        if (v.x > maxX) res.x = maxX;
        else if (v.x < minX) res.x = minX;
        if (v.y > maxY) res.y = maxY;
        else if (v.y < minY) res.y = minY;
        if (v.z > maxZ) res.z = maxZ;
        else if (v.z < minZ) res.z = minZ;
        return res;
    }

    // indique si le déplacement en x, y et z est unidirectionnel 
    protected bool onlyOneDirection(float x, float y, float z) {
        return (x == 0.0f && z== 0.0f) || (y == 0.0f && z== 0.0f) || (x== 0.0f && y==0.0f);
    }

    // indique quel position d'impact d'environnement entre p1 et p2 est le plus adapté pour l'agent current 
    protected Vector3 bestOne(Agent current,Vector3 p1,Vector3 p2) {
        Vector3 pos = current.transform.position;
        if(Utils.normVector(p1-pos) < Utils.normVector(p2-pos)) return p1;
        else return p2;
    }
    
}
