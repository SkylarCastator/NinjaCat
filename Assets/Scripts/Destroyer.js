var timeTilDeath : int = 5;
function Update () {
Destroy(gameObject, timeTilDeath);
if(transform.position.y < -400 || transform.position.x < -400 ||transform.position.x > 400){
Destroy(gameObject);
}

}