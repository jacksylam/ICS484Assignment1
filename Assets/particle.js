 #pragma strict

 var particleCount : int;
 var a : int = 1;
 var b : int = 1;
 var c : int = 0;

 function Start ()
 {
     var myParticleSystem : ParticleSystem;
     var myParticles: ParticleSystem.Particle[];

     myParticleSystem = GetComponent(ParticleSystem);
     myParticleSystem.Emit(particleCount);
     myParticles = new ParticleSystem.Particle[particleCount + 1];

     var x : float;
     var y : float;
     var prevPos : Vector3;

     for (var i = 0; i < particleCount; i++)
     {
         // Get previous particle position
         prevPos = (i < 1) ? Vector3.one : myParticles[i - 1].position;

         x = prevPos.x;
         y = prevPos.y;

         var x1 = y - x / Mathf.Abs(x) * Mathf.Sqrt(Mathf.Abs(2*b * x + c));
         var y1 = a - x;

         var newPosition = new Vector3(x1, y1, 0);

         myParticleSystem.GetParticles(myParticles);
         myParticles[i].position = newPosition;
         myParticleSystem.SetParticles(myParticles, particleCount);
     }
 }
